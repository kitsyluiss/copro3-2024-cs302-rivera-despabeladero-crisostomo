using System;
using System.Text.RegularExpressions;

namespace CookingSystem
{
    public abstract class Customization 
    {
        public abstract void Customize();
        
        public string ChooseUser(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Validator.GetValidatedUser();
            return input;
        }


        public string ChooseOption(string prompt, Dictionary<int, string> options)
        {
            Console.WriteLine("\n" + prompt);
            foreach (var option in options)
            {
                Console.WriteLine("[" + option.Key + "] " + option.Value);
            }

            int choice = Validator.GetValidatedInput(1, options.Count);
            return options[choice];
        }

        public Dictionary<string, int> AllocatePoints(string prompt, Dictionary<int, string> options, int maxPoints)
        {
            Console.WriteLine("\n" + prompt);
            Console.WriteLine("You have " + maxPoints + " points to allocate.");
            Console.WriteLine("Distribute points among the following options:");

            foreach (var option in options)
            {
                Console.WriteLine("[" + option.Key + "] " + option.Value);
            }

            var allocations = new Dictionary<string, int>();
            int remainingPoints = maxPoints;

            while (remainingPoints > 0)
            {
                Console.WriteLine("\nRemaining points: " + remainingPoints);
                Console.Write("Enter the option number to allocate points: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && options.ContainsKey(choice))
                {
                    Console.Write("Enter points to allocate to " + options[choice] + ": ");
                    if (int.TryParse(Console.ReadLine(), out int points) && points > 0 && points <= remainingPoints)
                    {
                        string optionName = options[choice];
                        if (!allocations.ContainsKey(optionName))
                        {
                            allocations[optionName] = 0;
                        }

                        allocations[optionName] += points;
                        remainingPoints -= points;
                    }
                    else
                    {
                        Console.WriteLine("Invalid point value. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                }
            }

            return allocations;
        }


        public bool ChooseFlag(string prompt, Dictionary<int, bool> options)
        {
            Console.WriteLine("\n" + prompt);
            foreach (var option in options)
            {
                Console.WriteLine("[" + option.Key + "] " + (option.Value ? "Yes" : "No"));
            }

            int choice = Validator.GetValidatedInput(1, options.Count);
            return options[choice];
        }
        public bool ChooseFlag(string prompt, Dictionary<int, bool> options, bool defaultValue)
        {
            Console.WriteLine("\n" + prompt);
            foreach (var option in options)
            {
                Console.WriteLine("[" + option.Key + "] " + (option.Value ? "Yes" : "No"));
            }
            Console.WriteLine("Press enter to skip. " + (defaultValue ? "Yes" : "No"));

            string userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput))
            {
                return defaultValue;
            }

            int choice;
            if (int.TryParse(userInput, out choice) && options.ContainsKey(choice))
            {
                return options[choice];
            }
            else
            {
                Console.WriteLine("Invalid input. Default option selected.");
                return defaultValue;
            }
        }
    }
}
