using System;

namespace BMI
{
    // Vi har klassen Person som kommer att innehålla metoder för att räkna BMI och BMR.
    class Person
    {
        // Variabler som vi kommer att använda i klassen.
        private double height;
        private double weight;
        private double bmi;

        // Initializator för klassen BMI
        public Person(double height, double weight)
        {
            this.height = height;
            this.weight = weight;
        }

        // Avsluta programmet med errCode tal
        public static void Die(short errCode)
        {
            string error = "Fel inmatning\nExit";
            Console.WriteLine(error);

            Environment.Exit(errCode);
        }
        
        public void printBmr() {
            // TODO
        }

        public void printBmi()
        {
            // Få metoden Console.Writeline att bete sig som C-funktionen
            // printf med den här format string
            // {0:0.00} kommer att ersättas med bmi variabeln formaterad med
            // endast två decimaler.
            // {1} kommer att ersättas med append string
            string outputFormatString = "Din BMI är {0:0.00}: du är {1}.";

            // Denna string kommer att läggas till i utdtata till användaren.
            string append = "";

            // Se till att de nödvändiga variablerna är initialiserade
            // och beräkna utdata annars avslutas programmet.
            if (height != 0 && weight != 0) {
                // Beräkna BMI
                bmi = 1.3 * weight / Math.Pow(height, 2.5);

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
		// Försök att läsa en dubbelkonstant från användaren.
		// Återge det lästa numret från användaren.
		// Återge 0 om det misslyckas. 
		private static double TryReadDouble()
		{
			// Uppmana användaren att ange indata.
			// Om det inte är en double skriv ut ett felmeddelande och återge 0
			// I annat fall initialiseras read variabeln med doublekonstant
			if (!double.TryParse(Console.ReadLine(), out double read))
				return 0;
			else
				return read;
		}

		
        static void Main()
        {
            // Här kommer vi spara inmätningsdata.
            double height; // höjd
            double weight; // vikt

            // Informera användaren om programmets syfte och funktion.
            Console.WriteLine("BMI beräknare program");

            // Informera användaren om att inmäta sin höjd.
            Console.Write("Ange din höjd: ");
            height = TryReadDouble();

            // Informera användaren om att inmäta sin vikt.
            Console.Write("Ange din vikt: ");
            weight = TryReadDouble();

            // Skafa en variabel person från klassen Person med inmätande data och skriva ut hans BMI värde.
            Person person = new Person(height, weight);
            person.printBmi();
        }
    }

}
