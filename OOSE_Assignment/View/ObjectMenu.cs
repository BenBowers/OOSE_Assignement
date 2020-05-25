using System;
using System.Collections.Generic;

namespace OOSE_Assignment.View
{
    public class ObjectMenu<E> : Menu<E> where E : class
    {
        public ObjectMenu(List<E> options) : base(options)
        {
        }

        /**
         * Will return null if no selection is made
         */
        public E Run()
        {
            int selection = GetSelection();
            E returnVal = null;
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
    }
}
