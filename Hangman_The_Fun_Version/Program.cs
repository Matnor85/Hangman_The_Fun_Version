namespace Hangman_The_Fun_Version;

internal class Program
{
    // Här är den aktuella spelaren
    public static Player? _player;
    static void Main(string[] args)
    {
        // Skriver ut Hangman logan
        Logotype.Logotyp();
        ConsoleHelper.CenterAll(Language.Get("Press"));

        // Stänger jag av markören i konsolen för att få mer spel liknande upplevelse
        Console.CursorVisible = false;
        Console.ReadKey(true);

        // Här skapas en ny spelare
        _player = CreatePlayer();

        //Skapa en ny instans av Menu för att komma åt den efter som,
        //Menu klassen och dens klasser inte är statiska
        Menu menu = new Menu();

        // Här startas huvudmenyn
        menu.StartMenu();
    }
    // Här är metoden som skapar spelaren
    static Player CreatePlayer()
    {
        string input;
        do
        {
            Console.Clear();

            // Här ber vi spelaren om sitt namn
            ConsoleHelper.CenterAll(Language.Get("AskForName") + "\n" + Language.Get("SetName"));

            // Sätter jag markören där jag vill ha den.
            ConsoleHelper.SetCursor(0, 3);

            // Sätter jag på markören
            Console.CursorVisible = true;

            input = Console.ReadLine()!;

            // Stänger jag av markören igen.
            Console.CursorVisible = false;

            // Här kollar vi att spelaren namn inte är kortare än två bokstäver.
        } while (string.IsNullOrEmpty(input) || input.Length < 2);

        // Här returnerar vi det som spelaren skrev in om det uppfyller vilkoret innan
        return new Player(input);
    }
}
