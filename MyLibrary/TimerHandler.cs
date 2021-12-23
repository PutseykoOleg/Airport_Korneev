using System;
using System.Windows.Forms;

namespace MyLibrary
{
    /**
     * Класс, представляющий обработчик таймера
     * 
     * Нужен для циклического вызова какого-либо метода
     */
    public static class TimerHandler
    {
        // Обрабатываемый таймер с периодичностью вызова 100 миллисекунд
        private static Timer _timer = new Timer { Interval = 100 };

        /**
         * Событие, которое принимает в качестве обработчика метод, который необходимо вызывать циклически с заданной периодичностью
         * 
         * Пример:
         * 
           public void WriteString() {
               Console.WriteLine("Some string");
           }

           TimerHandler.MakeItUpdatable += WriteString;
         * 
         * В результате будет выводиться строка "Some string" каждые 100 миллисекунд
         */
        public static event EventHandler MakeItUpdatable;

        // Конструктор класса
        static TimerHandler()
        {
            // Добавление пользовательского обработчика события Tick
            _timer.Tick += Tick;
            // Запуск таймера
            _timer.Start();
        }

        /**
         * Пользовательский обработчик события Tick
         * 
         * Должен иметь те же параметры (sender и e), что и в обработчике Tick класса Timer
         */
        private static void Tick(object sender, EventArgs e)
        {
            // Вызов "переданного" метода
            MakeItUpdatable?.Invoke(sender, e);
        }

        // Метод, останавливающий работу таймера, т.е. завершающий цикл вызовов
        public static void Stop()
        {
            _timer.Stop();
        }
    }
}
