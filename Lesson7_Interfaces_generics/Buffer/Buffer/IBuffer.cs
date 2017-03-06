using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffer
{
    interface IBuffer<T> : IPrintable
    {
        bool isEmpty();

        bool isFull();

        T Peek();
    }
}
