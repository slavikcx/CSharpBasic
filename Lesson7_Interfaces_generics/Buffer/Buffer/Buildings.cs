using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Interfaces_generics
{
    class Buildings : IComparable
    {
        private string title;
        private int amountOfFloors;

        public Buildings(string Title, int AmountOfFloors)
        {
            title = Title;
            amountOfFloors = AmountOfFloors;
        }
        
        public int CompareTo(object obj)
        {
                Buildings building = obj as Buildings;
                return this.amountOfFloors.CompareTo(building.amountOfFloors);
        }

        public override string ToString()
        {
            return string.Format("Building {0} has {1} floors \n", title, amountOfFloors);
        }

    }
}
