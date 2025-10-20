namespace Hangman_The_Fun_Version;
internal class Menu
{
    // Lösenordet för att töma high score listan. Använder en const string,
    // För man inte ska kunna ändra lösenordet.
    private const string HighScorePassword = "admin123";

    // I varje meny anropar jag olika metoder för att få en mer lättläst kod.
    public void StartMenu()
    {
        bool run = true;
        while (run)
        {
            // Skapar jag en sting array för att kunna skriva ut det centrerat i konsolen.
            // Och justerar raderna i sidled med hjälp av PadRight(10) för jämnare placering.
            string[] menuLines = new string[]
            {
                "-----HANGMAN-----",
                "",
                "[1] - " + Language.Get("Play").PadRight(10),
                "[2] - " + Language.Get("ShowHighScore").PadRight(10),
                "[3] - " + Language.Get("Language").PadRight(10),
                "[4] - " + Language.Get("Exit").PadRight(10)
            };
            Console.Clear();
            // Här skriver jag ut det centrerat i konsolen.
            ConsoleHelper.CenterMenu(menuLines);

            // Gör ett menyval utan att trycka på Enter
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    // Använder jag för att få ett litet beep vid meny valet.
                    ConsoleHelper.Sound();
                    PlayMenu();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    ShowHighScore();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleHelper.Sound();
                    ChangeLanguage();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ConsoleHelper.Sound();
                    Exit();
                    break;
                // Ifall man skulle råka trycka på något annat än det som finns som meny val.
                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-4"));
                    // Detta ger spelaren lite tid att läsa felmeddelandet innan man hoppar tillbaka till meny sidan man var på.
                    Thread.Sleep(1300);
                    break;
            }
        }
    }

    // Metoden som avslutar spelet.
    static void Exit()
    {
        bool run = true;
        while (run)
        {
            string[] exitLines = new string[]
            {
                "-----"+Language.Get("Exit")+"-----",
                "",
                Language.Get("AreYouSure"),
                "[1] - " + Language.Get("Yes").PadRight(5),
                "[2] - " + Language.Get("No").PadRight(5)
            };
            Console.Clear();
            ConsoleHelper.CenterMenu(exitLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("ExitMessage"));
                    Console.ReadKey(true);
                    Console.Clear();
                    Environment.Exit(0);
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    return;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-2"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }

    // Menyn där man väljer svårighetsgrad.
    private void PlayMenu()
    {
        bool run = true;

        while (run)
        {
            string[] soloLines = new string[]
            {
            "-----" + Language.Get("Play") + "-----",
            "",
            "[1] - " + Language.Get("Easy").PadRight(10),
            "[2] - " + Language.Get("Normal").PadRight(10),
            "[3] - " + Language.Get("Hard").PadRight(10),
            "[4] - " + Language.Get("Back").PadRight(10)
        };
            Console.Clear();
            ConsoleHelper.CenterMenu(soloLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();
                    Easy();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    Normal();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleHelper.Sound();
                    Hard();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ConsoleHelper.Sound();
                    run = false;
                    break;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-4"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }
    // Inom denna så sätter vi först kategori och sedan svårighetsgrad Easy och startar sedan spelet.
    private void Easy()
    {
        bool run = true;
        // Här skapar jag en instans av Game.
        Game game = new Game(Program._player!);

        while (run)
        {
            string[] easyLines = new string[]
            {
            "-----" + Language.Get("Category") + "-----",
            "",
            "[1] - " + Language.Get("Animals").PadRight(10),
            "[2] - " + Language.Get("Fruits").PadRight(10),
            "[3] - " + Language.Get("Cities").PadRight(10),
            "[4] - " + Language.Get("Back").PadRight(10)
        };
            Console.Clear();
            ConsoleHelper.CenterMenu(easyLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();
                    game.SetCategory("Animals");
                    game.SetToEasy();
                    game.GameOn();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    game.SetCategory("Fruits");
                    game.SetToEasy();
                    game.GameOn();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleHelper.Sound();
                    game.SetCategory("Cities");
                    game.SetToEasy();
                    game.GameOn();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ConsoleHelper.Sound();
                    run = false;
                    break;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-4"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }
    // Inom denna så sätter vi först kategori och sedan svårighetsgrad Normal och startar sedan spelet.
    private void Normal()
    {
        bool run = true;
        // skapar jag en instans av Game
        Game game = new Game(Program._player!);

        while (run)
        {
            string[] normalLines = new string[]
            {
            "-----" + Language.Get("Category") + "-----",
            "",
            "[1] - " + Language.Get("Animals").PadRight(10),
            "[2] - " + Language.Get("Fruits").PadRight(10),
            "[3] - " + Language.Get("Cities").PadRight(10),
            "[4] - " + Language.Get("Back").PadRight(10)
        };
            Console.Clear();
            ConsoleHelper.CenterMenu(normalLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();
                    game.SetCategory("Animals");
                    game.SetToNormal();
                    game.GameOn();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    game.SetCategory("Fruits");
                    game.SetToNormal();
                    game.GameOn();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleHelper.Sound();
                    game.SetCategory("Cities");
                    game.SetToNormal();
                    game.GameOn();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ConsoleHelper.Sound();
                    run = false;
                    break;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-4"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }
    // Inom denna så sätter vi först kategori och sedan svårighetsgrad Hard och startar sedan spelet.
    private void Hard()
    {
        bool run = true;
        // Skapar jag en instans av Game.
        Game game = new Game(Program._player!);

        while (run)
        {
            string[] hardLines = new string[]
            {
            "-----" + Language.Get("Category") + "-----",
            "",
            "[1] - " + Language.Get("Animals").PadRight(10),
            "[2] - " + Language.Get("Fruits").PadRight(10),
            "[3] - " + Language.Get("Cities").PadRight(10),
            "[4] - " + Language.Get("Back").PadRight(10)
        };
            Console.Clear();
            ConsoleHelper.CenterMenu(hardLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();

                    game.SetCategory("Animals");
                    game.SetToHard();
                    game.GameOn();
                    break;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    game.SetCategory("Fruits");
                    game.SetToHard();
                    game.GameOn();
                    break;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleHelper.Sound();
                    game.SetCategory("Cities");
                    game.SetToHard();
                    game.GameOn();
                    break;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ConsoleHelper.Sound();
                    run = false;
                    break;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-4"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }
    // Här får man välja om man vill visa high score eller om man vill töma listan.
    public static void ShowHighScore()
    {
        bool run = true;
        while (run)
        {
            Console.Clear();
            string[] highScoreLines = new string[]
            {
            "-----" + Language.Get("HighScore") + "-----",
            "",
            "[1] - " + Language.Get("ShowList").PadRight(16),
            "[2] - " + Language.Get("ClearList").PadRight(10),
            "[3] - " + Language.Get("Back").PadRight(16)
            };
            ConsoleHelper.CenterMenu(highScoreLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();
                    Console.Clear();
                    ConsoleHelper.CenterAll("----" + Language.Get("ShowHighScore") + "----");
                    // Här kör jag en try/catch. Om filen inte finns får jag ett felmeddelande.
                    try
                    {
                        // Här kollar jag om filen finns
                        if (File.Exists("highscore.txt"))
                        {
                            // Här loopar vi igenom  varje rad i highscore.txt, och delar upp det i namn, antal gissningar och svårighetsgrad
                            // Och sedan centrerar det i konsolen.
                            foreach (var line in File.ReadAllLines("highscore.txt"))
                            {
                                var parts = line.Split(';');
                                if (parts.Length == 3)
                                    Console.WriteLine(ConsoleHelper.CenterText($"{parts[0]} - " + Language.Get("Attempts") +
                                        $"{parts[1]} - " + Language.Get(parts[2]), Console.WindowWidth));
                            }
                            ConsoleHelper.CenterAll(Language.Get("Press"));
                        }
                        // Om listan är tom så Skrivs det ut att det inte finns något på high score listan
                        else
                        {
                            ConsoleHelper.CenterAll(Language.Get("NoHighScore"));
                        }
                        // Om filen inte finns får vi ett felmeddelande som säger: Fel vid läsning av highscore: (och med typ av undantag)
                    }
                    catch (Exception ex)
                    {
                        ConsoleHelper.CenterAll(Language.Get("ReadError") + ex.Message);
                    }
                    Console.ReadKey(true);
                    // Hoppar tillbaka till start menyn. 
                    return;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("EnterPassword") + "\n" + Language.Get("Password"));
                    // Sätter markören där jag vill ha den.
                    ConsoleHelper.SetCursor(0, 5);
                    Console.CursorVisible = true;
                    // Ser till att password alltid får ett giltigt strängvärde och aldrig blir null.
                    string password = Console.ReadLine() ?? "";
                    // Och stänger av den igen.
                    Console.CursorVisible = false;

                    if (password == HighScorePassword)
                    {
                        Console.Clear();
                        ResetHighScore();
                        ConsoleHelper.CenterAll(Language.Get("HighScoreListIsEmpty"));
                        ConsoleHelper.CenterAll(Language.Get("Press"));
                    }
                    else
                    {
                        Console.Clear();
                        ConsoleHelper.CenterAll(Language.Get("WrongPassword"));
                        Thread.Sleep(1300);
                    }
                    Console.ReadKey(true);
                    return;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    run = false;
                    break;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-3"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }
    // Rensar highscore.txt filen igenom att skriva över den med en tom sträng.
    public static void ResetHighScore()
    {
        if (File.Exists("highscore.txt"))
            File.WriteAllText("highscore.txt", string.Empty);
    }
    // Denna metod låter spelaren byta språk.
    private void ChangeLanguage()
    {
        bool run = true;
        while (run)
        {
            string[] languageLines = new string[]
            {
                "-----" + Language.Get("Language") + "-----",
                "",
                "[1] - " + Language.Get("Swedish").PadRight(10),
                "[2] - " + Language.Get("English").PadRight(10),
                "[3] - " + Language.Get("Norway").PadRight(10),
                "[4] - " + Language.Get("Danish").PadRight(10),
                "[5] - " + Language.Get("Germany").PadRight(10),
                "[6] - " + Language.Get("Back").PadRight(10)
        };
            Console.Clear();
            ConsoleHelper.CenterMenu(languageLines);

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ConsoleHelper.Sound();
                    // Ändrar till svenska och sätter språk kultur till "sv-Sv"
                    Language.SetLanguage("sv-SV");
                    return;

                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ConsoleHelper.Sound();
                    // Ändrar språk till engelska och sätter språk kultur till "en-GB"
                    Language.SetLanguage("en-GB");
                    return;

                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ConsoleHelper.Sound();
                    // Ändrar språk till norska och sätter språk kultur till "no-NO"
                    Language.SetLanguage("nb-NO");
                    return;

                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ConsoleHelper.Sound();
                    // Ändrar språk till danska och sätter språk kultur till "dk-DK"
                    Language.SetLanguage("da-DK");
                    return;

                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ConsoleHelper.Sound();
                    // Ändrar till Tyska och sätter språk kultur till "de-DE"
                    Language.SetLanguage("de-DE");
                    return;

                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    ConsoleHelper.Sound();
                    run = false;
                    break;

                default:
                    Console.Clear();
                    ConsoleHelper.CenterAll(Language.Get("WrongInput1-6"));
                    Thread.Sleep(1300);
                    break;
            }
        }
    }
}
