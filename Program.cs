using System;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CookingSystem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CharacterCustomization characterCustomization = new CharacterCustomization();
            GameMenu game = new GameMenu();

            bool gameRunning = false;

            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

            while (!gameRunning)
            {
                ScaleTextToConsole();
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1);

                Console.WriteLine("Please select an option: ");
                Console.WriteLine("[1] Sharpen Your Knives (New Game)");
                Console.WriteLine("[2] Reheat the Leftovers (Load Game)");
                Console.WriteLine("[3] Whisk Into Action (Campaign Mode)");
                Console.WriteLine("[4] Meet the Master Chefs (Credits)");
                Console.WriteLine("[5] Close the Kitchen (Exit)");

                int userChoice = 0;
                bool validChoice = false;

                while (!validChoice)
                {
                    try
                    {
                        userChoice = Convert.ToInt32(Console.ReadLine());
                        if (userChoice >= 1 && userChoice <= 5)
                        {
                            validChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice, please choose a number between 1 and 5.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                    }
                }

                switch (userChoice)
                {
                    case 1:
                        game.CreateCharacter();
                        break;
                    case 2:
                        game.LoadGame();
                        break;
                    case 3:
                        game.CampaignMode();
                        break;
                    case 4:
                        game.Credits();
                        break;
                    case 5:
                        game.Exit();
                        gameRunning  = true;
                        return;
                }

                Console.WriteLine("Go back to main menu?\n[1] Yes\n[2] No(Exit Game)");
                int userChoice2 = 0;
                validChoice = false;

                while (!validChoice)
                {
                    try
                    {
                        userChoice2 = Convert.ToInt32(Console.ReadLine());
                        if (userChoice2 == 1 || userChoice2 == 2)
                        {
                            validChoice = true;
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice, please choose 1 or 2.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid number.");
                    }
                }

                if (userChoice2 == 2)
                {
                    gameRunning = true;
                    Console.WriteLine("Exiting game...");
                }
            }
        }

        static void ScaleTextToConsole()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            int consoleWidth = Console.WindowWidth;

            string decorativeLine = new string('═', consoleWidth - 1);

            Console.WriteLine(decorativeLine);

            string[] menuText = new string[]
            {
            "       I Was Just a Home Cook, but Now I’m in a   ",
            "     Shokugeki Battleground Where the Fate of the  ",
            "           World Rests on My Signature Dish!       "
            };

            foreach (var line in menuText)
            {
                string scaledLine = ScaleTextToWidth(line, consoleWidth);
                Console.WriteLine(scaledLine);
            }

            Console.WriteLine(decorativeLine);
        }

        static string ScaleTextToWidth(string text, int width)
        {
            text = text.Trim();

            if (text.Length >= width)
            {
                return text.Substring(0, width);
            }

            int totalPadding = width - text.Length;
            int paddingLeft = totalPadding / 2;
            int paddingRight = totalPadding - paddingLeft;

            return new string(' ', paddingLeft) + text + new string(' ', paddingRight);
        }
    }
}
