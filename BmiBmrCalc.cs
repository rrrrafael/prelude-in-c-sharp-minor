using System;

namespace PRR01
{
    public static class CustomTools
    {
        public static void Die(short errCode)
        {
            string error = "Fel inmatning\nExit";
            Console.WriteLine(error);

            Environment.Exit(errCode);
        }

        public static int TryReadBool()
        {
            string? read = Console.ReadLine();

            if (read != null)
            {
                switch (read.ToLower()[0])
                {
                    case 'm':
                        return  1;
                    case 'k':
                        return  0;
                    default:
                        return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public static double TryReadDouble()
        {
            if (!double.TryParse(Console.ReadLine(), out double read))
                return 0;
            else
                return read;
        }

        public static int TryReadInt()
        {
            if (!int.TryParse(Console.ReadLine(), out int read))
                return 0;
            else
                return read;
        }
    }
    class User
    {
        private double height;
        private double weight;
        private double bmi;
        private double bmr;
        private int    age;
        private int    gender;

        public User(double height, double weight, int age, int gender)
        {
            this.height = height;
            this.weight = weight;
            this.age    = age;
            this.gender = gender;
        }

        public double GetBmi()
        {
            return 1.3 * weight / Math.Pow(height, 2.5);
        }

        public void PrintBmi(double bmi)
        {
            if (height != 0 && weight != 0)
            {
                string outputFormatString = "Din BMI är {0:0.00}: du är {1}.";
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

                Console.WriteLine(outputFormatString, bmi, append);
            }
            else
            {
                CustomTools.Die(1);
            }
        }

        public double GetBmr()
        {
            if (gender == 1)
                // Män
                return 66.47 + (13.75 * weight) + (5.003 * (height * 100)) - (6.755 * age);
            else if (gender == 0)
                // Kvinnor
                return 655.1 + (9.563 * weight) + (1.85 * (height * 100)) - (4.676 * age);
            else
                return -1;
        }

        public void PrintBmr()
        {
            // TODO
        }
    }

    class Program
    {
        private const string heightPromp  = "Ange din höjd i meter (t.ex. 1,59): ";
        private const string weightPrompt = "Ange din vikt i kilogram (t.ex. 91,72): ";
        private const string agePrompt    = "Ange din ålder: ";
        private const string genderPrompt = "Skriv ditt kön: ";

        static void Main()
        {
            double height;
            double weight;
            int    age;
            int    gender;

            Console.WriteLine("BMI beräknare program");

            Console.Write(heightPromp);
            height = CustomTools.TryReadDouble();

            Console.Write(weightPrompt);
            weight = CustomTools.TryReadDouble();

            Console.Write(agePrompt);
            age    = CustomTools.TryReadInt();

            Console.Write(genderPrompt);
            gender = CustomTools.TryReadBool();

            User user = new User(height, weight, age, gender);
            user.PrintBmi(user.GetBmi());
        }
    }
}