namespace Airport_Korneev
{
    /**
     * Абстрактный класс, описывающий некоторый самолет
     * 
     * В данной программе описан только один наследник этого класса - пассажирский самолет, т.к. по заданию 
     * взаимодействие происходит только с таким типом самолетов.
     */
    public abstract class Airplane
    {
        // Название авиакомпании
        public string airlineName { get; protected set; }
        // Рейс
        public Flight flight { get; protected set; }
    }
}
