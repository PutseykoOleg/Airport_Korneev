using System;

namespace MyLibrary
{
    // Класс, описывающий пассажирский самолет
    public class PassengerPlane: Airplane
    {
        // Приватное поле для хранения статуса полета (изначально - статус NONE)
        private FlightStatus _flightStatus = FlightStatus.NONE;
        // Публичное поле (свойство) для обработки статуса полета
        public FlightStatus flightStatus {
            // Метод, вызывающийся при обращении к данному свойству
            get
            {
                /**
                 * Если статус не "Отменен"
                 * 
                 * Эта проверка необходима, т.к. обращение к данному свойству происходит циклично каждые 100 миллисекунд.
                 * А вместе с тем заново проходятся все эти проверки и устанавливается новое значение. Все статусы, помимо NONE и
                 * CANCELED взаимосвязаны, поэтому смена одного из них другим вполне ожидаема. А вот если во время этой смены на некоторое
                 * время установится статус CANCELED будет неверная логическая последовательность.
                 * 
                 * Т.о. статус CANCELED может установиться только изначально, когда текущий статус - NONE. И если он установился, то
                 * больше не поменяется.
                 */
                if (_flightStatus != FlightStatus.CANCELED)
                {
                    Random rand = new Random();

                    // Если статусы ранее не были установлены, то установить и вернуть статус CANCEL с вероятностью 10%
                    if (_flightStatus == FlightStatus.NONE && rand.Next(0, 100) < 10)
                    {
                        return _flightStatus = FlightStatus.CANCELED;
                    }

                    // Время начала посадки
                    DateTime boardingTime = flight.departureDateTime;
                    boardingTime.AddMinutes(-40);

                    // Если посадка еще не началась
                    if (DateTime.Now < boardingTime)
                    {
                        // Установить и вернуть статус "Еще не взлетел"
                        return _flightStatus = FlightStatus.DID_NOT_TAKE_OFF;
                    }

                    // Если сейчас время посадки
                    if (DateTime.Now >= boardingTime && DateTime.Now < flight.departureDateTime)
                    {
                        // Установить и вернуть статус "Ожидание посадки"
                        return _flightStatus = FlightStatus.WAITING_FOR_BOARDING;
                    }

                    // Время прилета
                    DateTime landingTime = flight.departureDateTime;
                    landingTime.AddMinutes(flight.travelTime * 60);

                    // Если самолет уже взлетел, но еще не прилетел
                    if (DateTime.Now >= flight.departureDateTime && DateTime.Now < landingTime)
                    {
                        // Установить и вернуть статус "В пути"
                        return _flightStatus = FlightStatus.ON_THE_WAY;
                    }

                    // Если самолет уже прилетел, установить и вернуть статус "Приземлился"
                    return _flightStatus = FlightStatus.ARRIVED;
                }

                // Вернуть статус "Отменен"
                return _flightStatus;
            }
        }

        // Конструктор класса
        public PassengerPlane()
        {
            // Установка значений по умолчанию
            airlineName = "";
            flight = new Flight(number: -1, route: new Route("", ""), departureDateTime: default, price: 0f, travelTime: 0f);
        }

        /**
         * Конструктор класса с параметрами
         * 
         * airlineName - название авиакомпании
         * flight - экземпляр класса "Рейс"
         */
        public PassengerPlane(string airlineName, Flight flight)
        {
            this.airlineName = airlineName;
            this.flight = flight;
        }
    }
}
