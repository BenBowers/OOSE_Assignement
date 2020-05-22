using System;
using System.Collections.Generic;

namespace OOSE_Assignment.View
{
    public abstract class Menu
    {

        public const string OUT_OF_RANGE_PROMPT = "Integer out of range";
        public const string ERROR_PROMPT = "Please input a number between {0} and {1}";
        public List<MenuItem> options;

        public Menu(List<MenuItem> options)
        {
            this.options = options;
        }

        public Menu() { }

        public void Run()
        {
            int selection = 0;
            bool validInput = false;

            do
            {
                for (int ii = 1; ii <= options.Count; ii++)
                {
                    Console.WriteLine(ii + ". " + options[ii - 1].Name);
                }
                try
                {

                    selection = Convert.ToInt32(Console.ReadLine());
                    if (InRange(selection))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine(ERROR_PROMPT, 0, options.Count);
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine(ERROR_PROMPT, 0, options.Count);
                }
                catch (FormatException)
                {
                    Console.WriteLine(ERROR_PROMPT, 0, options.Count);
                }
            } while (!validInput); // Loop until a valid option is selected

            options[selection - 1].Run();
        }

        private bool InRange(int number)
        {
            return number > 0 && number <= options.Count;
        }
    }
}
