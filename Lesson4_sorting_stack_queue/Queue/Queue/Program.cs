using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] circArray = new int[5];

            int head = 0;
            int tail = 0;
            int count = 0;
            int choice = 0;
            int value = 0;

            Random rnd = new Random();

            Console.WriteLine("Empty circle buffer created.");

            do
            {
                Console.WriteLine("1 - Enqueue random value");
                Console.WriteLine("2 - Dequeue value");
                Console.WriteLine("3 - Check if buffer is Full");
                Console.WriteLine("4 - Check if buffer is Empty");
                Console.WriteLine("0 - Exit");

                choice = Convert.ToInt16(Console.ReadLine());

                switch(choice)
                {
                    case 1:

                        if(!isFull(circArray, count))
                        {
                            value = rnd.Next(100);
                            Enqueue(circArray, value, ref tail, ref count);
                            Print(circArray, head, tail, count);
                        }else
                        {
                            Console.WriteLine("Unable to Enque new value. Buffer is Full");
                        }
                        break;

                    case 2:
                        if (!isEmpty(count))
                        {
                            Dequeue(circArray, ref head, ref count);

                        }else
                        {
                            Console.WriteLine("Unable to Dequeue value. Buffer is Empty");
                        }
                        break;

                    case 3:
                        if (isFull(circArray, count))
                        {
                            Console.WriteLine("Buffer is Full");
                        }
                        else
                        {
                            Console.WriteLine("Buffer is not Full");
                        }

                        break;

                    case 4:
                        if (isEmpty(count))
                        {
                            Console.WriteLine("Buffer is Empty");
                        }
                        else
                        {
                            Console.WriteLine("Buffer is not Empty");
                        }

                        break;

                    case 0:

                        break;

                    default:
                        Console.WriteLine("Please press valid key");
                        break;

                }



            } while (choice != 0);

        }

        static int[] Enqueue(int[] array, int value, ref int tail, ref int count)
        {
            array[tail] = value;

            if (tail == array.Length-1)
            {
                tail = 0;
            } else
            {
                tail++;
            }
            
            count++;
            return array;
        }

        static int[] Dequeue(int[] array, ref int head, ref int count)
        {
            Console.WriteLine("Dequeued value is {0}", array[head]);

            if (head == array.Length - 1)
            {
                head = 0;
            }
            else
            {
                head++;
            }

            
            count--;
            return array;

        }

        static bool isFull(int[] array, int count)
        {
            bool isFull = false;
            if (count == array.Length)
            {
                isFull = true;
            } else
            {
                isFull = false;
            }

            return isFull;
        }

        static bool isEmpty(int count)
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

        static void Print (int[] array, int head, int tail, int count)
        {
          
            for (int i = head; i< count; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine("");
        }
    }
}
