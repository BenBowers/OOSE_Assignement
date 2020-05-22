namespace OOSE_Assignment.View
{
    public delegate void MenuAction();
    public class MenuItem
    {
        public MenuItem(string name, MenuAction action)
        {
            Name = name;
            Action = action;
        }

        public string Name { get; set; }
        public event MenuAction Action;

        public void Run()
        {
            Action();
        }
    }
}
