using System;
namespace Wright_Christian_API
{
    public class Validation
    {
        public Validation()
        {
        }

        public static string StringValidation(string userInput)
        {
            while (string.IsNullOrWhiteSpace(userInput))
            {
                //State the problem
                Console.WriteLine("\r\nSorry, this can not be blank or empty");

                //Repeat the problem
                Console.Write("\r\nPlease enter a valid entry: ");

                //Capture the answer
                UI.InputUI(); 
                userInput = Console.ReadLine();
                UI.StandardUI(); 
            }

            return userInput; 
        }

        public static int IntegerValidation(string userInput)
        {
            int convertedInput;

            while (!(int.TryParse(userInput, out convertedInput)))
            {
                //State the problem
                Console.WriteLine("\r\nSorry that is not a valid positive number!");

                //Repeat the question
                Console.Write("\r\nPlease enter a number: ");

                //Capture the answer
                UI.InputUI();
                userInput = Console.ReadLine();
                UI.StandardUI(); 
            }

            return convertedInput; 
        }
    }
}
