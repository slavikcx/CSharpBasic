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
            int choice = 0;
            int value = 0;

            Console.WriteLine("Please enter Queue size");
            int queueSize = Convert.ToInt32(Console.ReadLine());



            Queue userQueue = new Queue(queueSize);
            Random rnd = new Random();

            Console.Write("Empty queue created.");

            Console.WriteLine("");


            do
            {
                Console.WriteLine("1 - Enqueue random value");
                Console.WriteLine("2 - Dequeue value");
                Console.WriteLine("3 - Check if buffer is Full");
                Console.WriteLine("4 - Check if buffer is Empty");
                Console.WriteLine("0 - Exit");

                choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        if (!userQueue.isFull())
                        {
                            value = rnd.Next(100);
                            userQueue.Enqueue(value);
                            userQueue.Print();
                        }
                        else
                        {
                            Console.WriteLine("Unable to Enque new value. Buffer is Full");
                        }
                        break;

                    case 2:
                        if (!userQueue.isEmpty())
                        {
                            Console.WriteLine("Dequeued value is {0}", userQueue.Dequeue());

                        }
                        else
                        {
                            Console.WriteLine("Unable to Dequeue value. Buffer is Empty");
                        }
                        break;

                    case 3:
                        if (userQueue.isFull())
                        {
                            Console.WriteLine("Buffer is Full");
                        }
                        else
                        {
                            Console.WriteLine("Buffer is not Full");
                        }

                        break;

                    case 4:
                        if (userQueue.isEmpty())
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
    }
}
