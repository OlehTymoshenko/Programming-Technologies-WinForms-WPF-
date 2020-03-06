using System;

namespace Lab_6_Programm
{
    /// <summary>
    /// Класс для получения углов для каждой стрелки часов
    /// </summary>
    public class Clock_logic
    {
        /// <summary>
        ///  метод для возврата угла для часовой стрелки в радианах
        /// </summary>
        /// <param name="_hour"></param>
        /// <param name="_min"></param>
        /// <returns></returns>
        public static double GetHourArc(int _hour, int _min)
        {
            if (_hour >= 12) // если перешли за 12 часов, то вычитаем 12, т.к. часов на часах 12
                _hour -= 12;

            return (_hour * 30 + _min / 2 - 90) * (Math.PI / 180); // вычисляем угл в радианах
        }
        /// <summary>
        /// метод для возврата угла для минутной стрелки в радианах
        /// </summary>
        /// <param name="_min"></param>
        /// <param name="_sec"></param>
        /// <returns></returns>
        public static double GetMinArc(int _min, int _sec)
        {
            return ((_min * 6 + _sec / 10 - 90) * (Math.PI / 180)); // вычисляем угл в радианах
        }
        /// <summary>
        /// метод для возврата угла для секундной стрелки в радианах
        /// </summary>
        /// <param name="_sec"></param>
        /// <returns></returns>
        public static double GetSecArc(int _sec)
        {
            return ((_sec * 6 - 90) * (Math.PI / 180)); // вычисляем угл в радианах
        }
    }
}
