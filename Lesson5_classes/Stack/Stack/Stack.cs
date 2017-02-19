using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Stack
    {
        
        private int[] stack;
        private int top = -1;



        public Stack (int size)
        {
            stack = new int[size];
        }

        public int Pop()
        {
            int value = 0;

            Console.WriteLine("Poped value is {0}", stack[top]);
            top--;

            return value;
        }

        public void Push(int value)
        {
            top++;
            stack[top] = value;

            
        }

        public bool IsEmpty()
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

        public bool IsFull()
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

        public int Peek ()
        {
            int value = 0;
            value = stack[top];
            return value;
        }

        public void Print()
        {

            for (int i = 0; i <= top; i++)
            {
                Console.Write("{0} ", stack[i]);
            }
            Console.WriteLine("");
        }
    }
}
