using System;
namespace OOSE_Assignment.View
{
    public class Prompt
    {
        public string Message;
        public Prompt(string message)
        {
            Message = message;
        }

        protected string Run()
        {
            System.Console.Write(Message + ": ");
            return System.Console.ReadLine();
        }
    }
}
