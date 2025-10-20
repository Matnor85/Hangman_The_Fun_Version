namespace Hangman_The_Fun_Version;
// Denna klassen använs till att justera text och markören
internal class ConsoleHelper
{
    // Justerar Markören
    public static void SetCursor(int height = 0, int width = 0)
    {
        // Här använder jag WindowHeight för att sätta markören vertikalt,
        // och +1 för att hamna under texten som finns.
        int cursorHeight = (Console.WindowHeight / 2) + height;

        // Beräknar horisontell position. Mitten av fönstret plus offset
        // +3 justerar så att texten inte hamnar direkt vid mitten utan får ett mellanslag (Namn: [input])
        int cursorWidth = (Console.WindowWidth / 2) + width;

        // Sätter markören på beräknad position men offsets height och width.
        Console.SetCursorPosition(cursorWidth, cursorHeight);
    }

    // Centrerar texten i horisontellt.
    public static string CenterText(string text, int totalWidth)
    {
        // Kontrollerar om texten är null eller tom eller om den är längre än konsolens bredd.
        if (string.IsNullOrEmpty(text) || totalWidth <= text.Length)
        {
            // Om texten inte kan centrerad, returneras den som den är.
            return text;
        }
        // Beräknar antalet mellanslag som behövs för att centrera texten.
        int padding = totalWidth - text.Length;

        // Här delar men upp mellan slagen jämt mellan vänster och höger sida.
        int padLeft = padding / 2;
        int padRight = padding - padLeft;

        // Returnerar vi den centrerade texten med lika mycket mellanslag på båda sidor.
        return new string(' ', padLeft) + text + new string(' ', padRight);
    }

    // Centrerar allt till mitten av konsolen.
    public static void CenterAll(string text)
    {
        // Konsolens totala bredd.
        int totalWidth = Console.WindowWidth;
        // Konsolens totala höjd.
        int totalHeight = Console.WindowHeight;

        // Dela upp texten i rader om det finns radbrytningar.
        string[] lines = text.Replace("\r", "").Split('\n');

        // Beräkna hur många tomma rader som behövs ovanför för att centrera vertikalt.
        int topPadding = (totalHeight / 2) - (lines.Length / 2);

        // Skriv ut tomma rader ovanför.
        for (int i = 0; i < topPadding; i++)
            Console.WriteLine();

        // Skriv ut varje rad centrerad horisontellt med hjälp av CenterText.
        foreach (var line in lines)
            Console.WriteLine(CenterText(line, totalWidth));
    }

    // Centrerar en sträng arrays alla element som jag använder för att visa meny valen
    // Denna är nästan identisk mot CenterAll metoden förutom att denna hanterar en array istället för en sträng.
    public static void CenterMenu(string[] lines)
    {
        // Konsolens totala höjd
        int totalHeight = Console.WindowHeight;

        // Beräkna hur många tomma rader som behövs ovanför för att centrera vertikalt.
        int topPadding = (totalHeight / 2) - (lines.Length / 2);

        // Skriv ut tomma rader för vertikal centrering.
        for (int i = 0; i < topPadding; i++)
            Console.WriteLine();

        // Skriv ut varje rad centrerad horisontellt med hjälp av CenterText.
        foreach (var line in lines)
            Console.WriteLine(CenterText(line, Console.WindowWidth));
    }

    // Centrerar en lista av strängar både horisontellt och vertikalt i konsolen.
    public static void CenterBlock(List<string> lines)
    {
        // Konsolens totala höjd och bredd
        int totalHeight = Console.WindowHeight;
        int totalWidth = Console.WindowWidth;

        // Beräkna startposition vertikalt så att blocket hamnar centrerat
        int startY = (totalHeight / 2) - (lines.Count / 2);

        // Tömer konsolen och sätt startposition för utskrift
        Console.Clear();
        Console.SetCursorPosition(0, Math.Max(0, startY));

        // Skriv ut varje rad centrerad horisontellt
        foreach (var line in lines)
        {
            string centeredLine = CenterText(line, totalWidth);
            Console.WriteLine(centeredLine);
        }
        // Flytta markören till början av nästa rad
        Console.SetCursorPosition(0, startY + lines.Count + 1);
    }
    // Spelar upp ett kort ljud om man kör på Windows.
    // Gör inget på andra operativsystem eftersom Console.Beep() inte stöds där.
    public static void Sound()
    {
        // Kollar om man använder windows.
        if (OperatingSystem.IsWindows())
        {
            Console.Beep(1300, 35);
        }
    }
}
