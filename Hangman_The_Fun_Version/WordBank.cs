namespace Hangman_The_Fun_Version;
internal class WordBank
{
    // Ordets kategori, sv�righetsgrad och sj�lva ordet
    public string _category;
    public string _difficulty;
    public string _word;
    // Skapar ett nytt wordbank instans med kategori, sv�righetsgrad och ord
    public WordBank(string category, string difficulty, string word)
    {
        _category = category;
        _difficulty = difficulty;
        _word = word;
    }
}