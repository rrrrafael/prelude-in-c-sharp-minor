using System;

class BMI
{
    // Avsluta programmet med errCode tal
    public static void Die(short errCode)
    {
        string error = "Fel inmatning\nExit";
        Console.WriteLine(error);

        Environment.Exit(errCode);
    }

    // Försök att läsa en dubbelkonstant från användaren.
    // Återge det lästa numret från användaren.
    // Återge 0 om det misslyckas. 
    public static double TryReadDouble()
    {
        // Uppmana användaren att ange indata.
        // Om det inte är en double skriv ut ett felmeddelande och
        återge 0
        // I annat fall initialiseras read variabeln med doublekonstant
            if (!double.TryParse(Console.ReadLine(), out double read))
                return 0;
            else
                return read;
    }

    public static void GetBmi()
    {
        double bmi = 0.0; // BMI - Body Mass Index
        double height;    // höjd
        double weitght;   // vikt

        // Information till användaren
        string manual = "BMI beräknare programm\n";

        // Få metoden Console.Writeline att bete sig som C-funktionen
        // printf med den här format string
        // {0:0.00} kommer att ersättas med bmi variabeln formaterad med
        // endast två decimaler.
        // {1} kommer att ersättas med append string
        string outputFormatString = "Din BMI är {0:0.00}: du är {1}.";

        // Denna string kommer att läggas till i utdtata till användaren.
        string append = "";


        // Informera användaren om programmets syfte och funktion.
        Console.WriteLine(manual);

        Console.Write("Ange din höjd: ");
        height = TryReadDouble();

        Console.Write("Ange din vikt: ");
        weitght = TryReadDouble();

        // Se till att de nödvändiga variablerna är initialiserade
        // och beräkna utdata annars avslutas programmet.
        if (height != 0 && weitght != 0) {
            // Beräkna BMI
            bmi = 1.3 * weitght / Math.Pow(height, 2.5);

            // Tabell:
            // Tabellen nedan gäller för män och kvinnor över 18 år med
            // normal kroppsbyggnad.
            //
            // BMI under 18.5        undervikt
            // BMI 18.5–25           sund och normal vikt
            // BMI 25–30             övervikt
            // BMI 30–40             kraftig övervikt
            // BMI över 40           extrem övervik
            if (bmi < 18.5)
                append = "undervikt";
            else if (bmi >= 18.5 && bmi <= 25)
                append = "sund och normal vikt";
            else if (bmi > 25 && bmi <= 30)
                append = "övervikt";
            else if (bmi > 30 && bmi <= 40)
                append = "kraftig övervikt";
            else if (bmi > 40)
                append = "extremt överkvikt";
        }
        else {
            // Avslutas om det misslyckas
            Die(1);
        }

        // Skriv ut resultatet till användaren
        Console.WriteLine(outputFormatString, bmi, append);
    }
}

class Program
{
    static void Main()
    {
        BMI.GetBmi();
    }
}
