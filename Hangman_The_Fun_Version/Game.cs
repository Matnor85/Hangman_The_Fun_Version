namespace Hangman_The_Fun_Version;
internal class Game
{
    private int TotalGuesses { get; set; } // Antalet gissningar som finns kvar.
    private string _secretWord; // Ordet spelaren ska lista ut.
    private char[] _maskedWord; // Hemliga ordet maskerat med (-)
    private Player _player; // Spelaren för spelet.
    private HangManPicture _hangman = new HangManPicture(); // "Bilden" för spelet.
    private string _currentCategory; // Aktuella kategorin man valt. 
    private string _currentDifficulty; // Aktuella svårighetsgrad man valt.
    private int _maxGuesses;// Denna håller koll på det totala antalet gissningar som är tillåtet, beroende på vilken svårighetsgrad som är satt.
    private List<WordBank> _allWords = new List<WordBank>(); // Listan med alla ord från .txt filen.

    // Skapar en ny spelare och läser in alla ord som finns ifrån Wordbank.txt.
    public Game(Player player)
    {
        _player = player;
        GetWordsFromFile("Wordbank.txt");
    }
    // Denna metod är den som är själva spelet, som hanterar gissningar, uppdaterar det maskerade ordet,
    // och ritar ut gubben och avgör om spelet är klart.

    public void GameOn()
    {
        // Kallar på en metod som nollställer totala gissningar.
        _player.ResetGuessesCount();
        // Maskerar jag det hemliga ordet.
        Array.Fill(_maskedWord, '-');
        do
        {
            // Här sätter jag buffert storleken på consolen till fönstrets storlek för att undvika scrollning.
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            // Här beräknar jag hur många gånger spelaren har gissat fel under spelet.
            int wrongGuesses = _maxGuesses - TotalGuesses;

            // Skapar jag en ny lista som jag ska lägga in allt som har med spelet att göra, detta gör jag
            // för att jag skall kunna centrera spelet snyggare i consolen.
            var lines = new List<string>
            {
                $"{Language.Get("Category")}: {Language.Get("Category_" + _currentCategory)}",
                $"{Language.Get("Difficulty")}: {Language.Get("Difficulty_" + _currentDifficulty)}",
                "",
                "",
                "",
                "",
                ""
            };
            // Här skapar jag en array som kollar jag vilken svårighetsgrad som är satt och hämtar rätt "bild"
            // och delar upp bilden och lägger den i olika element i arrayen.
            string[] hangmanLines;
            // Easy
            if (_currentDifficulty == "Easy")
                hangmanLines = _hangman.easyStages[wrongGuesses].Replace("\r", "").Split('\n');
            // Normal
            else if (_currentDifficulty == "Normal")
                hangmanLines = _hangman.normalStages[wrongGuesses].Replace("\r", "").Split('\n');

            // Hard
            else
                hangmanLines = _hangman.hardStages[wrongGuesses].Replace("\r", "").Split('\n');

            // Här loopar jag igenom hangman-bilden rad för rad och lägger till i listan.
            foreach (var line in hangmanLines)
            {
                // Här tar jag bort helt tomma rader, men behåller rader med mellanslag.
                if (!string.IsNullOrWhiteSpace(line))
                    lines.Add(line);
            }

            // Lägg till spelinformation i listan.
            lines.Add("");
            lines.Add("");
            lines.Add("");
            lines.Add("");
            lines.Add("");
            lines.Add($"{Language.Get("SecretWord")} {new string(_maskedWord)}");
            lines.Add($"{Language.Get("GuessedLetters")} {string.Join(", ", _player._guessedLetters)}");
            lines.Add($"{Language.Get("TriesLeft")} {TotalGuesses}");
            lines.Add(Language.Get("GuessLetter"));

            // Här skriver jag ut hela listan centrerat.
            ConsoleHelper.CenterBlock(lines);
            // Jämför listan ifall om spelaren radan har gissat på bokstaven, ifall den finns så räknas inte den gissningen.
            char guessedChar = char.ToUpper(Console.ReadKey(true).KeyChar);
            if (_player._guessedLetters.Contains(guessedChar))
            {
                continue;
            }

            // Här lägger jag till den bokstaven som spelaren precis gissade på i spelarens lista över gissade bokstäver
            _player.MakeGuess(guessedChar);
            bool found = false;
            // Med denna loop kollar jag igenom det hemliga ordet ifall om bokstaven finns.
            for (int i = 0; i < _secretWord.Length; i++)
            {
                if (guessedChar == char.ToUpper(_secretWord[i]))
                {
                    _maskedWord[i] = _secretWord[i];
                    found = true;
                }
            }
            // Minskar antalet gissningar med en om bokstaven inte finns.
            if (!found)
            {
                ConsoleHelper.Sound();
                TotalGuesses--;
            }
            // Om antal gissningar är noll så går man vidare till GameOver metoden.
            if (TotalGuesses <= 0)
            {
                GameOver();
                return;
            }
            // Här kollar man om det hemliga ordet är avslöjat, och går vidare till WellDone metoden.
            if (IsSecretWordUncovered())
            {
                WellDone();
                return;
            }
            // Loopen fortsätter så länge spelet är igång.
        } while (true);

    }
    // Här kollar jag att det maskerade ordet är avslöjat eller ej.
    private bool IsSecretWordUncovered()
    {
        return string.Equals(new string(_maskedWord), _secretWord,
            StringComparison.InvariantCultureIgnoreCase);
    }


    public void SetToEasy()
    {
        // Här sätter jag antalet gissningar man får.
        TotalGuesses = 8;
        _maxGuesses = 8;
        // Här sätter jag svårighetsgraden för spelet.
        _currentDifficulty = "Easy";
        // Här hämtar jag ett slumpat ord med vald kategori för svårighetsgraden.
        _secretWord = GetRandomWord(_currentCategory, _currentDifficulty);
        // Och här maskerar jag ordet
        _maskedWord = new char[_secretWord.Length];
    }

    public void SetToNormal()
    {
        // Här sätter jag antalet gissningar man får.
        TotalGuesses = 6;
        _maxGuesses = 6;
        // Här sätter jag svårighetsgraden för spelet.
        _currentDifficulty = "Normal";
        // Här hämtar jag ett slumpat ord med vald kategori för svårighetsgraden.
        _secretWord = GetRandomWord(_currentCategory, _currentDifficulty);
        // Och här maskerar jag ordet.
        _maskedWord = new char[_secretWord.Length];
    }

    public void SetToHard()
    {
        // Här sätter jag antalet gissningar man får.
        TotalGuesses = 4;
        _maxGuesses = 4;
        // Här sätter jag svårighetsgraden för spelet.
        _currentDifficulty = "Hard";
        // Här hämtar jag ett slumpat ord med vald kategori för svårighetsgraden.
        _secretWord = GetRandomWord(_currentCategory, _currentDifficulty);
        // Och här maskerar jag ordet.
        _maskedWord = new char[_secretWord.Length];
    }

    // Med denna metod så kan jag läsa in allt från en .txt fil och sparar det i en lista.
    // Från denna lista kan jag sedan slumpa fram ett ord ifrån beroende på kategori och svårighetsgrad med GetRandomWord() metoden.
    private void GetWordsFromFile(string file)
    {
        try
        {
            string[] lines = File.ReadAllLines(file);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(';');
                if (parts.Length == 3)
                {
                    // Här lägger jag till i listan med parts [0] kategori, [1] svårighetsgrad och [2] ordet.
                    _allWords.Add(new WordBank(parts[0], parts[1], parts[2]));
                }
            }
        }
        // Fångar ev. fel.
        catch (Exception ex)
        {
            ConsoleHelper.CenterAll(Language.Get("FileReadError") + "\n" + ex.Message);
        }
    }
    // Denna metod sätter vilken kategori spelet ska ha.
    public void SetCategory(string category)
    {
        _currentCategory = category;
    }
    // Här skapar jag en temporär lista med ord som matchar med kategori och svårighetsgrad som är vald,
    // Och efter det så slumpar man fram ett ord från listan och returnerar det till GameOn metoden.
    public string GetRandomWord(string category, string difficulty)
    {
        try
        {

            List<string> filteredWords = new List<string>();
            for (int i = 0; i < _allWords.Count; i++)
            {
                if (_allWords[i]._category == category && _allWords[i]._difficulty == difficulty)
                {
                    filteredWords.Add(_allWords[i]._word);
                }
            }
            if (filteredWords.Count == 0)
                // Om inga ord finns som matchar det vi kräver så returneras null.
                return null!;

            Random rnd = new Random();
            int index = rnd.Next(filteredWords.Count);
            return filteredWords[index];
        }
        catch (Exception ex)
        {
            ConsoleHelper.CenterAll(Language.Get("RetrievingWords") + $": {ex.Message}");
            return null!;
        }
    }
    public void GameOver()
    {
        // skapar en lista med all text som ska visas på en gång för att centrera det bättre.
        var lines = new List<string>();

        lines.Add("");
        lines.Add("     ______");
        lines.Add("     |   \\|");
        lines.Add("     O    |");
        lines.Add("    /|\\   |");
        lines.Add("    / \\   |");
        lines.Add("          |");
        lines.Add("    ==========");
        lines.Add("");
        lines.Add("");
        lines.Add(Language.Get("GameOver"));
        lines.Add($"{Language.Get("EndShowWord")} {_secretWord}");
        lines.Add($"{Language.Get("EndShowGuesses")} {_player!.TotalGuesses}");
        lines.Add($"{Language.Get("EndShowGuessedLetters")} {string.Join(", ", _player._guessedLetters)}");
        lines.Add($"{Language.Get("BetterLuckNextTime")} {_player!.Name}");
        lines.Add("");
        lines.Add("");
        lines.Add("");
        lines.Add(Language.Get("Press"));
        // Skriver jag ut listan så att den centreras i konsolen.
        ConsoleHelper.CenterBlock(lines);

        Console.ReadKey(true);
        // Nollställer jag antalet gissningar, så det inte följer med till nästa spel omgång.
        TotalGuesses = 0;
        // Nollställer jag listan med gissade bokstäver, så det inte följer med till nästa spel omgång.
        _player._guessedLetters.Clear();
    }

    private void WellDone()
    {
        // skapar en lista med all text som ska visas på en gång för att centrera det bättre.
        var lines = new List<string>();

        lines.Add("");
        lines.Add("     \\O/");
        lines.Add("     |");
        lines.Add("     / \\");
        lines.Add("  =======");
        lines.Add("");
        lines.Add("");
        lines.Add(Language.Get("WellDone"));
        lines.Add($"{Language.Get("EndShowWord")} {_secretWord}");
        lines.Add($"{Language.Get("EndShowGuesses")} {_player!.TotalGuesses}");
        lines.Add($"{Language.Get("EndShowGuessedLetters")} {string.Join(", ", _player._guessedLetters)}");
        lines.Add($"{Language.Get("Awsome")} {_player!.Name}");
        lines.Add("");
        lines.Add("");
        lines.Add("");
        lines.Add(Language.Get("Press"));
        // Skriver jag ut listan så att den centreras i konsolen.
        ConsoleHelper.CenterBlock(lines);

        Console.ReadKey(true);

        // Spara jag informationen till highscore listan med namnet på spelaren och antalet gissningar och svårighetsgrad.
        string scoreLine = $"{_player.Name};{_player.TotalGuesses};{_currentDifficulty}";
        try
        {
            File.AppendAllText("highscore.txt", scoreLine + Environment.NewLine);
        }
        // Fångar ev. fel.
        catch (Exception ex)
        {
            ConsoleHelper.CenterAll(Language.Get("FileWriteError") + "\n" + ex.Message);
        }
        // Nollställer jag antalet gissningar, så det inte följer med till nästa spel omgång.
        TotalGuesses = 0;
        // Nollställer jag listan med gissade bokstäver, så det inte följer med till nästa spel omgång.
        _player._guessedLetters.Clear();
    }

}
