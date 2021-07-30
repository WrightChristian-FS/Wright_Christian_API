/*
 * Christian Wright 
 * 30JUL2021
 * APA 
 * 
 * API Application
 * 
 */

using System;
namespace Wright_Christian_API
{
    public class UI
    {
        public UI()
        {
        }

        public static void HeaderUI()
        {
            //This should be used to separate the color of console headers
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void StandardUI()
        {
            //This should be used to set the normal text color to white
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void InputUI()
        {
            //This should be used to set the color of user input to ghost gray 
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }

        public static void ErrorUI()
        {
            //This should be used to present the user with the red error code
            Console.ForegroundColor = ConsoleColor.DarkRed;
        }

        public static void ConfirmUI()
        {
            //This should be used to confirm text with green 
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }
    }
    
}