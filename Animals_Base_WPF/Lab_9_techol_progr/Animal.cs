using System.Globalization;
using System.Windows.Controls;

namespace Lab_9_techol_progr
{
    /// <summary>
    /// Класс, записи которго будет храниться 
    /// </summary>
    public class Animal
    {
        public Animal() { }
        /// <summary>
        /// Конструктор с параметрами 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="kind"></param>
        /// <param name="weight"></param>
        /// <param name="growth"></param>
        public Animal(string name, short age, string kind, short weight, short growth)
        {
            Name = name;
            Age = age;
            KindAnimal = kind;
            Weight = weight;
            Growth = growth;
        }
        /// <summary>
        /// Свойтсво для имени
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Свойтсво для возраста
        /// </summary>
        public short Age { get; set; }
        /// <summary>
        /// Свойтсво для вида животного
        /// </summary>
        public string KindAnimal { get; set; }
        /// <summary>
        /// Свойтсво для веса
        /// </summary>
        public short Weight { get; set; }
        /// <summary>
        /// Свойтсво для роста
        /// </summary>
        public short Growth { get; set; }

    }
}
