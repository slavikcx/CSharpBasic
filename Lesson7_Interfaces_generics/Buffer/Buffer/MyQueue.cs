using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buffer
{
    class MyQueue<T> : Buffer<T>, IMyQueue<T>
    {

        private int head = 0;
        private int tail = 0;
        private int count = 0;

        private T[] queue;

        public MyQueue(int size)
        {
            queue = new T[size];
        }
        
        public T Dequeue()
        {
            T value;

            value = queue[head];

            if (head == queue.Length - 1)
            {
                head = 0;
            }
            else
            {
                head++;
            }

            count--;
            return value;
        }

        public void Enqueue(T value)
        {
            queue[tail] = value;

            if (tail == queue.Length - 1)
            {
                tail = 0;
            }
            else
            {
                tail++;
            }

            count++;
        }

        public override bool isEmpty()
        {
            bool isEmpty = false;
            if (count == 0)
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
            if (count == queue.Length)
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
            value = queue[tail-1];
            return value;
        }

        public override void Print()
        {
            for (int i = head; i < count; i++)
            {
                Console.Write("{0} ", queue[i]);
            }
            Console.WriteLine("");
        }
    }
}
