using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;


namespace LifeInsurance
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("LIFE INSURANCE QUOTE");

            // Setup new instance of Client
            Client NewClient = new Client();

            // Capture user details.

            // User Age
            Console.WriteLine("What is your date of birth (DD/MM/YYYY)?");
            NewClient.Age = NewClient.CaptureAge(Console.ReadLine());
            Console.WriteLine("");

            //User Gender
            Console.WriteLine("What is your gender? (M/F)");
            NewClient.Gender = NewClient.CaptureGender(Console.ReadLine());
            Console.WriteLine("");

            // Capture postcode and convert to country
            Console.WriteLine("What is your post code?");
            NewClient.Country = Postcode.LookupCountry(Console.ReadLine());
            Console.WriteLine("");

            // Capture smoking details
            Console.WriteLine("Are you a smoker? (enter Y/N)");
            NewClient.Smoker = NewClient.CaptureSmoker(Console.ReadLine());
            Console.WriteLine("");

            // Capture exercise details
            Console.WriteLine("How many hours exercise do you do per week?");
            NewClient.HoursOfExercise = Convert.ToInt32(NewClient.CaptureExercise(Console.ReadLine()));
            Console.WriteLine("");

            // Capture children details
            Console.WriteLine("Do you have any children? (enter Y/N)");
            NewClient.Children = NewClient.CaptureChildren(Console.ReadLine());
            Console.WriteLine("");

            // Calculate Price
            double TotalPremium = Calculation.CalculatePrice(NewClient);

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
                  
    }
}