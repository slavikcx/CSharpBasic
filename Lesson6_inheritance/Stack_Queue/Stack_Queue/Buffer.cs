using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    class Buffer
    {

        public Buffer (int size)
        {

        }

        public virtual bool isEmpty()
        {
            return false;
        }

        public virtual bool isFull()
        {
            return false;
        }

        public virtual void Print()
        {

        }

    }
}
