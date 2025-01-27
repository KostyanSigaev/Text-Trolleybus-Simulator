using System.Text;

namespace TextTrollSim;

internal class Program {
    //////////////////////////////////////////////////////
    // 
    // Здесь перечисляются все модели троллейбусов и их бортовые номера
    // Если вы хотите изменить троллейбусы игры, то указывайте их здесь
    // как показано при примере имеющихся
    // 
    //////////////////////////////////////////////////////
    private static Trolleybus[] trolleybuses = new Trolleybus[] {
        new Trolleybus("ЗиУ-5Д", new string[] {"0100", "0102", "0103", "0105", "0107", "0110", "0113", "0114"}),
        new Trolleybus("ЗиУ-682Б", new string[] {"0115", "0116", "0117", "0118", "0119", "0120", "0121", "0122", "0123", "0124"}),
        new Trolleybus("ЗиУ-682В", new string[] {"0144", "0146", "0171", "0172", "0173", "0180", "0181", "0187"}),
        new Trolleybus("ЗиУ-682Г", new string[] {"0142", "0145", "0166", "0182"}),
        new Trolleybus("ЮМЗ-Т1", new string[] {"0188", "0189", "0190", "0191", "0192", "0193", "0194"}),
        new Trolleybus("ЮМЗ-Т2", new string[] {"0192", "0196", "0197", "0198", "0199", "0200"}),
        new Trolleybus("Mercedes-Benz O405GTZ", new string[] {"0201", "0202"})
    };

    //////////////////////////////////////////////////////
    // 
    // Здесь перечисляются все доступные маршруты и их остановки
    // Если вам нужны другие маршруты и остановки - меняйте их здесь
    // как показано в примере
    // Здесь указывается название маршрута, краткое описание (пункт А - пункт Б)
    // и все остановки
    // 
    //////////////////////////////////////////////////////
    private static Route[] routes = new Route[] {
        new Route("1", "КТТУ - НКМЗ", new string[] {"КТТУ",
            "Актюбинская",
            "Завод \"Альфа\"",
            "ул. Нади Курченко",
            "ул. Парковая",
            "Школа",
            "ул. Дворцовая",
            "Стоматологическая",
            "19-го партсъезда",
            "Дом быта",
            "ул. Шкадинова",
            "Бульвар Машиностроителей",
            "НКМЗ",
            "Бульвар Машиностроителей",
            "ул. Шкадинова",
            "Дом быта",
            "19-го партсъезда",
            "Стоматологическая",
            "ул. Дворцовая",
            "Школа",
            "ул. Парковая",
            "ул. Нади Курченко",
            "Завод \"Альфа\"",
            "Актюбинская",
            "КТТУ"}),
        new Route("2", "КТТУ - ЭМСС", new string[] {"КТТУ",
            "ул. Остапа Вишни",
            "ул. Нади Курченко",
            "Бульвар Краматорский",
            "ул. Гвардейцев Кантемировцев",
            "ул. Юбилейная",
            "Дворец пионеров",
            "ул. Молодёжная",
            "ул. Дворцовая",
            "Поликлиника №3",
            "Детская поликлиника",
            "Рынок",
            "ДК Строителей",
            "ул. Маяковского",
            "КЖБ",
            "133 квартал (Станкострой)",
            "КЗТС",
            "ЭМСС",
            "КЗТС",
            "133 квартал (Станкострой)",
            "КЖБ",
            "ул. Маяковского",
            "ДК Строителей",
            "Рынок",
            "Совбез",
            "Поликлиника №3",
            "ул. Дворцовая",
            "ул. Молодёжная",
            "Дворец пионеров",
            "ул. Юбилейная",
            "ул. Гвардейцев Кантемировцев",
            "Бульвар Краматорский",
            "ул. Нади Курченко",
            "ул. Остапа Вишни",
            "КТТУ"}),
        new Route("2a", "КТТУ - Детская поликлиника", new string[] {"КТТУ",
            "ул. Остапа Вишни",
            "ул. Нади Курченко",
            "Бульвар Краматорский",
            "ул. Гвардейцев Кантемировцев",
            "ул. Юбилейная",
            "Дворец пионеров",
            "ул. Молодёжная",
            "ул. Дворцовая",
            "Поликлиника №3",
            "Детская поликлиника",
            "Совбез",
            "Поликлиника №3",
            "ул. Дворцовая",
            "ул. Молодёжная",
            "Дворец пионеров",
            "ул. Юбилейная",
            "ул. Гвардейцев Кантемировцев",
            "Бульвар Краматорский",
            "ул. Нади Курченко",
            "ул. Остапа Вишни",
            "КТТУ"}),
        new Route("3", "КТТУ - НКМЗ", new string[] {"КТТУ",
            "ул. Остапа Вишни",
            "ул. Нади Курченко",
            "Бульвар Краматорский",
            "ул. Гвардейцев Кантемировцев",
            "ул. Юбилейная",
            "Дворец пионеров",
            "ул. Молодёжная",
            "Автовокзал",
            "ул. Автотранспортная",
            "Проспект Мира",
            "Крматорская ТЭЦ",
            "НКМЗ",
            "Крматорская ТЭЦ",
            "Проспект Мира",
            "ул. Автотранспортная",
            "Автовокзал",
            "ул. Молодёжная",
            "Дворец пионеров",
            "ул. Юбилейная",
            "ул. Гвардейцев Кантемировцев",
            "Бульвар Краматорский",
            "ул. Нади Курченко",
            "ул. Остапа Вишни",
            "КТТУ"}),
        new Route("4", "КТТУ - НКМЗ", new string[] {"КТТУ",
            "ул. Остапа Вишни",
            "ул. Нади Курченко",
            "Бульвар Краматорский",
            "ул. Гвардейцев Кантемировцев",
            "ул. Юбилейная",
            "Дворец пионеров",
            "ул. Молодёжная",
            "ул. Дворцовая",
            "Поликлиника №3",
            "ул. Шкадинова",
            "Бульвар Машиностроителей",
            "НКМЗ",
            "Бульвар Машиностроителей",
            "ул. Шкадинова",
            "Поликлиника №3",
            "ул. Дворцовая",
            "ул. Молодёжная",
            "Дворец пионеров",
            "ул. Юбилейная",
            "ул. Гвардейцев Кантемировцев",
            "Бульвар Краматорский",
            "ул. Нади Курченко",
            "ул. Остапа Вишни",
            "КТТУ"})
    };

    private static int trolleybusIndex, numberIndex, routeIndex, stopIndex;
    private static Random random = new Random();

    static void Main(string[] args) {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.Title = "Симулятор Краматорского троллейбуса 1996"; // здесь можно поменять название игры
        MainMenu();
    }

    private static void MainMenu() {
        string? select = string.Empty;
        Console.Clear();
        Console.Write("Симулятор Краматорского троллейбуса 1996\n\n" + // здесь можно поменять название игры
            "Главное меню:\n" +
            "1. Начать игру\n" +
            "2. О проекте\n" +
            "3. Выход\n\n" +
            "Ваш выбор: ");
        select = Console.ReadLine();
        switch(select) {
            case "1":
                SetGameParameters();
                break;
            case "2":
                Console.Clear();
                Console.WriteLine($"Симулятор Краматорского троллейбуса 1996\n\n" + // это всё вы можете поменять как вам угодно
                    $"Автор: Костян Сигаев\n" +                                     // это всё вы можете поменять как вам угодно
                    $"Разработчик: Костян Сигаев\n" +                               // это всё вы можете поменять как вам угодно
                    $"Генеральный директор: Костян Сигаев\n" +                      // это всё вы можете поменять как вам угодно
                    $"Графический дизайнер: Костян Сигаев\n" +                      // это всё вы можете поменять как вам угодно
                    $"Звукорежиссёр: Костян Сигаев\n" +                             // это всё вы можете поменять как вам угодно
                    $"А также: Костян Сигаев\n" +                                   // это всё вы можете поменять как вам угодно
                    $"И Костян Сигаев в роли Костяна Сигаева\n\n" +                 // это всё вы можете поменять как вам угодно
                    $"Нажмите любую кнопку, чтобы вернуться в главное меню...");    // это всё вы можете поменять как вам угодно
                Console.ReadKey();
                MainMenu();
                break;
            case "3":
                Environment.Exit(0);
                break;
            default:
                SetGameParameters();
                break;
        }
    }

#pragma warning disable CS8604
#pragma warning disable CS8602
    private static void SetGameParameters() {
        Console.Clear();

        Console.WriteLine("Для начала выберите троллейбус из списка:");
        for(int i = 0; i < trolleybuses.Length; i++) {
            Console.WriteLine($"{i + 1}) {trolleybuses[i].trolleybusName}");
        }
        string? playerInput = string.Empty;
        Console.Write("Ваш выбор: ");
        playerInput = Console.ReadLine();
        if(!int.TryParse(playerInput, out trolleybusIndex)) {
            trolleybusIndex = random.Next(0, trolleybuses.Length - 1);
        } else {
            if(int.Parse(playerInput) >= trolleybuses.Length) trolleybusIndex = trolleybuses.Length - 1;
            else trolleybusIndex = int.Parse(playerInput) - 1;
        }

        Console.WriteLine($"\nВы выбрали {trolleybuses[trolleybusIndex].trolleybusName}, теперь выберите бортовой номер:");
        for(int i = 0; i < trolleybuses[trolleybusIndex].numbers.Length; i++) {
            Console.WriteLine($"{i + 1}) {trolleybuses[trolleybusIndex].numbers[i]}");
        }
        Console.Write($"Ваш выбор: ");
        playerInput = string.Empty;
        playerInput = Console.ReadLine();
        if(!int.TryParse(playerInput, out numberIndex)) {
            numberIndex = random.Next(0, trolleybuses[trolleybusIndex].numbers.Length - 1);
        } else {
            if(int.Parse(playerInput) >= trolleybuses[trolleybusIndex].numbers.Length) numberIndex = trolleybuses[trolleybusIndex].numbers.Length - 1;
            else numberIndex = int.Parse(playerInput) - 1;
        }

        Console.WriteLine($"\nВы выбрали {trolleybuses[trolleybusIndex].trolleybusName} c номером {trolleybuses[trolleybusIndex].numbers[numberIndex]}, теперь выберите маршрут:");
        for(int i = 0; i < routes.Length; i++) {
            Console.WriteLine($"{i + 1}) Маршрут №{routes[i].routeName}: {routes[i].description} ({routes[i].stops.Length} остановок)");
        }
        Console.Write($"Ваш выбор: ");
        playerInput = string.Empty;
        playerInput = Console.ReadLine();
        if(!int.TryParse(playerInput, out routeIndex)) {
            routeIndex = random.Next(0, routes.Length - 1);
        } else {
            if(int.Parse(playerInput) >= routes.Length) routeIndex = routes.Length - 1;
            else routeIndex = int.Parse(playerInput) - 1;
        }

        Console.WriteLine($"\nВыбранные вами параметры: Троллейбус {trolleybuses[trolleybusIndex].trolleybusName} номер {trolleybuses[trolleybusIndex].numbers[numberIndex]}, маршрут №{routes[routeIndex].routeName}");
        Console.Write("Вы согласны? [Да | Нет]: ");
        playerInput = Console.ReadLine();
        playerInput = playerInput.ToLower();

        switch(playerInput) {
            case "да":
                Game();
                break;
            case "нет":
                SetGameParameters();
                break;
            default:
                Game();
                break;
        }
    }
#pragma warning restore CS8602
#pragma warning restore CS8604

    private static void Game() {
        bool isRunning = true;
        int passengers = 0, passengersInside = 0;
        string? playerInput = string.Empty;

        Console.Clear();
        Console.WriteLine("Начало игры...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Троллейбус готовится...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Троллейбус выехал из депо...");
        System.Threading.Thread.Sleep(1000);
        Console.WriteLine("Троллейбус подъехал к первой остановке...\n");
        System.Threading.Thread.Sleep(1000);

        while(isRunning) {
            bool canRide = false;
            Console.WriteLine($"Остановка: {routes[routeIndex].stops[stopIndex]}\n" +
                $"Количество пассажиров внутри: {passengersInside}");

            if(stopIndex + 1 >= routes[routeIndex].stops.Length) {
                isRunning = false;
                continue;
            }
            while(!canRide) {
                Console.WriteLine($"Выберите действие:\n" +
                $"1. Впустить/выпустить пассажиров\n" +
                $"2. Отправиться на следующую остановку\n" +
                $"3. Закончить рейс");
                Console.Write($"Ваш выбор: ");
                playerInput = Console.ReadLine();
                switch(playerInput) {
                    case "1":
                        Console.WriteLine("\nДвери открываются...");
                        System.Threading.Thread.Sleep(1000);
                        Console.Write("Пассажиры выходят и заходят");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".");
                        System.Threading.Thread.Sleep(500);
                        Console.Write(".\n");
                        System.Threading.Thread.Sleep(1000);
                        Console.WriteLine("Двери закрываются...");
                        System.Threading.Thread.Sleep(1000);
                        int toExit, toEnter;
                        toExit = random.Next(0, passengersInside);
                        toEnter = random.Next(0, 10);
                        if(passengersInside <= 0) toExit = 0;
                        Console.WriteLine($"Пассажиров вышло: {toExit}, зашло: {toEnter}\n");
                        passengersInside -= toExit;
                        passengersInside += toEnter;
                        passengers += toEnter;
                        System.Threading.Thread.Sleep(1000);
                        break;
                    case "2":
                        canRide = true;
                        break;
                    case "3":
                        canRide = true;
                        isRunning = false;
                        continue;
                    default:
                        canRide = true;
                        break;
                }
            }

            if(isRunning) {
                Console.WriteLine("\nТроллейбус отправился. Прогресс:");
                Console.Write("[]");
                for(int i = 0; i < 30; i++)
                {
                    Console.Write(">");
                    System.Threading.Thread.Sleep(100);
                }
                Console.Write("[]");
                Console.WriteLine("\nТроллейбус подъехал к следующей остановке:\n");
                System.Threading.Thread.Sleep(1000);
            }

            stopIndex++;
        }

        Console.WriteLine($"\nТроллейбус закончил движение по маршруту {routes[routeIndex].routeName}:\n" +
            $"Всего перевезено пассажиров: {passengers}\n" +
            $"Нажмите любую кнопку чтобы продолжить...");
        Console.ReadKey();
        MainMenu();
    }
}

public class Trolleybus {
    public string trolleybusName;
    public string[] numbers;

    public Trolleybus(string trolleybusName, string[] numbers) {
        this.trolleybusName = trolleybusName;
        this.numbers = numbers;
    }
}

public class Route {
    public string routeName, description;
    public string[] stops;

    public Route(string routeName, string description, string[] stops) {
        this.routeName = routeName;
        this.description = description;
        this.stops = stops;
    }
}
