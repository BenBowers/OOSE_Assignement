
using System;
using OOSE_Assignment.View;
namespace OOSE_Assignment.Controller
{
    public class NamePrompt : Prompt
    {
        public const string USER_PROMPT = "Please enter player name";
        public NamePrompt() : base(USER_PROMPT) { }
        public string GetName()
        {
            return Run();
        }
    }
}
