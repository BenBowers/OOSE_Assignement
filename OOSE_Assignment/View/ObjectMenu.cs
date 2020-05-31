using System;
using System.Collections.Generic;

namespace OOSE_Assignment.View
{
    // A generic object menu that will display a list of objects and return the
    // selected one
    public class ObjectMenu<E> : Menu<E>
    {
        public ObjectMenu(List<E> options, string menuName) : base(options, menuName)
        {
        }

        /**
         * Will return null if no selection is made
         */
        public E Run()
        {
            int selection = GetSelection();
            E returnVal = default;
            if(selection < options.Count)
            {
                returnVal = options[selection];
            }
            return returnVal;
        }


        protected override string GetName(int ii)
        {
            return options[ii].ToString();
        }

        public void SetMenuName(string s)
        {
            menuName = s;
        }
    }
}
