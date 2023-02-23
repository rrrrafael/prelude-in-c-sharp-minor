namespace PRR01
{
    // A static class. This is a bag of usefool methods to
    // make the code less repetitive and easier to read.
    // Main consist of wrapper methods
    public static class CustomTools
    {
        // Simple error handling method:
        // Prints the error message msg to the user and exits
        // with status code errCode
        public static void Die(string msg, int errCode)
        {   
            Console.Write("Fel inmatning: ");
            Console.WriteLine(msg + "\nExit");


            Environment.Exit(errCode);
        }

        // Wrapper around the methods double.TryParse and
        // Console.Readline
        // Try to read a string of numbers as a double.
        // Returns the number or 0 on failure
        public static double TryReadDouble()
        {
            if (!double.TryParse(Console.ReadLine(), out double read))
                return 0;
            else
                return read;
        }

        // Wrapper around the methods int.TryParse and
        // Console.Readline
        // Try to read a string of numbers as an int.
        // Returns the number or 0 on failure
        public static int TryReadInt()
        {
            if (!int.TryParse(Console.ReadLine(), out int read))
                return 0;
            else
                return read;
        }
    }

    // User class does all the data validation in its constructor
    class User
    {
        // User private fields
        private double height;
        private double weight;
        private int    age;
        // Please note difference in the type inside and outside of User class in gender
        // Since the program only deals with male and female the type bool was chosen
        private bool   gender;

        // User constructor
        // All the logic and checks for appropriate values happens here.
        // Exits with specific erro message on failure
        public User(double height, double weight, int age, string? gender)
        {
            // Since there is only one statement inside the if's and else's 
            // we decided not to use curly braces to avoid clutter
            // Read slowly
            if (height >= 0.5 && height <= 2.2)
                this.height = height;
            else
                CustomTools.Die("inte ett lämpligt svar: höjd: " + height, 1);
            
            if (weight >= 10 && weight <= 250)
                this.weight = weight;
            else
                CustomTools.Die("inte ett lämpligt svar: vikt: " + weight, 1);

            if (age >= 18 && age <= 70)
                this.age = age;
            else
                CustomTools.Die("inte ett lämpligt svar: ålder: " + age, 1);
            
            // Check for null before doing anything
            // See Program class varibles declarions for more information
            if (gender != null)
            {
                // Do validations using lowercase to simplify
                switch (gender.ToLowerInvariant())
                {
                    case "k":
                        this.gender = true;
                        break;
                    case "m":
                        this.gender = false;
                        break;
                    default:
                        CustomTools.Die("inte ett lämpligt svar: kön: " + gender, 1);
                        break;
                }
            }
            else
            {
                CustomTools.Die("inte ett lämpligt svar: kön kan inte saknas.", 1);
            }
        }

        // Calculatee BMI
        public double GetBmi()
        {
            return 1.3 * weight / Math.Pow(height, 2.5);
        }

        public static void PrintBmi(double bmi)
        {
            // Make the Console.WriteLine behave lika C printf function.
            // please refer to this Console.WriteLine reference:
            // https://learn.microsoft.com/en-us/dotnet/api/system.console.writeline?view=net-7.0
            // {0:0.00} means to only use two decimal after the floating point
            // {1} will be replaced by append varible
            string outputFormatString = "Din BMI är {0:0.00}: du är {1}.";
            
            // Make the output modular assigning the appropriate value
            // to append
            string append = "";

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

            // Prints for ex.: "Din BMI är 27.58: du är övervikt."
            Console.WriteLine(outputFormatString, bmi, append);
        }

        // Calculate BMR
        public double GetBmr()
        {
            if (gender)
                // Formula for women
                return 655.1 + (9.563 * weight) + (1.85 * (height * 100)) - (4.676 * age);            
            else
                // Formula for men
                return 66.47 + (13.75 * weight) + (5.003 * (height * 100)) - (6.755 * age);
        }

        public static void PrintBmr(double bmr)
        {
            // Prints for ex.: "Din BMR är 1688.02."
            Console.WriteLine("Din BMR är {0:0.00}.", bmr);
        }
    }

    // A high level class that takes care of generic I/O interacitions
    // and lightly manages objects
    class Program
    {
        // BEGIN output strings
        // For better code organization these varialbles hold output strings
        // These make the code more readable and easy to modify
        private const string greetingPrompt = "BMI och BMR beräknare program: version 1.0.0\nTryck på \"h\" för att få hjälp; tryck på något annat för att starta.";
        private const string heightPromp    = "Ange din höjd i meter (t.ex. 1,59): ";
        private const string weightPrompt   = "Ange din vikt i kilogram (t.ex. 91,72): ";
        private const string agePrompt      = "Ange din ålder (mellan 18 och 70): ";
        private const string genderPrompt   = "Skriv ditt kön ([M/m] för Man eller [K/k] för Kvinna): ";
        private const string exitPrompt     = "\nTack för att du använder detta program! Vänligen kontakta en riktig läkare om du inte mår bra. Detta är inte en diagnos.\nHej då!";
        private const string loadingMessage = "\nBeräkning...\n";
        private const string helpMessage    = "" +
            "\nDu bad om hjälp. Hjälpen skriver ut detta meddelande och avslutas:\n\n" +

            "Programmet beräknar ditt BMI (Body Mass Index) och BMR (Basal Metabolic Rate).\n\n" +

            "Du kommer att uppmanas att ange:\n\n" +

                    "\tDin  höjd i meter (bara siffror);\n" +
                    "\tGiltiga värden är: 0,5 till 2,2.\n\n" +

                    "\tDin  vikt i kilogram (bara siffror);\n" +
                    "\tGiltiga värden är: 10 till 250.\n\n" +

                    "\tDin  ålder (bara siffror);\n" +
                    "\tGiltiga värden: 18 till 70.\n\n" +

                    "\tDitt kön: Giltiga värden är antingen M/m för man eller K/k för kvinna;\n" +
                    "\tDetta program fungerar inte med andra könsidentiteter ännu.\n\n" +

            "Om ogiltiga värden matas in i programmet kommer det att visa ett felmeddelande och avslutas." +
            "Om värdena är giltiga skriver programmet ut på skärmen ditt BMI-värde" +
            "och vilken kategori det tillhör, följt av ditt BMR-värde.\n\n" +

            "Exit.";
        // END output strings

        public static void Help()
        {
            Console.WriteLine(helpMessage);
            Environment.Exit(0);
        }

        // Main method manages I/O interaction and
        // feed apropriate arguments to objects and functions
        static void Main()
        {   
            // There is no need to create BMI or BMR variables
            // The user specific data is owned by the User class
            double  height;
            double  weight;
            int     age;
            // The gender of a nullable type
            // Please refer to this reference to lear more:
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types
            string? gender;

            // Clear console to start program
            Console.Clear();
            
            // Tells the user the function and usage of the program
            // Offer option to get help or to start program.
            Console.WriteLine(greetingPrompt);

            // Check whether user asked for help or not
            string? option;
            if ((option = Console.ReadLine()) == "h")
            {
                Help();
            }
            else
            {
                // Clear console again
                Console.Clear();

                // These CustomTools methods are simple wrappers around Console.Read
                // Please see CustomTools class
                Console.Write(heightPromp);
                height = CustomTools.TryReadDouble();

                Console.Write(weightPrompt);
                weight = CustomTools.TryReadDouble();

                Console.Write(agePrompt);
                age    = CustomTools.TryReadInt();

                // Simple string reading
                Console.Write(genderPrompt);
                gender = Console.ReadLine();

                // In case it takes much long for the program to do its jobs
                // Future proofing for when the program gets bigger and takes longer
                Console.WriteLine(loadingMessage);

                // Create User object and call two static methods
                // to print BMI and BMR back to the user
                User user = new(height, weight, age, gender);
                User.PrintBmi(user.GetBmi());
                User.PrintBmr(user.GetBmr());

                // Exit telling the user
                Console.WriteLine(exitPrompt);
            }
        }
    }
}