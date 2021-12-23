using System;

namespace MyLibrary
{
    // Класс, описывающий рейс
    public struct Flight
    {
        // Приватное поле, хранящее время полета в часах
        private double _travelTime;
        // Публичное поле (свойство), через которое происходит обработка приватного
        public double travelTime { 
            /**
             * Метод, вызывающийся при обращении к свойству
             * 
             * Переводит число вида 8,2342347 в 823, где 8 - часы, а 23 - неполный час (проценты от него, после будут переводиться в минуты)
             */
            get => Math.Truncate(_travelTime * 100); 
            // Метод, вызывающийся при установлении значения свойству
            private set => _travelTime = value; 
        }
        // Номер рейса
        public int number { get; private set; }
        // Маршрут
        public Route route { get; private set; }
        // Дата и время вылета
        public DateTime departureDateTime { get; private set; }
        // Стоимость полета
        public float price { get; private set; }

        public Flight(int number, Route route, DateTime departureDateTime, float price, double travelTime)
        {
            // Далее перезапишется на travelTime, но инициализация нужна, т.к. в этой версии C# в конструкторе должны инициализироваться все поля
            this._travelTime = 0;

            this.number = number;
            this.route = route;
            this.departureDateTime = departureDateTime;
            this.price = price;
            this.travelTime = travelTime;
        }
    }
}
