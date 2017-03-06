using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffer
{
    class MyStack<T> : Buffer<T>, IMyStack<T>
    {
        private T[] stack;
        private int top = -1;

        public MyStack (int size)
        {
            stack = new T[size];
        }

        public override bool isEmpty()
        {
            bool isEmpty = false;

            if (top <= -1)
            {
                isEmpty = true;
            }
            else
            {
                isEmpty = false;
            }

            return isEmpty;
        }

        public override bool isFull()
        {
            bool isFull = false;

            if (top >= stack.Length - 1)
            {
                isFull = true;
            }
            else
            {
                isFull = false;
            }

            return isFull;

        }

        public override T Peek()
        {
            T value;
            value = stack[top];
            return value;
        }

        public T Pop()
        {
            T value;

            value = stack[top];
            top--;

            return value;
        }

        public override void Print()
        {

            for (int i = 0; i <= top; i++)
            {
                Console.Write("{0} ", stack[i]);
            }
            Console.WriteLine("");
        }

        public void Push(T value)
        {
            top++;
            stack[top] = value;
        }
    }
}
