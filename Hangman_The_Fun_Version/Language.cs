using System.Globalization;
using System.Resources;

namespace Hangman_The_Fun_Version;
// Language hanterar språkbyte och textöversättning i spelet.
internal class Language
{
    // ResourceManager används för att hämta textsträngar från resursfilen Resources.resx
    // Och i den filen kan man enkelt lägga till flera språk.
    private static readonly ResourceManager rm =
       new ResourceManager("Hangman_The_Fun_Version.Resources.Resources", typeof(Language).Assembly);

    // Metoden sätter vilket språk kultur som ska användas.
    // "Se" svenska är förhands valet, "En" för engelska och "De" för tyska osv.
    public static void SetLanguage(string cultureCode)
    {
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
    }

    // Get metoden hämtar en textsträng baserat på nyckeln från resursfilen,
    // och returnerar värdet av nyckeln.
    public static string Get(string key)
    {
        try
        {
            // Returnerar översättningen eller om nyckeln inte finns så skrivs,
            // ordet man anget ut inom hakparenteserna som en indikation.
            return rm.GetString(key) ?? $"[{key}]";
        }
        catch (MissingSatelliteAssemblyException)
        {
            // Om språk filen inte finns fångas den här och returneras "[key]" som en indikation.
            // Skriver ut meddelandet på engelska för att unvika att man hamnar i en evighets loop om jag 
            // anropa metoden i sig själv.
            return $"Missing language file for key: [{key}]";
        }
        catch (Exception e)
        {
            // Fångar oväntade fel vid hämtning av text från filen.
            return $"Error fetching text for key [{key}]: {e.Message}";
        }
    }
}
