namespace Hangman_The_Fun_Version;
internal class WordBank
{
    // Ordets kategori, svårighetsgrad och själva ordet
    public string _category;
    public string _difficulty;
    public string _word;
    // Skapar ett nytt wordbank instans med kategori, svårighetsgrad och ord
    public WordBank(string category, string difficulty, string word)
    {
        _category = category;
        _difficulty = difficulty;
        _word = word;
    }
}