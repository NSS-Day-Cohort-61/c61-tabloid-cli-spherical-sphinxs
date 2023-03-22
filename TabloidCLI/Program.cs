using System;
using System.Collections.Generic;
using System.Drawing;
using TabloidCLI.UserInterfaceManagers;

namespace TabloidCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            // Color Manager
            ColorManager();

            // MainMenuManager implements the IUserInterfaceManager interface
            IUserInterfaceManager ui = new MainMenuManager();
            while (ui != null)
            {
                // Each call to Execute will return the next IUserInterfaceManager we should execute
                // When it returns null, we should exit the program;
                ui = ui.Execute();
            }
        }

        public static void ColorManager()
        {
            Dictionary<int, string> colors = new Dictionary<int, string>
        {
            { 1, "Red" },
            { 2, "Blue" },
            { 3, "Green" }
        };

            Console.WriteLine("What color would you like the terminal to be? :");

            Console.WriteLine(" 0) Normal");
            foreach (KeyValuePair<int, string> color in colors)
            {
                Console.WriteLine($" {color.Key}) {color.Value}");
            }

            string colorChoiceString = Console.ReadLine();

            int colorChoice = 0;

            try
            {
                colorChoice = int.Parse(colorChoiceString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid Selection");
            }


            switch (colorChoice)
            {
                case 0:
                    break;
                case 1:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    break;
                case 2:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    break;
                case 3:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Clear();
                    break;
            }
        }
    }
}
