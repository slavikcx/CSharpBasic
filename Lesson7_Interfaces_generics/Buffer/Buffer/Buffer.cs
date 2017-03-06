using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffer
{
    abstract class Buffer<T> : IBuffer<T>
    {
        public abstract bool isEmpty();
        public abstract bool isFull();
        public abstract T Peek();
        public abstract void Print();
    }
}
