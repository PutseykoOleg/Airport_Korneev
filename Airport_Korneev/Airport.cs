using System;
using System.Collections.Generic;

namespace Airport_Korneev
{
    // Интерфейс, описывающий объект, предоставляющий некоторую информацию, связанную с самолетом
    public interface IInformable
    {
        // Метод, возвращающий некоторую информацию в виде пар "название - значение"
        Dictionary<string, string> GetAirplaneInfo(int flightNumber);
    }

    // Класс, описывающий аэропорт
    public class Airport: IInformable
    {
        // Список самолетов
        public List<PassengerPlane> airplanes { get; private set; } = new List<PassengerPlane>();

        // Конструктор класса
        public Airport() { }
        // Конструктор класса с параметрами
        public Airport(List<PassengerPlane> airplanes)
        {
            this.airplanes = airplanes;
        }

        // Метод, возвращающий информацию о самолете с заданным номером рейса
        public Dictionary<string, string> GetAirplaneInfo(int flightNumber)
        {
            // Найденный самолет
            Airplane foundAirplane = new PassengerPlane();
            // Значение, определяющее найден ли самолет
            bool isFound = false;

            // Для каждого самолета из списка
            foreach (PassengerPlane airplane in airplanes)
            {
                // Если номер его рейса равен заданному
                if(airplane.flight.number == flightNumber)
                {
                    // Инициализировать найденный самолет
                    foundAirplane = airplane;
                    // Отметить, что самолет найден
                    isFound = true;
                    // Выйти из цикла
                    break;
                }
            }

            // Подстчет времени в пути (определение часов и минут)
            int travelTimeHours = (int)(foundAirplane.flight.travelTime / 100);
            int travelTimeMinutes = (int)((foundAirplane.flight.travelTime % 100) * 0.6);

            return isFound
                // Если самолет найден, то вернуть полную информацию о нем
                ? new Dictionary<string, string>()
                {
                    { "Название авиакомпании", foundAirplane.airlineName },
                    { "Номер рейса", foundAirplane.flight.number.ToString() },
                    { "Пункт вылета", foundAirplane.flight.route.from },
                    { "Пункт назначения", foundAirplane.flight.route.to },
                    { "Дата и время вылета", foundAirplane.flight.departureDateTime.ToString() },
                    { "Время в пути", $"{(travelTimeHours < 10 ? "0" : "") + travelTimeHours}:{(travelTimeMinutes < 10 ? "0" : "") + travelTimeMinutes}" },
                    { "Стоимость полета", $"{foundAirplane.flight.price} ₽" },
                }
                // Если нет, то вернуть пустой словарь
                : new Dictionary<string, string>();
        }
    }
}
