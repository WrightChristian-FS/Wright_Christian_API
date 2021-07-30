/*
 * Christian Wright 
 * 30JUL2021
 * APA 
 * 
 * API Application
 * 
 */

using System;
using System.Collections.Generic;

namespace Wright_Christian_API
{
    public class Menu
    {
        //Fields
        private static string _title;
        private static Dictionary<string, string> _menuItems = new Dictionary<string, string>();
        private static string _type = "ID"; 

        public static void Init(string title, Dictionary<string,string> menuItems)
        {
            _title = title;
            _menuItems = menuItems;

        }

        public static void Display()
        {
            Console.Clear();
            //Header
            UI.HeaderUI();
            Console.WriteLine("==========================");
            Console.WriteLine($"   {_title}");
            Console.WriteLine("==========================\r\n");
            UI.StandardUI();

            UI.InputUI(); 
            Console.WriteLine($"{_type,-10} {_title}\r\n");
            UI.StandardUI(); 

            //Print the menu options 
            foreach(KeyValuePair<string, string> item in _menuItems)
            {
                Console.WriteLine($"{item.Key, -10} {item.Value}");
            }

            Console.WriteLine($"\r\nEnter EXIT to exit the program");

        }
    }
}
