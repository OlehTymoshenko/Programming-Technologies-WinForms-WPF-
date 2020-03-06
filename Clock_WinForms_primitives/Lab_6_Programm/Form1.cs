using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Lab_6_Programm
{
    /// <summary>
    /// класс реализующий часы
    /// </summary>
    public partial class FormClock : Form
    {
        /// <summary>
        /// Количество полей, свойств, которые нужны для восстановления часов из файла
        /// </summary>
        const short COUNT_FIELEDS_FOR_SAVE = 11;
        /// <summary>
        /// представляет цент pictureBox-a
        /// </summary>
        public Point _centerPoint;
        /// <summary>
        /// Шрифт для цифер на часах
        /// </summary>
        Font _numFont = new Font("Calibri", 14, FontStyle.Bold);
        /// <summary>
        /// Поле представляющее собой текущую позицию курсора, нужна для перемещения часов
        /// по зажиму левой кнопки миши
        /// </summary>
        Point CursorPoint = new Point();
        /// <summary>
        /// Радиус часов
        /// </summary>
        public double ClockSize { get; set; }
        /// <summary>
        /// Цвет циферблата часов
        /// </summary>
        public SolidBrush BackgroundColor { get; set; } = new SolidBrush(Color.MidnightBlue);
        /// <summary>
        /// Цвет рамки часов
        /// </summary>
        public Color BorderLineColor { get; set; } = Color.MidnightBlue;
        /// <summary>
        /// Цвет цифр, и остальных линий для часов, цвет точко в центре часов
        /// </summary>
        public SolidBrush NumbersColor { get; set; } = new SolidBrush(Color.LightSkyBlue);
        /// <summary>
        /// Цвет часовой стрелки
        /// </summary>
        public Color HourLineColor { get; set; } = Color.LightSkyBlue;
        /// <summary>
        /// Цвет минутной стрелки
        /// </summary>
        public Color MinLineColor { get; set; } = Color.LightSkyBlue;
        /// <summary>
        /// Цвет секундной стрелки
        /// </summary>
        public Color SecLineColor { get; set; } = Color.LightSkyBlue;
        /// <summary>
        /// Цвет фона для цифровых часов
        /// </summary>
        public Color BackColorDigitalClock { get; set; } = Color.MidnightBlue;
        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FormClock()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); /* Устанавливаем двойную буферизацию */
            this.SetStyle(ControlStyles.UserPaint, true); // чтобы элемент прорисововал сам себя
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); // для уменьшения мерцания

            this.FormBorderStyle = FormBorderStyle.None; // форма без рамок
            this.TransparencyKey = Control.DefaultBackColor; // прозрачную область формы делать невидимой

            _linkLabel.Text = string.Empty; // обнуляем время
            _linkLabel.BackColor = BackColorDigitalClock; // задаем цвет фона
            _linkLabel.Visible = false; // скрываем цифровые часы

            SetStartParams(); // устанавливаем центральную точку и радиус

            _timer.Interval = 999; // интервал генерации события таймером
            _timer.Enabled = true; // вкл таймер

            Graphics _gr = _pictureBox.CreateGraphics(); // получаем графику
            DrawBackground(ref _gr); // прорисовываем основу часов(циферблат и рамку)
            _gr.Dispose(); // освобождаем ресурсы
        }
        /// <summary>
        /// Метод для записи конфигур. часов в файл
        /// </summary>
        /// <returns></returns>
        string WriteSettings()
        {
            try // отлавливаем ошибки
            {
                SaveFileDialog _dialog = new SaveFileDialog(); // создаем savefiledialog
                _dialog.FileName = "Config.cfg"; // имя по по умолчаниюи присваиваем
                _dialog.InitialDirectory = Application.StartupPath; // выбираем начальную директорию
                _dialog.Filter = "setting files (*.cfg)|*.cfg"; // устанавливаем фильтры
                _dialog.Title = "Сохранить файл"; // называем диалог
                if (_dialog.ShowDialog() == DialogResult.OK) // если нажали ОК
                {
                    // Открываем поток 
                    using (FileStream fs = new FileStream(_dialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        if (fs != null) // если поток успешно открыли
                        {
                            StreamWriter wr = new StreamWriter(fs); // создаем StreamWriter
                            object[] _arrOfFields = GetArrOfFields(); // получаем массив значений, которые нужно сохжранить
                            for (int i = 0; i < COUNT_FIELEDS_FOR_SAVE; i++) // проходим по всех значениям
                            { 
                                wr.WriteLine(_arrOfFields[i]); // записуем в буфер
                            }
                            wr.Flush(); // из буфера записуем в файл
                        }
                    }
                    return null; // если всех успешно закончилось
                } // если отменили процесс 
                return "Вы прервали процесс сохранения конфигурации в файл";
            }
            catch(Exception ex) // если случилось исключение
            {
                return ex.Message; // возв. сообщен. ошибки
            }
        }

        /// <summary>
        /// Метод для считывания конфигурации из файла
        /// </summary>
        /// <returns></returns>
        string ReadSetting()
        {
            try // отлавливаем исключения
            {
                OpenFileDialog dialog = new OpenFileDialog(); // создаем OpenFIleDialog
                dialog.InitialDirectory = Application.StartupPath; // начальная директория
                dialog.Filter = "Config files (*.cfg)| *.cfg"; // фильтер файлов
                dialog.Title = "Открыть файл"; // название окна
                dialog.FileName = "Config.cfg"; // название файла по умолчанию
                if(dialog.ShowDialog() == DialogResult.OK) // если польз. нажал ОК
                {   // Открываем поток 
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                    { // если удалось открыть поток, то читаем файлы
                        if(fs != null)
                        {
                            StreamReader rd = new StreamReader(fs); // создаем StreamReader
                            _linkLabel.Visible = bool.Parse(rd.ReadLine()); // читаем знач. для видимости цифровых часов
                            // Читаем цвет циферблата
                            BackgroundColor = new  SolidBrush(Color.FromArgb(int.Parse(rd.ReadLine()))); // 
                            // Читаем цвет рамки циферблата
                            BorderLineColor = Color.FromArgb(int.Parse(rd.ReadLine()));
                            // Читаем Цвет цифр
                            NumbersColor = new SolidBrush(Color.FromArgb(int.Parse( rd.ReadLine())));
                            // Читаем цвет часовой стрелки
                            HourLineColor = Color.FromArgb(int.Parse(rd.ReadLine()));
                            // Читаем цвет минутной стрелки
                            MinLineColor = Color.FromArgb(int.Parse(rd.ReadLine()));
                            // Читаем цвет секундной стрелки
                            SecLineColor = Color.FromArgb(int.Parse(rd.ReadLine()));
                            // Читаем цвет фона цифровых часов
                            BackColorDigitalClock = Color.FromArgb(int.Parse(rd.ReadLine()));
                            // читаем размеры pictureBox-a
                            _pictureBox.Size = new Size(int.Parse(rd.ReadLine()), int.Parse(rd.ReadLine()));
                            // Устанавливаем знач. центральной точки и радиуса часов
                            SetStartParams();
                            // Устанав. размер формы, подстроеный под размер области для часов
                            this.Size = new Size(_pictureBox.Width + 17, _pictureBox.Height + 40);
                            // Читаем стиль границ окна часов
                            this.FormBorderStyle = (FormBorderStyle)Enum.Parse(typeof(FormBorderStyle), rd.ReadLine());

                            _linkLabel.BackColor = BackColorDigitalClock; // задаем цвет фона

                            return null; // если все успешно
                        }
                    }
                } // если отменили процесс 
                return "Вы прервали процесс открытия конфигурации из файла";
            }
            catch (Exception ex) // если случилось исключение
            {
                return ex.Message; // возв. сообщен. ошибки
            }
        }
        /// <summary>
        /// Метод, который возвращает массив значений, которые нужно сохранить
        /// </summary>
        /// <returns></returns>
        object[] GetArrOfFields()
        {
            return new object[] { _linkLabel.Visible.ToString(), BackgroundColor.Color.ToArgb(), BorderLineColor.ToArgb(),
            NumbersColor.Color.ToArgb(), HourLineColor.ToArgb(), MinLineColor.ToArgb(), SecLineColor.ToArgb(),
            BackColorDigitalClock.ToArgb(), _pictureBox.Size.Width.ToString(), _pictureBox.Size.Height.ToString() 
            ,this.FormBorderStyle.ToString()};
        }

        /// <summary>
        /// Метод для установки параметров центальной точки и радиуса 
        /// </summary>
        void SetStartParams()
        {
            ClockSize = _pictureBox.Width / 2; // радиус
            _centerPoint = new Point(_pictureBox.Width / 2, _pictureBox.Height / 2); // центальная точка
        }
        /// <summary>
        /// Метод для показа цифровых часов
        /// </summary>
        private void ShowDigitalClock()
        {
            _linkLabel.Text = DateTime.Now.ToLongTimeString(); // берем текущее время
            _linkLabel.BackColor = BackColorDigitalClock; // задаем цвет фона
            _linkLabel.Visible = true; // делаем видимыми
        }
        /// <summary>
        ///  Метод для сокрытия цифорвых часов
        /// </summary>
        private void CloseDigitalClock()
        {
            _linkLabel.Visible = false; // скрываем часы
        }
         /// <summary>
         ///  Метод для рисования часовой линии
         /// </summary>
         /// <param name="_gr"></param>
        void DrawHourLine(ref Graphics _gr)
        {
            Pen _pen = new Pen(HourLineColor, 3); // задаем ручку, которой будет рисоватся линия 
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor; // задаем стиль окончания линии
            double _hourArc = Clock_logic.GetHourArc(DateTime.Now.Hour, DateTime.Now.Minute); // получаем угол в радианах для часовой стрелки
            // рисуем линию с помощью тригонометрических функций, которые возвращают значение на оси X или Y от значение угла и функции
            _gr.DrawLine(_pen, _centerPoint, new PointF((float)(Math.Cos(_hourArc) * (ClockSize - 20) + ClockSize), (float)(Math.Sin(_hourArc) * (ClockSize - 20) + ClockSize)));
        }
        /// <summary>
        /// Метод для рисования минутной линии
        /// </summary>
        /// <param name="_gr"></param>
        void DrawMinLine(ref Graphics _gr)
        {
            Pen _pen = new Pen(MinLineColor, 2); // задаем ручку, которой будет рисоватся линия 
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor; // задаем стиль окончания линии
            double _minArc = Clock_logic.GetMinArc(DateTime.Now.Minute, DateTime.Now.Second); // получаем угол в радианах для минутной стрелки
            // рисуем линию с помощью тригонометрических функций, которые возвращают значение на оси X или Y от значение угла и функции
            _gr.DrawLine(_pen, _centerPoint, new PointF((float)(Math.Cos(_minArc) * (ClockSize - 20) + ClockSize), (float)(Math.Sin(_minArc) * (ClockSize - 20) + ClockSize)));
        }
        /// <summary>
        /// Метод для рисования секундной линии
        /// </summary>
        /// <param name="_gr"></param>
        void DrawSecLine(ref Graphics _gr)
        {
            Pen _pen = new Pen(SecLineColor, 1); // задаем ручку, которой будет рисоватся линия 
            _pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;  // задаем стиль окончания линии
            double _secArc = Clock_logic.GetSecArc(DateTime.Now.Second); // получаем угол в радианах для секундной стрелки
            // рисуем линию с помощью тригонометрических функций, которые возвращают значение на оси X или Y от значение угла и функции
            _gr.DrawLine(_pen, _centerPoint, new PointF((float)(Math.Cos(_secArc) * (ClockSize - 20) + ClockSize), (float)(Math.Sin(_secArc) * (ClockSize - 20) + ClockSize)));
        }
        /// <summary>
        /// Метод для перерысовования испорченой области цифербалта в результате хода стрелок
        /// </summary>
        /// <param name="_gr"></param>
        private void ReDrawBackground(ref Graphics _gr)
        {
            // перерисовываем основную область
            _gr.FillEllipse(BackgroundColor, (float)(20f), (float)(20f), (float)_pictureBox.Width - 40, (float)_pictureBox.Height - 40);
            // перерисовать точку в центре часов
            _gr.FillEllipse(NumbersColor, _centerPoint.X - 4, _centerPoint.Y - 4, 8, 8);
        }
        /// <summary>
        /// Метод для рисования основной области часов, которая не будет испорчена
        /// </summary>
        /// <param name="_gr"></param>
        private void DrawBackground(ref Graphics _gr)
        {
            // прорисовка рамки формы
            _gr.DrawEllipse(new Pen(BorderLineColor, 20f), (float)(10), (float)(10), (float)_pictureBox.Width - 20, (float)_pictureBox.Height - 20);

            for (int i = 1; i <= 12; i++) // для всех часов, которые будут
            {                             // выводится линией, а не цифрой
                if ((i == 12) || (i == 3) || (i == 6) || (i == 9)) {; } // отвеиваем цифры, которые будут выводится цифрой 
                else
                {
                    // Получаем точку на поверхности круга
                    PointF p1 = new PointF((float)(Math.Cos(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize), (float)(Math.Sin(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize));
                    // рисуем линию от поверхности круга к центру
                    _gr.DrawLine(new Pen(NumbersColor, 3), p1, _centerPoint);
                }
            }
            // рисуем рамку, которая обрежет линии, которые идут к центру, и сделает их нормальной длины
            _gr.DrawEllipse(new Pen(BorderLineColor, 20f), (float)(20), (float)(20), (float)_pictureBox.Width - 40, (float)_pictureBox.Height - 40);
            ReDrawBackground(ref _gr); // рисуем область центральную часов (внутри рамки)
            for (int i = 1; i <= 12; i++) // выбираем часы которые будут выведены цифрами
            {
                switch (i) // 
                {
                    case 12: // для 12 часов
                        {
                            _gr.DrawString($"{i}", _numFont, NumbersColor, (float)(Math.Cos(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize - 12), (float)(Math.Sin(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize));
                        }
                        break;
                    case 3: // для 3 часов
                        {
                            _gr.DrawString($"{i}", _numFont, NumbersColor, (float)(Math.Cos(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize - 17), (float)(Math.Sin(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize - 12));
                        }
                        break;
                    case 6: // для 6 часов
                        {
                            _gr.DrawString($"{i}", _numFont, NumbersColor, (float)(Math.Cos(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize - 8), (float)(Math.Sin(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize - 22));
                        }
                        break;
                    case 9: // для 9 часов
                        {
                            _gr.DrawString($"{i}", _numFont, NumbersColor, (float)(Math.Cos(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize + 4), (float)(Math.Sin(((i * 30) - 90) * (Math.PI / 180)) * ClockSize + ClockSize - 12));
                        }
                        break;
                }
            }
        }
        /// <summary>
        /// Метод для вызова диалога для получения цвета
        /// </summary>
        /// <returns></returns>
        int GetColorDialog()
        {
            ColorDialog colorDialog = new ColorDialog // создаем диалог
            {                                         // и разрешаем использование
                AllowFullOpen = true                  // полной палитры выбора цвета
            };
            if (colorDialog.ShowDialog() != DialogResult.OK) // если не была нажата кнопка ОК
                return -1; // возв. знач. символизирующее ошибку выбора цвета 
            else
                return colorDialog.Color.ToArgb(); // возв. цвет в формате ARGB
        }

        /// <summary>
        ///  Метод для увеличения размера часов
        /// </summary>
        void RiseClockSize() 
        {
            if (_pictureBox.Width > 199) // задаем ограничитель, по которому можно увеличить только на 1 размер часы
            {
                MessageBox.Show("Вы достигли максимального размера для бесплатной версии, купите премиум версию для получения часов большего размера", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            this.Size = new Size(this.Size.Width + 40, this.Size.Height + 40); // если часы не максимального размера, то уведичуем их
            _pictureBox.Height += 40; // увеличуем pictureBox
            _pictureBox.Width += 40;
            SetStartParams(); // Устанавливаем параметры, которые зависят от размера часов (радиус и центральная точка)
            _linkLabel.Location = new Point(_linkLabel.Location.X + 20, _linkLabel.Location.Y + 20); // задаем новое расположение для цифровых часов
            this.Refresh(); // перерисуем форму
        }
        /// <summary>
        /// Метод для уменьшения размера часов
        /// </summary>
        void DecreseClockSize()
        {
            if (_pictureBox.Width < 121) // задаем ограничитель, по которому можно уменьшить только на 1 размер часы
            { 
                MessageBox.Show("Вы достигли минимального размера для бесплатной версии, купите премиум версию для получения часов меньшего размера", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
            }
            this.Size = new Size(this.Size.Width - 40, this.Size.Height - 40); // если часы не минимального размера, то уменьшаем их
            _pictureBox.Height -= 40; // уменьшаем pictureBox
            _pictureBox.Width -= 40;
            SetStartParams(); // Устанавливаем параметры, которые зависят от размера часов (радиус и центральная точка)
            _linkLabel.Location = new Point(_linkLabel.Location.X - 20, _linkLabel.Location.Y - 20); // задаем новое расположение для цифровых часов
            this.Refresh(); // перерисуем форму
        }
        /// <summary>
        /// Обработчик события таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _timer_Tick(object sender, EventArgs e)
        {
            Graphics _gr = _pictureBox.CreateGraphics(); // получаем графику
            _gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // задаем настройки для улучшения 
            _gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic; // графики в 
            _gr.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;        // часах
            _linkLabel.Text = DateTime.Now.ToLongTimeString(); // задаем время для цифровых часов
            ReDrawBackground(ref _gr); // перерисуем испорченую область
            DrawHourLine(ref _gr); // нарисовать часовую линию
            DrawMinLine(ref _gr); // нарисовать минутную линию
            DrawSecLine(ref _gr); // нарисовать секундную линию
            _gr.Dispose(); // освободить ресурсы графики
        }

        /// <summary>
        /// Обработик нажатия на левую кнопку мыши
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // объект типа Cursor представляет место расположения мыши         
            CursorPoint = Cursor.Position;
        }

        /// <summary>
        /// Обработчик для передвижания мишкой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // если нажата левая кнопка мыши    
            if (e.Button == MouseButtons.Left)
            {
                // определение текущих координат курсора на форме          
                Point CurrentPosition = e.Location;
                // определение текущих координат курсора на экране 
                CurrentPosition = this.PointToScreen(CurrentPosition);
                // пересчет расстояния (this.Left) между левым краем 
                // формы и левым краем клиентской части экрана 
                this.Left += CurrentPosition.X - CursorPoint.X;
                /* пересчет расстояния (this.Top) между верхним краем 
                   формы и верхним краем клиентской части экрана */
                this.Top += CurrentPosition.Y - CursorPoint.Y;
                // пересчет значения CursorPoint 
                CursorPoint = CurrentPosition;
            }
        }

        /// <summary>
        /// Обработчик для пееррисовки формы в случае ее перекрытия, т.е. порчи, не связаной с таймером
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _pictureBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics _gr = e.Graphics; // получаем графику
            DrawBackground(ref _gr); // рисуем всю графику заново
        }

        /// <summary>
        /// Обработчик для задания цвета части часов в центре рамки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClockBackroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = GetColorDialog(); // получаем цвет
            if (value != -1) // проверка на успешность получения
            {
                Color _tmp = Color.FromArgb(value); // создаем цвет из параметра
                SolidBrush solidBrush = new SolidBrush(_tmp); // создаем кисть из цвета 
                BackgroundColor = solidBrush; // задаем свойству цвета области внутри рамки новый цвет
                BackColorDigitalClock = _tmp; // задаем свойсту фона цифровых часов аналогичный цвет
                _linkLabel.BackColor = BackColorDigitalClock; // задаем самим часам новый цвет
            }
        }

        /// <summary>
        /// Обработчик для задания цвета рамки часов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = GetColorDialog();  // получаем цвет
            if (value != -1) // проверка на успешность получения
            {
                Color _tmp = Color.FromArgb(value); // создаем цвет из параметра
                BorderLineColor = _tmp; // задаем свойсту цвета рамки часов полученный цвет
                Graphics _gr = _pictureBox.CreateGraphics(); // получаем графику
                DrawBackground(ref _gr); // перерисуем часы
            }
        }

        /// <summary>
        /// Обработчик для задания цвета цифр, линий для часов на циферблате и точки внутри часов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumbersColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = GetColorDialog(); // получаем цвет
            if (value != -1) // проверка на успешность получения
            {
                Color _tmp = Color.FromArgb(value); // создаем цвет из параметра
                SolidBrush solidBrush = new SolidBrush(_tmp); // создаем кисть из цвета 
                NumbersColor = solidBrush; // задаем свойству цвета цифр и ... новый цвет
                Graphics _gr = _pictureBox.CreateGraphics(); // получаем графику
                DrawBackground(ref _gr); // перерисуем часы
            }
        }

        /// <summary>
        /// Обработчик для задания цвета часой стрелки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HourArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = GetColorDialog(); // получаем цвет
            if (value != -1) // проверка на успешность получения
            {
                HourLineColor = Color.FromArgb(value); // создаем цвет из параметра и присв. соответ. свойству
            }
        }

        /// <summary>
        /// Обработчик для задания цвета минутной стрелки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinuteArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = GetColorDialog(); // получаем цвет
            if (value != -1) // проверка на успешность получения
            {
                MinLineColor =  Color.FromArgb(value); // создаем цвет из параметра и присв. соответ. свойству
            }
        }

        /// <summary>
        /// Обработчик для задания цвета секундной стрелки 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SecArrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int value = GetColorDialog(); // получаем цвет
            if (value != -1) // проверка на успешность получения
            {
                SecLineColor = Color.FromArgb(value); // создаем цвет из параметра и присв. соответ. свойству
            }
        }

        /// <summary>
        /// Обраточик для выхода из приложения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close(); // закрываем форму
        }

        /// <summary>
        /// Обработчик кнопки "Об авторе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AbAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("\t\tПрограмма Часы\nСоздатель - Тимошенко Олег, студент 525-Б группы", "Об авторе", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
        }

        /// <summary>
        /// Обработчик для изменения стиля границ формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BorderNoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None) // если форма без рамок
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle; // задаем границы с рамками
                this.TransparencyKey = Color.White; // задаем цвет прозрачной части часов бемыл
            }
            else // если часы с границами
            {
                this.FormBorderStyle = FormBorderStyle.None; // задаем стиль границ - без рамок
                this.TransparencyKey = Control.DefaultBackColor; // задаем цвет прозрачной части часов прозрачным
            }
            this.Refresh(); // перерисовываем форму
        }

        /// <summary>
        /// Обработчик для изменения видимости цифровых часов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DigitalTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_linkLabel.Visible == false) // если скрытые, 
                ShowDigitalClock(); // то показуем
            else // если открытые, 
                CloseDigitalClock(); // то скрываем
        }

        /// <summary>
        /// Обработчик для увеличения размера часов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RiseSizeClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RiseClockSize(); // вызываем метод, который увеличит часы
        }

        /// <summary>
        /// Обрабочик для уменьшения размера формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DecreseClockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DecreseClockSize(); // вызываем метод, который уменьшит форму
        }

        /// <summary>
        /// Обработчик для записи текущей конфигурации в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WriteInFileConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = WriteSettings(); // вызываем метод для записи конфигурации и получаеи результат
            if (res == null) // если res равен null, то все успешно
            {
                MessageBox.Show("Конфигурация была успешно сохранена", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else // иначе выводим ошибку и текст ошибки
            {
                MessageBox.Show("Ошибка записи конфигурации в файл\n" + res, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        /// <summary>
        /// ОБработчик для открытия конфигурации из файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenConfigFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string res = ReadSetting(); // вызываем метод для считывания конфигурации и получаем результат
            if (res == null) // если res равен null, то все успешно
            {
                MessageBox.Show("Конфигурация была успешно считана", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                Graphics _gr = _pictureBox.CreateGraphics(); // получаем графику 
                DrawBackground(ref _gr); // вызываем метод для перерисовки графики
                _gr.Dispose(); // освобождаем ресурсы графики
            }
            else // иначе выводим ошибку и текст ошибки
            {
                MessageBox.Show("Ошибка считывания конфигурации из файла\n" + res, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}

