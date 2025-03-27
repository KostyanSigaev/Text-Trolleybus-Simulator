using System.Text;
using System.Xml.Linq;

namespace TextTrollSim;

internal class Program {
    private static GameData gameData = new GameData();
    private static int trolleybusIndex, numberIndex, routeIndex, stopIndex;
    private static Random random = new Random();

    static void Main(string[] args) {
        //Console.OutputEncoding = Encoding.UTF8;
        //Console.InputEncoding = Encoding.UTF8;
        gameData = GameData.LoadFromXml("gamedata.xml");
        Console.Title = gameData.GameName;
        MainMenu();
    }

    private static void MainMenu() {
        string? select = string.Empty;
        Console.Clear();
        Console.Write($"{gameData.GameName}\n\n" +
            "Главное меню:\n" +
            "1. Начать игру\n" +
            "2. О проекте\n" +
            "3. Выход\n\n" +
            "Ваш выбор: ");
        select = Console.ReadLine();
        switch(select) {
            case "1": SetGameParameters(); break;
            case "2":
                Console.Clear();
                Console.WriteLine($"{gameData.GameName}\n\n" +
                    $"Автор основной игры: Костян Сигаев\n" +
                    $"Автор адаптации: {gameData.Author}\n" +
                    $"Нажмите любую кнопку, чтобы вернуться в главное меню...");
                Console.ReadKey();
                MainMenu();
                break;
            case "3": Environment.Exit(0); break;
            default: SetGameParameters(); break;
        }
    }

#pragma warning disable CS8604
#pragma warning disable CS8602
    private static void SetGameParameters() {
        Console.Clear();
        Console.WriteLine("Для начала выберите троллейбус из списка:");
        for(int i = 0; i < gameData.Trolleybuses.Count; i++) Console.WriteLine($"{i + 1}) {gameData.Trolleybuses[i].Model}");

        string? playerInput = string.Empty;
        Console.Write("Ваш выбор: ");
        playerInput = Console.ReadLine();
        if(!int.TryParse(playerInput, out trolleybusIndex)) trolleybusIndex = random.Next(0, gameData.Trolleybuses.Count - 1);
        else {
            if(int.Parse(playerInput) >= gameData.Trolleybuses.Count) trolleybusIndex = gameData.Trolleybuses.Count - 1;
            else trolleybusIndex = int.Parse(playerInput) - 1;
        }

        Console.WriteLine($"\nВы выбрали {gameData.Trolleybuses[trolleybusIndex].Model}, теперь выберите бортовой номер:");
        for(int i = 0; i < gameData.Trolleybuses[trolleybusIndex].Numbers.Length; i++) Console.WriteLine($"{i + 1}) {gameData.Trolleybuses[trolleybusIndex].Numbers[i]}");

        Console.Write($"Ваш выбор: ");
        playerInput = string.Empty;
        playerInput = Console.ReadLine();
        if(!int.TryParse(playerInput, out numberIndex)) numberIndex = random.Next(0, gameData.Trolleybuses[trolleybusIndex].Numbers.Length - 1);
        else {
            if(int.Parse(playerInput) >= gameData.Trolleybuses[trolleybusIndex].Numbers.Length) numberIndex = gameData.Trolleybuses[trolleybusIndex].Numbers.Length - 1;
            else numberIndex = int.Parse(playerInput) - 1;
        }

        Console.WriteLine($"\nВы выбрали {gameData.Trolleybuses[trolleybusIndex].Model} c номером {gameData.Trolleybuses[trolleybusIndex].Numbers[numberIndex]}, теперь выберите маршрут:");
        for(int i = 0; i < gameData.Routes.Count; i++) Console.WriteLine($"{i + 1}) Маршрут №{gameData.Routes[i].Name}: {gameData.Routes[i].Stops.Count} остановок");

        Console.Write($"Ваш выбор: ");
        playerInput = string.Empty;
        playerInput = Console.ReadLine();
        if(!int.TryParse(playerInput, out routeIndex)) routeIndex = random.Next(0, gameData.Routes.Count - 1);
        else {
            if(int.Parse(playerInput) >= gameData.Routes.Count) routeIndex = gameData.Routes.Count - 1;
            else routeIndex = int.Parse(playerInput) - 1;
        }

        Console.WriteLine($"\nВыбранные вами параметры: Троллейбус {gameData.Trolleybuses[trolleybusIndex].Model} номер {gameData.Trolleybuses[trolleybusIndex].Numbers[numberIndex]}, маршрут №{gameData.Routes[routeIndex].Name}");
        Console.Write("Вы согласны? [Да | Нет]: ");
        playerInput = Console.ReadLine();
        playerInput = playerInput.ToLower();

        switch(playerInput) {
            case "да": Game(); break;
            case "нет": SetGameParameters(); break;
            default: Game(); break;
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
            Console.WriteLine($"Остановка: {gameData.Routes[routeIndex].Stops[stopIndex]}\n" + $"Количество пассажиров внутри: {passengersInside}");

            if(stopIndex + 1 >= gameData.Routes[routeIndex].Stops.Count) {
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
                    case "2": canRide = true; break;
                    case "3": canRide = true; isRunning = false; continue;
                    default: canRide = true; break;
                }
            }

            if(isRunning) {
                Console.WriteLine("\nТроллейбус отправился. Прогресс:");
                Console.Write("[]");
                for(int i = 0; i < 30; i++) {
                    Console.Write(">");
                    System.Threading.Thread.Sleep(100);
                }

                Console.Write("[]");
                Console.WriteLine("\nТроллейбус подъехал к следующей остановке:\n");
                System.Threading.Thread.Sleep(1000);
            }

            stopIndex++;
        }

        Console.WriteLine($"\nТроллейбус закончил движение по маршруту {gameData.Routes[routeIndex].Name}:\n" +
            $"Всего перевезено пассажиров: {passengers}\n" +
            $"Нажмите любую кнопку чтобы продолжить...");
        Console.ReadKey();
        MainMenu();
    }
}

public class GameData {
    public string GameName { get; set; } = "";
    public string Author { get; set; } = "";
    public List<Trolleybus> Trolleybuses { get; set; } = new List<Trolleybus>();
    public List<Route> Routes { get; set; } = new List<Route>();

    public static GameData LoadFromXml(string filePath) {
        if(!File.Exists(filePath)) throw new FileNotFoundException("XML файл не найден", filePath);

        XDocument doc = XDocument.Load(filePath);
        XElement? root = doc.Element("TextTrollSim");
        if(root == null) throw new Exception("Некорректный XML-файл");

        GameData gameData = new GameData {
            GameName = root.Element("GameName") != null ? root.Element("GameName")!.Value : "Без названия",
            Author = root.Element("Author") != null ? root.Element("Author")!.Value : "Неизвестный автор"
        };

        XElement? trolleysElement = root.Element("Trolleybuses");
        if(trolleysElement != null) {
            foreach(XElement t in trolleysElement.Elements("Trolleybus")) {
                string model = t.Attribute("model")?.Value ?? "Неизвестная модель";
                string Numbers = t.Attribute("numbers")?.Value ?? "";
                gameData.Trolleybuses.Add(new Trolleybus(model, Numbers.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)));
            }
        }

        XElement? routesElement = root.Element("Routes");
        if(routesElement != null) {
            foreach(XElement r in routesElement.Elements("Route")) {
                string name = r.Attribute("name")?.Value ?? "Без имени";
                List<string> Stops = r.Elements("Stop").Select(s => s.Value).ToList();
                gameData.Routes.Add(new Route(name, Stops));
            }
        }

        return gameData;
    }
}

public class Trolleybus {
    public string Model { get; set; }
    public string[] Numbers { get; set; }

    public Trolleybus(string model, string[] Numbers) {
        this.Model = model;
        this.Numbers = Numbers;
    }
}

public class Route {
    public string Name { get; set; }
    public List<string> Stops { get; set; }

    public Route(string name, List<string> Stops) {
        this.Name = name;
        this.Stops = Stops;
    }
}
