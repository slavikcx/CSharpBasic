using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7_Interfaces_generics
{
    interface ISorter<T> : IPrintable
    {
        void Sort();
    }
}
