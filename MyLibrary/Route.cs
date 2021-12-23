namespace MyLibrary
{
    // Структура, описывающая маршрут
    public struct Route
    {
        // Начальная точка маршрута
        public string from { get; private set; }
        // Конечная точка маршрута
        public string to { get; private set; }

        public Route(string from, string to)
        {
            this.from = from;
            this.to = to;
        }
    }
}
