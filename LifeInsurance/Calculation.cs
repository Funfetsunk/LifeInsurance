using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeInsurance
{
    class Calculation
    {

        public static double CalculatePrice(Client client)
        {
         // Work out base price.
            // Start with male customers.
            double TotalPremium;

            if (client.Gender == "M")
            {
                if (client.Age >= 0 && client.Age <= 18)
                {
                    TotalPremium = 150.00;
                }
                else if (client.Age >= 19 && client.Age <= 24)
                {
                    TotalPremium = 180.00;
                }
                else if (client.Age >= 25 && client.Age <= 35)
                {
                    TotalPremium = 200.00;
                }
                else if (client.Age >= 35 && client.Age <= 45)
                {
                    TotalPremium = 250.00;
                }
                else if (client.Age >= 45 && client.Age <= 60)
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
                if (client.Age >= 0 && client.Age <= 18)
                {
                    TotalPremium = 100.00;
                }
                else if (client.Age >= 19 && client.Age <= 24)
                {
                    TotalPremium = 165.00;
                }
                else if (client.Age >= 25 && client.Age <= 35)
                {
                    TotalPremium = 180.00;
                }
                else if (client.Age >= 35 && client.Age <= 45)
                {
                    TotalPremium = 225.00;
                }
                else if (client.Age >= 45 && client.Age <= 60)
                {
                    TotalPremium = 315.00;
                }
                else
                {
                    TotalPremium = 485.00;
                }
            }

            // Adjust Premium based on "Regional Health Index"
            switch (client.Country)
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

                case "Northern Ireland":
                    TotalPremium = TotalPremium + 75.00;
                    break;

                default:
                    TotalPremium = TotalPremium + 100.00;
                    break;
            }

            // If client has children increase premium by 50%
            if (client.Children == "Y")
            {
                TotalPremium = TotalPremium * 1.5;
            }

            // If client is a smoker increase premium by 300%
            if (client.Smoker == "Y")
            {
                TotalPremium = TotalPremium * 4.0;
            }

            // Adjust premium based on exercise.
            if (client.HoursOfExercise < 1)
            {
                TotalPremium = TotalPremium * 1.2;
            }
            else if (client.HoursOfExercise < 3)
            {
            }
            else if (client.HoursOfExercise < 6)
            {
                double Deduction = TotalPremium * 0.3;
                TotalPremium = TotalPremium - Deduction;
            }
            else if (client.HoursOfExercise < 9)
            {
                double Deduction = TotalPremium * 0.5;
                TotalPremium = TotalPremium - Deduction;
            }
            else if (client.HoursOfExercise >= 9)
            {
                TotalPremium = TotalPremium * 1.5;
            }

            // Check that the final premium is not less then £50, if it is make the premium £50
            if (TotalPremium < 50.00)
            {
                TotalPremium = 50.00;
            }
            return TotalPremium;
        }


        }


}
