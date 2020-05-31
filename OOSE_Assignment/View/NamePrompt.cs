namespace OOSE_Assignment.View
{
    /**
     * Prompt that displays when a name is needed
     */
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
