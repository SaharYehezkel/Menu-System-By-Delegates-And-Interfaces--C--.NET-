using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class CapitalsAndVersion
    {
        public static void CountCapitals() 
        {
            int capitalsCounter = 0;
            string userInput;

            Console.WriteLine("Enter a string then I'll calculate the capitals:");
            userInput = Console.ReadLine();
            foreach (char letter in userInput)
            {
                if (char.IsUpper(letter))
                {
                    capitalsCounter++;
                }
            }

            Console.WriteLine("Amount of capitals letters is {0}", capitalsCounter);
        }

        public static void ShowVersion()
        {
            Console.WriteLine("Version: 24.1.4.9633");
        }
    }
}
