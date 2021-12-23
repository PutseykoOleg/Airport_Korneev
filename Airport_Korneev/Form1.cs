using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLibrary;

namespace Flight_Schedule_App
{

    public partial class Form1 : Form
    {
        // Количество самолетов в аэропорту
        public const int COUNT_OF_AIRPLANES = 10;

        // Аэропорт
        public Airport airport = new Airport();

        public Form1()
        {
            InitializeComponent();
        }

        // Метод, вызывающийся при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация таблицы
            InitializeTable();
            // Инициализация списка самолетов
            InitializeAirplaneList();
        }

        // Метод, инициализирующий таблицу
        private void InitializeTable()
        {
            // Добавление столбцов
            table.Columns.Add("id", "№");
            table.Columns.Add("airlineName", "Авиакомпания");
            table.Columns.Add("number", "Рейс");
            table.Columns.Add("routeTo", "Пункт назачения");
            table.Columns.Add("departureDateTime", "Время отправления");
            table.Columns.Add("status", "Статус");

            // Данные в таблице - только для чтения
            table.ReadOnly = true;
            // Автозаполнение всей ширины таблицы
            table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // Убрать строку, которая отображается последней и позволяет вставить новые данные в таблицу
            table.AllowUserToAddRows = false;
            // Убрать возможность одновременного выбора нескольких строк
            table.MultiSelect = false;

            // Сделать все столбцы несортируемыми
            for(int i = 0; i < table.Columns.Count; i++)
            {
                table.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        // Метод, инициализирующий список самолетов
        private void InitializeAirplaneList()
        {
            // Очистить список, чтобы при случайном вызове метода не продублировались его значения
            airport.airplanes.Clear();

            Random rand = new Random();

            // Начальные и конечные пункты маршрута соответственно
            List<string> routesFrom = new List<string>() { "Москва" };
            List<string> routesTo = new List<string>() { "Владивосток", "Обихиро", "Эр-Рияд" };

            for (int i = 0; i < COUNT_OF_AIRPLANES; i++)
            {
                // Добавить в список новый самолет
                airport.airplanes.Add(new PassengerPlane(
                    // Определение авиакомпании с вероятностью 50%
                    airlineName: rand.Next(0, 100) < 50 ? "Аэрофлот" : "Россия",
                    // Рейс
                    flight: new Flight(
                        // Номер рейса находится в пределах от 1000 до 9999
                        number: rand.Next(1000, 10000),
                        // Маршрут
                        route: new Route(
                            // Рандомный начальная точка
                            from: routesFrom[rand.Next(0, routesFrom.Count)], 
                            // Рандомная конечная точка
                            to: routesTo[rand.Next(0, routesTo.Count)]
                        ),
                        // Время вылета в промежутке "3 дня назад - 3 дня вперед" относительно текущей даты
                        departureDateTime: DateTime.Now.AddHours(rand.Next(-72, 72)),
                        // Стоимость полета, кратная 1000
                        price: rand.Next(5, 150) * 1000,
                        // Время в полете 1-8 полных часов и 0-1 неполный (минуты)
                        travelTime: rand.Next(1, 9) + rand.NextDouble()
                    )
                ));

                // Добавить информацию о самолете в таблицу
                AddAirplaneToTable(airport.airplanes[airport.airplanes.Count - 1]);
            }
        }

        // Метод, добавляющий информацию о самолете в таблицу
        private void AddAirplaneToTable(PassengerPlane airplane)
        {
            // Словарь пар "статус полета - отображаемое значение"
            Dictionary<FlightStatus, string> statuses = new Dictionary<FlightStatus, string>()
            {
                { FlightStatus.DID_NOT_TAKE_OFF, "До рейса :Days::Hours::Minutes::Seconds" },
                { FlightStatus.WAITING_FOR_BOARDING, "Ожидание посадки" },
                { FlightStatus.ON_THE_WAY, "В пути" },
                { FlightStatus.ARRIVED, "Приземлился" },
                { FlightStatus.CANCELED, "Отменен" },
            };

            // Создание строки и получение ее индекса
            int index = table.Rows.Add();

            // Вынесение строки в отдельную переменную для удобства
            DataGridViewRow row = table.Rows[index];

            // Инициализация каждой из ячеек строки
            row.Cells["id"].Value = index + 1;
            row.Cells["airlineName"].Value = airplane.airlineName;
            row.Cells["number"].Value = airplane.flight.number;
            row.Cells["routeTo"].Value = airplane.flight.route.to;
            row.Cells["departureDateTime"].Value = airplane.flight.departureDateTime;
            // Обновление значения ячейки каждые 100 миллисекунд
            TimerHandler.MakeItUpdatable += (s, e) => 
                row.Cells["status"].Value = airplane.flightStatus != FlightStatus.DID_NOT_TAKE_OFF
                    // Если отображаемое значение статуса не содержит каких-либо параметров, то отобразить его
                    ? statuses[airplane.flightStatus]
                    // Если содержит, то заменить каждый
                    : statuses[airplane.flightStatus]
                        // Замена параметра ":Days" на количество дней между текущей датой и датой отправления
                        .Replace(":Days", (airplane.flight.departureDateTime.AddTicks(-DateTime.Now.Ticks).Day - 1).ToString())
                        .Replace(":Hours", airplane.flight.departureDateTime.AddTicks(-DateTime.Now.Ticks).Hour.ToString())
                        .Replace(":Minutes", airplane.flight.departureDateTime.AddTicks(-DateTime.Now.Ticks).Minute.ToString())
                        .Replace(":Seconds", airplane.flight.departureDateTime.AddTicks(-DateTime.Now.Ticks).Second.ToString());
        }

        // Метод, вызывающийся при изменении выбора строки таблицы
        private void table_SelectionChanged(object sender, EventArgs e)
        {
            // Если выбрана, то включить кнопку "Подробнее"
            moreButton.Enabled = table.SelectedRows.Count > 0;
        }

        // Метод, вызывающийся при нажатии кнопки "Подробнее"
        private void moreButton_Click(object sender, EventArgs e)
        {
            // Выбранный самолет
            PassengerPlane selectedAirplane = airport.airplanes[table.SelectedRows[0].Index];
            // Получение информации о нем
            Dictionary<string, string> structuredInfo = airport.GetAirplaneInfo(selectedAirplane.flight.number);

            string info = "";

            // Представление информации в виде сплошного текста с неколькими строками
            foreach(KeyValuePair<string, string> line in structuredInfo)
            {
                info += line.Key + ": " + line.Value + "\n";
            }

            // Вывод информации в диалоговое окно
            MessageBox.Show(info, $"Информация по рейсу №{selectedAirplane.flight.number}");
        }

        // Метод, вызывающийся при изменении значения поля ввода номера рейса
        private void flightNumberInput_TextChanged(object sender, EventArgs e)
        {
            // Фильтрация строк таблицы
            FilterTable();
        }

        // Метод, вызывающийся при изменении значения поля ввода названия авиакомпании
        private void airlineInput_TextChanged(object sender, EventArgs e)
        {
            // Фильтрация строк таблицы
            FilterTable();
        }

        // Метод, вызывающийся при изменении значения даты
        private void dateInput_ValueChanged(object sender, EventArgs e)
        {
            // Фильтрация строк таблицы
            FilterTable();
        }

        // Метод, выполняющий фильтрацию строк таблицы
        private void FilterTable()
        {
            // Фильтры
            string flightNumber = flightNumberInput.Text;
            string airlineName = airlineInput.Text;
            DateTime date = dateInput.Value;

            // Для каждой строки
            for(int i = 0; i < airport.airplanes.Count; i++)
            {
                // Самолет, относящийся к данной строке
                PassengerPlane airplane = airport.airplanes[i];
                // Значение, определяющее видимость строки
                bool isVisible = true;

                // Если поле ввода номера рейса не пустое
                if (flightNumber != "")
                {
                    // Если номер рейса текущего самолета и фильра совпадают, то оставить строку видимой до следующего фильтра
                    isVisible &= airplane.flight.number.ToString() != flightNumber ? false : true;
                }

                // Если поле ввода названия авиакомпании не пустое
                if (airlineName != "")
                {
                    // Если название авиакомпании текущего самолета и фильра совпадают, то скорректировать видимость строки
                    isVisible &= airplane.airlineName != airlineName ? false : true;
                }

                // Если поле ввода даты не пустое
                if (date != default)
                {
                    // Если дата вылета текущего самолета больше либо равна даты фильтра, то скорректировать видимость строки
                    isVisible &= airplane.flight.departureDateTime < date ? false : true;
                }

                // Установить видимость строки
                table.Rows[i].Visible = isVisible;
                // Снять выбор строки
                table.Rows[i].Selected = false;
            }
        }
    }
}
