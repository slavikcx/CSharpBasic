using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    class MyStack : Buffer
    {
        private int[] stack;
        private int top = -1;

        public MyStack(int size) : base(size)
        {
            stack = new int[size];
        }

        public void Push(int value)
        {
            top++;
            stack[top] = value;
        }

        public int Pop()
        {
            int value = 0;

            value = stack[top];
            top--;

            return value;
        }

        public int Peek()
        {
            int value = 0;
            value = stack[top];
            return value;
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
      
        public override void Print()
        {

            for (int i = 0; i <= top; i++)
            {
                Console.Write("{0} ", stack[i]);
            }
            Console.WriteLine("");
        }
    }
}
