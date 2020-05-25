using System;
using System.Collections.Generic;

namespace OOSE_Assignment.View
{

    public abstract class Menu<E> where E : class 
    {

        public const string OUT_OF_RANGE_PROMPT = "Integer out of range";
        public const string ERROR_PROMPT = "Please input a number between {0} and {1}";
        protected List<E> options;


        protected string menuName { get; set; } = "Menu";
        protected string exitPrompt { get; set; } = "Exit";

        public Menu(List<E> options)
        {
            this.options = options;

        }

        public Menu() { }


        /**
         * This retrieves the elements name in the list
         */
        protected abstract string GetName(int ii);

        protected int GetSelection()
        {
            int selection = 0;
            bool validInput = false;

            do
            {
                Console.WriteLine(menuName);
                for (int ii = 1; ii <= options.Count; ii++)
                {
                    Console.WriteLine(ii + ". " + GetName(ii - 1));
                }
                Console.WriteLine(options.Count + 1 + ". " + exitPrompt);
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

            return selection - 1;
        }

        private bool InRange(int number)
        {
            return number > 0 && number <= options.Count   + 1;
        }

        protected bool IsExit(int index)
        {
            return index >= options.Count;
        }

    }
}
