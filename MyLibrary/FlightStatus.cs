namespace MyLibrary
{
    // Перечисление статусов полета пассажирского самолета
    public enum FlightStatus
    {
        // Статус не задан
        NONE,
        // Отменен
        CANCELED,
        // Еще не взлетел
        DID_NOT_TAKE_OFF,
        // Ожидание посадки
        WAITING_FOR_BOARDING,
        // В пути
        ON_THE_WAY,
        // Приземлился
        ARRIVED,
    }
}
