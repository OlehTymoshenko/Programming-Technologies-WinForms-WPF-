using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;

namespace Lab_9_techol_progr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Коллекция для хранения всех инф. о животных
        /// </summary>
        ObservableCollection <Animal> list = new ObservableCollection<Animal>();
        /// <summary>
        /// Путь к файлу для сохранения инф. о животный 
        /// </summary>
        string FILE_PATH = Environment.CurrentDirectory + "\\DataBase.xml";

        /// <summary>
        /// Конструктор 
        /// </summary>
        public MainWindow()
        { 
            InitializeComponent();
            this.DataContext = new Animal(); // задаем контекст
            // Задаем животных по-умолчанию
            Animal[] arr = { new Animal("Boby", 3, "Bear", 250, 150), new Animal("Candy", 2, "Squirrel", 2, 25) };
            foreach(Animal i in arr) // добавляем животных в коллекцию
            {
                list.Add(i);
            }
            DGV.ItemsSource = list; // выводим в dataGRid
        }
        /// <summary>
        /// обработчик события Validation.Error для NameTb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTb_Error(object sender, ValidationErrorEventArgs e)
        {
            if(e.Action == ValidationErrorEventAction.Added) // если случилась ошибка 
            {
                MessageBox.Show(e.Error.ErrorContent.ToString(), "Error in Name text box");
            }
        }

        /// <summary>
        /// обработчик события Validation.Error для AgeTb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgeTb_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) // если случилась ошибка 
            {
                MessageBox.Show(e.Error.ErrorContent.ToString(), "Error in Age text box");
            }
        }

        /// <summary>
        /// обработчик события Validation.Error для Weight.tb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WeightTb_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added) // если случилась ошибка 
            {
                MessageBox.Show(e.Error.ErrorContent.ToString(), "Error in Weight text box");
            }
        }

        /// <summary>
        /// Обработчик кнопки для добавления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Есть ли ошибки при валидации
                if ((!Validation.GetHasError(NameTb)) && (!Validation.GetHasError(AgeTb)) && (!Validation.GetHasError(WeightTb)))
                { // добавляем новую запись
                    list.Add(new Animal(NameTb.Text, short.Parse(AgeTb.Text), KindTb.Text, short.Parse(WeightTb.Text), short.Parse(GrowthTb.Text)));
                }
                else // если есть ошибки валидации
                    MessageBox.Show("Error in inputed data", "Error");
            }
            catch (Exception ex) // отлавливаем исключения
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Обработчик кнопки для изменения записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Change_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Изменяем выбранную запись
                list[DGV.SelectedIndex] = new Animal(NameTb.Text, short.Parse(AgeTb.Text), KindTb.Text, short.Parse(WeightTb.Text), short.Parse(GrowthTb.Text));
            }
            catch (Exception ex) // отлавливаем исключения
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Обработчик кнопки выхода из приложения 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Обработчик кнопки удаления записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                list.RemoveAt(DGV.SelectedIndex); // удаляем выбранную запись
            }
            catch (Exception ex) // отлавливаем исключения
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Обработчик кнопки открытия xml файла 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Open_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                XDocument xDoc = XDocument.Load(FILE_PATH); // открыываем файл
                string name, kind; // переменные поля для считывания данных из файла
                short age, weight, growth;
                list.Clear(); // очищаем коллекцию
                foreach (XElement el in xDoc.Element("Animals").Elements("Animal")) // проходим по всем записям
                {

                    name = el.Element("Name").Value; // читаем имя
                    kind = el.Element("AnimalKind").Value; // читаем вид животного
                    age = short.Parse(el.Element("Age").Value); // возраст
                    weight = short.Parse(el.Attribute("Weight").Value); // вес
                    growth = short.Parse(el.Attribute("Growth").Value); // рост
                    list.Add(new Animal(name, age, kind, weight, growth)); // добавляем в коллекцию этот элемент
                }
            }
            catch (Exception ex) // отлавливаем исключения
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        /// <summary>
        /// Обработчик кнопки сохранения записей с файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            // создаем файл и используя функциональное конструирование в паре с Linq заполняем его информацией 
            XDocument xDoc = new XDocument(new XElement("Animals", list.Select(p => new XElement("Animal",
                new XAttribute("Weight", p.Weight), new XAttribute("Growth", p.Growth), 
                new XElement("Name", p.Name), new XElement("Age", p.Age),
                new XElement("AnimalKind", p.KindAnimal)))));
            xDoc.Save(FILE_PATH); // сохраняем созданный документ в файл
        }

        /// <summary>
        /// Обработчик для проверки значений поля Kind animal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KindTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // если длина строки получиться больше 30, то игнорируем ввод послед. символов
                string tmp = KindTb.Text + e.Text;
                if (tmp.Length > 30)
                    e.Handled = true;
        }

        /// <summary>
        /// Обработчик для проверки значений поля Growth
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GrowthTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try 
            {
                // Если ввод символа в конце
                if (GrowthTb.CaretIndex == GrowthTb.Text.Length)  
                { // то преобразуем строку и проверяем на диапазон
                    short tmp = short.Parse(GrowthTb.Text + e.Text);
                    if ((tmp > 1500) || (tmp < 1)) // если не входит, то пропускаем символ
                        e.Handled = true;
                }
                else // иначе (т.е. ввод в где-то в строке)
                { // вставляем новый символ в нужную позиции, получаем конец. строку
                    string tmp = GrowthTb.Text.Substring(0, GrowthTb.CaretIndex) + e.Text + GrowthTb.Text.Substring(GrowthTb.CaretIndex);
                    short tmpVal = short.Parse(tmp); // преобраз. в число
                    if ((tmpVal > 1500) || (tmpVal < 1)) // проверка на диапазон
                        e.Handled = true; // пропускаем символ
                }
            }
            catch // отлавливаем исключения
            {
                e.Handled = true;// пропускаем символ
            }
        }

        /// <summary>
        /// Обработчик выбора элемента в dataGrid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // получаем выбранну запись
                Animal item = list[DGV.SelectedIndex];
                // выводим все поля в соотв. textBox-сы
                NameTb.Text = item.Name; 
                AgeTb.Text = item.Age.ToString();
                KindTb.Text = item.KindAnimal;
                WeightTb.Text = item.Weight.ToString();
                GrowthTb.Text = item.Growth.ToString();
            }
            catch { } // если выбрали элемент,
            // а потом его изменили, чтобы не возникало исключение
        }
    }

    /// <summary>
    /// Реализация правила проверки для поля Name
    /// </summary>
    public class NameValidationRule : ValidationRule
    {
        private string errorMessage;
        public string ErrorMessage // сообщение, которые будет возв.
        {                          // в случ. не прохождения валидации
            get { return errorMessage; }

            set { errorMessage = value; }
        }

        /// <summary>
        /// Метод для проверки поля Name
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                // проверка на диапазон 
                if ((((string)value).Length < 1) || (((string)value).Length > 30))
                {
                    return new ValidationResult(false, "Name cant be less then 2 or greater than 30 symbols");
                }
                return new ValidationResult(true, null);
            }
            catch // если возникло исключение
            {
                return new ValidationResult(false, this.ErrorMessage);
            }
        }
    }

    /// <summary>
    /// Реализация правила проверки для поля Age
    /// </summary>
    public class AgeValidationRule : ValidationRule
    {
        // сообщение, которые будет возв. в случ. не прохождения валидации
        public string ErrorMessage { get; set; } = "Unexpected error";

        /// <summary>
        /// Метод для проверки поля Age
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            short age = 0;
            try // преоб. строку в short
            {
                age = short.Parse((string)value);
            }
            catch // если не удалось, то ошибка
            {
                return new ValidationResult(false, this.ErrorMessage);
            }

            // проверка на диапазон
            if ((age < 0) || (age >= 300))
            { // если число не прошло проверку
                return new ValidationResult(false, "Age range must be start with 0 to 300 years");
            }
            else // если все нормально
            {
                return new ValidationResult(true, null);
            }
        }
    }

    /// <summary>
    /// Реализация правила проверки для поля Weight
    /// </summary>
    public class WeightValidationRule : ValidationRule
    {
        // сообщение, которые будет возв. в случ. не прохождения валидации
        public string ErrorMessage { get; set; } = "Unexpected error";

        /// <summary>
        /// Метод для проверки поля Weight
        /// </summary>
        /// <param name="value"></param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            short weight = 0;
            try
            {    // преоб. строку в short
                weight = short.Parse((string)value);
            }
            catch // если не удалось, то ошибка
            {
                return new ValidationResult(false, this.ErrorMessage);
            }
            // проверка на диапазон
            if ((weight < 0) || (weight >= 1000))
            {
                return new ValidationResult(false, "Weight range must be start with 0 to 1000 years");
            }
            else // если все нормально
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
