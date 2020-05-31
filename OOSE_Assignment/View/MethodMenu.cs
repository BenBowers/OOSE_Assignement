using System;
using System.Collections.Generic;

namespace OOSE_Assignment.View
{
    public class MethodMenu : Menu<MenuItem>
    {
        protected MenuAction exit { get; set; }

        public MethodMenu()
        {
        }

        public virtual void Run()
        {
            int selection = GetSelection();
            if(IsExit(selection))
            {
                exit();
            }
            else
            {
                options[selection].Run();
            }
        }

        protected override string GetName(int ii)
        {
            return options[ii].Name;
        }


    }
}
