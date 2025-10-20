namespace Hangman_The_Fun_Version;
internal class Player
{
    // Skapar jag en lista som sparar alla bokstäver spelaren gissat på.
    public List<char> _guessedLetters { get; private set; } = new();
    // Sparar jag totala antalet gissningar spelaren har gjort.
    public int TotalGuesses { get; private set; }
    // Spelarens namn
    string _playerName;

    // skapar spelarens namn och kan endast ändras inom klassen
    public string Name
    {
        get { return _playerName; }
        private set
        {
            _playerName = value;
        }
    }
    // Här skapas en ny spelare men namnet man valde.
    public Player(string name)
    {
        Name = name;
    }
    // Här lägger man till en bokstav i listan över gissade bokstäver om den redan inte finns.
    public void MakeGuess(char guessedChar)
    {
        if (!_guessedLetters.Contains(guessedChar))
            _guessedLetters.Add(guessedChar);
    }
    // Här nollställer jag spelarens totala gissningar så att dom inte följer med till nästa spel
    // om spelaren väjer att spela igen.
    public void ResetGuessesCount()
    {
        TotalGuesses = 0;
    }
}
