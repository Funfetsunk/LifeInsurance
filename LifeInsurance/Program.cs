using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace LifeInsurance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("LIFE INSURANCE QUOTE");

            // Setup new instance of Client
            Client NewClient = new Client();

            // Capture user details.
            // User Age
            Console.WriteLine("What is your date of birth (DD/MM/YYYY)?");
            NewClient.Age = CalculateAge(Console.ReadLine());
            Console.WriteLine("");

            //User Gender
            Console.WriteLine("What is your gender? (M/F)");
            NewClient.Gender = CaptureGender(Console.ReadLine());
            Console.WriteLine("");

            // Capture postcode and convert to country
            Console.WriteLine("What is your post code?");
            NewClient.Country = PostCodeLookup(Console.ReadLine());
            Console.WriteLine("");

            // Capture smoking details
            Console.WriteLine("Are you a smoker? (enter Y/N)");
            NewClient.Smoker = CaptureSmoker(Console.ReadLine());
            Console.WriteLine("");

            // Capture exercise details
            Console.WriteLine("How many hours exercise do you do per week?");
            NewClient.HoursOfExercise = Convert.ToInt32(CaptureExercise(Console.ReadLine()));
            Console.WriteLine("");

            // Capture children details
            Console.WriteLine("Do you have any children? (enter Y/N)");
            NewClient.Children = CaptureChildren(Console.ReadLine());
            Console.WriteLine("");

            // Work out base price.
            // Start with male customers.
            double TotalPremium;

            if (NewClient.Gender == "M")
            {
                if (NewClient.Age >= 0 && NewClient.Age <= 18)
                {
                    TotalPremium = 150.00;
                }
                else if (NewClient.Age >= 19 && NewClient.Age <= 24)
                {
                    TotalPremium = 180.00;
                }
                else if (NewClient.Age >= 25 && NewClient.Age <= 35)
                {
                    TotalPremium = 200.00;
                }
                else if (NewClient.Age >= 35 && NewClient.Age <= 45)
                {
                    TotalPremium = 250.00;
                }
                else if (NewClient.Age >= 45 && NewClient.Age <= 60)
                {
                    TotalPremium = 320.00;
                }
                else
                {
                    TotalPremium = 500.00;
                }
            }

            //Then look at female customers.
            else
            {
                if (NewClient.Age >= 0 && NewClient.Age <= 18)
                {
                    TotalPremium = 100.00;
                }
                else if (NewClient.Age >= 19 && NewClient.Age <= 24)
                {
                    TotalPremium = 165.00;
                }
                else if (NewClient.Age >= 25 && NewClient.Age <= 35)
                {
                    TotalPremium = 180.00;
                }
                else if (NewClient.Age >= 35 && NewClient.Age <= 45)
                {
                    TotalPremium = 225.00;
                }
                else if (NewClient.Age >= 45 && NewClient.Age <= 60)
                {
                    TotalPremium = 315.00;
                }
                else
                {
                    TotalPremium = 485.00;
                }
            }

            // Adjust Premium based on "Regional Health Index"
            switch (NewClient.Country)
            {
                case "England":
                    break;

                case "Wales":
                    TotalPremium = TotalPremium - 100.00;
                    break;

                case "Scotland":
                    TotalPremium = TotalPremium + 200.00;
                    break;

                case "Ireland":
                    TotalPremium = TotalPremium + 50.00;
                    break;

                case "Northen Ireland":
                    TotalPremium = TotalPremium + 75.00;
                    break;

                default:
                    TotalPremium = TotalPremium + 100.00;
                    break;
            }

            // If client has children increase premium by 50%
            if (NewClient.Children == "Y")
            {
                TotalPremium = TotalPremium * 1.5;
            }

            // If client is a smoker increase premium by 300%
            if (NewClient.Smoker == "Y")
            {
                TotalPremium = TotalPremium * 4.0;
            }

            // Adjust premium based on exercise.
            if (NewClient.HoursOfExercise < 1)
            {
                TotalPremium = TotalPremium * 1.2;
            }
            else if (NewClient.HoursOfExercise < 3)
            {
            }
            else if (NewClient.HoursOfExercise < 6)
            {
                double Deduction = TotalPremium * 0.3;
                TotalPremium = TotalPremium - Deduction;
            }
            else if (NewClient.HoursOfExercise < 9)
            {
                double Deduction = TotalPremium * 0.5;
                TotalPremium = TotalPremium - Deduction;
            }
            else if (NewClient.HoursOfExercise >= 9)
            {
                TotalPremium = TotalPremium * 1.5;
            }

            // Check that the final premium is not less then £50, if it is make the premium £50
            if (TotalPremium < 50.00)
            {
                TotalPremium = 50.00;
            }

            // Clear the screen and display Price
            Console.Clear();
            Console.WriteLine("Based on the following information:");

            // Age
            Console.Write("You are ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(NewClient.Age);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" years old.");

            // Gender
            Console.Write("You are ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (NewClient.Gender == "M")
            {
                Console.WriteLine("Male");
            }
            else
            {
                Console.WriteLine("Female");
            }

            Console.ForegroundColor = ConsoleColor.White;

            // Country
            Console.Write("You live in ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(NewClient.Country);
            Console.ForegroundColor = ConsoleColor.White;

            // Smoker
            Console.Write("You ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (NewClient.Smoker == "Y")
            {
                Console.Write("are ");
            }
            else
            {
                Console.Write("are not ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("a smoker");

            // Exercise
            Console.Write("You get ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(NewClient.HoursOfExercise);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" hours exercise per week");

            // Children
            Console.Write("You ");
            Console.ForegroundColor = ConsoleColor.Green;
            if (NewClient.Children == "Y")
            {
                Console.Write("have ");
            }
            else
            {
                Console.Write("do not have ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("children");

            // Disaply Total Price
            Console.WriteLine("");
            Console.WriteLine("Your total premium is: {0:C}", TotalPremium);

            // Ensure screen is displayed.
            Console.ReadLine();
        }

        private static int CalculateAge(String DateOfBirth)
        {
            bool Redisp = true;
            DateTime dateofbirth;
            int Age = 0;
            while (Redisp)
            {
                if (DateTime.TryParse(DateOfBirth, out dateofbirth))
                {
                    Redisp = false;

                    Age = DateTime.Now.Year - dateofbirth.Year;
                    if (DateTime.Now.DayOfYear < dateofbirth.DayOfYear)
                        Age = Age - 1;
                }
                else
                {
                    Console.WriteLine("Please use format \"DD/MM/YYY\"");
                    Console.WriteLine("What is your date of birth (DD/MM/YYY)?");
                    DateOfBirth = Console.ReadLine();
                }
            }
            return Age;
        }

        private static string CaptureGender(String Gender)
        {
            bool Redisplay = true;

            while (Redisplay)
            {
                Gender = Gender.ToUpper();
                switch (Gender)
                {
                    case "M":
                        Redisplay = false;
                        break;

                    case "F":
                        Redisplay = false;
                        break;

                    default:
                        Redisplay = true;
                        Console.WriteLine("Please enter M or F.");
                        Console.WriteLine("What is your gender? (M/F)");
                        Gender = Console.ReadLine();
                        break;
                }
            }

            return Gender;
        }

        private static string PostCodeLookup(String PostCodeURL)
        {
            string PostCodeLookupURL = ("https://api.postcodes.io/postcodes/" + PostCodeURL);
            string country = ("");
            // Setup http call
            WebRequest wrGETURL;
            wrGETURL = WebRequest.Create(PostCodeLookupURL);
            wrGETURL.Method = "GET";
            // Setup proxy settings
            WebProxy prox = new WebProxy();
            Uri uri = new Uri("http://peg-proxy01:80");
            prox.Address = uri;
            // prox.Credentials = new System.Net.NetworkCredential("USERNAME", "PASSWORD", "INSURANCE");
            wrGETURL.Proxy = prox;
            
            // Make request

            try
            {
                Stream objStream;
                objStream = wrGETURL.GetResponse().GetResponseStream();
                // Parse return, extract Status and Country
                StreamReader reader = new StreamReader(objStream);
                string json = reader.ReadToEnd();
                JToken token = JObject.Parse(json);

                int Status = (int)token.SelectToken("status");
                // Populate NewClient instance with country.
                country = (string)token.SelectToken("result.country");
                return country;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("The following error occured.");
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting application");
                Console.ReadLine();
                Environment.Exit(0);
            }

            return country;
        }

        private static string CaptureSmoker(String Smoker)
        {
            bool Redisplay = true;

            while (Redisplay)
            {
                Smoker = Smoker.ToUpper();
                switch (Smoker)
                {
                    case "Y":
                        Redisplay = false;
                        break;

                    case "N":
                        Redisplay = false;
                        break;

                    default:
                        Redisplay = true;
                        Console.WriteLine("Please enter Y or N.");
                        Console.WriteLine("Are you a smoker? (enter Y/N)");
                        Smoker = Console.ReadLine();
                        break;
                }
            }
            return Smoker;
        }

        private static string CaptureExercise(string Exercise)
        {
            bool Redisplay = true;
            int exercise;
            while (Redisplay)
            {
                if (int.TryParse(Exercise, out exercise))
                {
                    Redisplay = false;
                }
                else
                {
                    Redisplay = true;
                    Console.WriteLine("Please enter a whole number");
                    Console.WriteLine("How many hours exercise do you do per week?");
                    Exercise = Console.ReadLine();
                }
            }
            return Exercise;
        }

        private static string CaptureChildren(string Children)
        {
            bool Redisplay = true;

            while (Redisplay)
            {
                Children = Children.ToUpper();
                switch (Children)
                {
                    case "Y":
                        Redisplay = false;
                        break;

                    case "N":
                        Redisplay = false;
                        break;

                    default:
                        Redisplay = true;
                        Console.WriteLine("Please enter Y or N.");
                        Console.WriteLine("Do you have any children? (enter Y/N)");
                        Children = Console.ReadLine();
                        break;
                }
            }
            return Children;
        }
    }

    internal class Client
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string Smoker { get; set; }
        public int HoursOfExercise { get; set; }
        public string Children { get; set; }
    }
}