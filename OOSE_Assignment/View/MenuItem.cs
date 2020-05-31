namespace OOSE_Assignment.View
{
    public delegate void MenuAction();
    // Class representing the elements in the methodMenu
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
