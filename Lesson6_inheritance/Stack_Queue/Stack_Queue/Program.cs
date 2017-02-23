using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            char choise;

            Console.WriteLine("What do you want to create? Press relevant key.");
            

            do
            {
                Console.WriteLine("To create Stack - <s>. To create Queue - <q>. Exit - <e>");
                choise = Convert.ToChar(Console.ReadLine());


                switch (choise)
                {
                    case 's':
                        StackHandling();
                        break;

                    case 'q':
                        QueueHandling();
                        break;

                    default:
                        Console.WriteLine("Please enter valid keys - <s> or <q>");
                        break;
                }

            } while (choise != 'e');

        }

        static void StackHandling()
        {
            int choice = 0;
            int value = 0;

            Console.WriteLine("Please enter stack size");
            int stackSize = Convert.ToInt32(Console.ReadLine());

            MyStack userStack = new MyStack(stackSize);
            Random rnd = new Random();

            Console.Write("Empty stack created.");

            Console.WriteLine("");

            do
            {

                Console.WriteLine("What do you want to do with stack?");
                Console.WriteLine("1 - Push random value");
                Console.WriteLine("2 - Pop last value");
                Console.WriteLine("3 - Check if stack is Full");
                Console.WriteLine("4 - Check if stack is Empty");
                Console.WriteLine("5 - Peek last value in stack");
                Console.WriteLine("6 - Print stack");
                Console.WriteLine("0 - Exit");

                choice = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        if (!userStack.isFull())
                        {
                            value = rnd.Next(100);
                            userStack.Push(value);
                            userStack.Print();
                        }
                        else
                        {
                            Console.WriteLine("Unable to push value. Stack is Full.");
                        }
                        break;

                    case 2:
                        if (!userStack.isEmpty())
                        {

                            Console.WriteLine("Poped value is {0}", userStack.Pop());
                            userStack.Print();
                        }
                        else
                        {
                            Console.WriteLine("Unable to pop value, Stack is Empty");
                        }
                        break;

                    case 3:
                        if (userStack.isFull())
                        {
                            Console.WriteLine("Stack is Full");
                        }
                        else
                        {
                            Console.WriteLine("Stack is not Full");
                        }
                        break;

                    case 4:
                        if (userStack.isEmpty())
                        {
                            Console.WriteLine("Stack is Empty");
                        }
                        else
                        {
                            Console.WriteLine("Stack is not Empty");
                        }
                        break;
                    case 5:

                        if (userStack.isEmpty())
                        {
                            Console.WriteLine("Unable to Peek value. Array is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Last value in stack is {0}", userStack.Peek());
                        }
                        break;

                    case 6:

                        userStack.Print();
                        break;

                    case 0:

                        break;

                    default:
                        Console.WriteLine("Please enter valid value");
                        break;
                }

            } while (choice != 0);

        }

        static void QueueHandling()
        {
            int choice = 0;
            int value = 0;

            Console.WriteLine("Please enter Queue size");
            int queueSize = Convert.ToInt32(Console.ReadLine());



            MyQueue userQueue = new MyQueue(queueSize);
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
