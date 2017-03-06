using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson7_Interfaces_generics;


namespace Buffer
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
            int counter = 1;

            Console.WriteLine("Please enter stack size");
            int stackSize = Convert.ToInt32(Console.ReadLine());

            Random rnd = new Random();

            MyStack<Buildings> stackOfBuildings = new MyStack<Buildings>(stackSize);

            Console.Write("Empty stack of Buildings created.");

            Console.WriteLine("");

            do
            {

                Console.WriteLine("What do you want to do with stack?");
                Console.WriteLine("1 - Push new Building");
                Console.WriteLine("2 - Pop last Building");
                Console.WriteLine("3 - Check if stack is Full");
                Console.WriteLine("4 - Check if stack is Empty");
                Console.WriteLine("5 - Peek last Building in stack");
                Console.WriteLine("6 - Print all Buildings");
                Console.WriteLine("0 - Exit");

                choice = Convert.ToInt16(Console.ReadLine());

                Console.WriteLine("");
                switch (choice)
                {
                    case 1:
                        if (!stackOfBuildings.isFull())
                        {
                            string title = "B-" + counter;
                            counter ++;
                            
                            int floors = rnd.Next(100);
                            Buildings building = new Buildings(title, floors);

                            stackOfBuildings.Push(building);
                            stackOfBuildings.Print();
                            
                        }
                        else
                        {
                            Console.WriteLine("Unable to push new building. Stack is Full.");
                        }
                        break;

                    case 2:
                        if (!stackOfBuildings.isEmpty())
                        {

                            Console.WriteLine("Poped building - {0}", stackOfBuildings.Pop());
                            counter--;
                            stackOfBuildings.Print();
                        }
                        else
                        {
                            Console.WriteLine("Unable to pop building. Stack is Empty");
                        }
                        break;

                    case 3:
                        if (stackOfBuildings.isFull())
                        {
                            Console.WriteLine("Stack is Full");
                        }
                        else
                        {
                            Console.WriteLine("Stack is not Full");
                        }
                        break;

                    case 4:
                        if (stackOfBuildings.isEmpty())
                        {
                            Console.WriteLine("Stack is Empty");
                        }
                        else
                        {
                            Console.WriteLine("Stack is not Empty");
                        }
                        break;
                    case 5:

                        if (stackOfBuildings.isEmpty())
                        {
                            Console.WriteLine("Unable to Peek building. Array is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Last building in stack - {0}", stackOfBuildings.Peek());
                        }
                        break;

                    case 6:

                        stackOfBuildings.Print();
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
            int counter = 1;
            
            Console.WriteLine("Please enter Queue size");
            int queueSize = Convert.ToInt32(Console.ReadLine());

            MyQueue<Buildings> queueOfBuildings = new MyQueue<Buildings>(queueSize);

            Random rnd = new Random();

            Console.Write("Empty queue created.");

            Console.WriteLine("");
            
            do
            {
                Console.WriteLine("1 - Enqueue random value");
                Console.WriteLine("2 - Dequeue value");
                Console.WriteLine("3 - Check if buffer is Full");
                Console.WriteLine("4 - Check if buffer is Empty");
                Console.WriteLine("5 - Peek last value in queue");
                Console.WriteLine("0 - Exit");

                choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        if (!queueOfBuildings.isFull())
                        {
                            string title = "B-" + counter;
                            counter++;

                            int floors = rnd.Next(100);
                            Buildings building = new Buildings(title, floors);

                            queueOfBuildings.Enqueue(building);
                            queueOfBuildings.Print();
                            
                        }
                        else
                        {
                            Console.WriteLine("Unable to Enque new building. Buffer is Full");
                        }
                        break;

                    case 2:
                        if (!queueOfBuildings.isEmpty())
                        {
                            Console.WriteLine("Dequeued building is {0}", queueOfBuildings.Dequeue());

                        }
                        else
                        {
                            Console.WriteLine("Unable to Dequeue building. Buffer is Empty");
                        }
                        break;

                    case 3:
                        if (queueOfBuildings.isFull())
                        {
                            Console.WriteLine("Buffer is Full");
                        }
                        else
                        {
                            Console.WriteLine("Buffer is not Full");
                        }

                        break;

                    case 4:
                        if (queueOfBuildings.isEmpty())
                        {
                            Console.WriteLine("Buffer is Empty");
                        }
                        else
                        {
                            Console.WriteLine("Buffer is not Empty");
                        }

                        break;
                    case 5:

                        if (queueOfBuildings.isEmpty())
                        {
                            Console.WriteLine("Unable to Peek building. Array is empty.");
                        }
                        else
                        {
                            Console.WriteLine("Last building in queue - {0}", queueOfBuildings.Peek());
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

