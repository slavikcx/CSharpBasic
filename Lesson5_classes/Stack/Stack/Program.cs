using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            int value = 0;

            Console.WriteLine("Please enter stack size");
            int stackSize = Convert.ToInt32(Console.ReadLine());



            Stack userStack = new Stack(stackSize);
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
                        if (!userStack.IsFull())
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
                        if (!userStack.IsEmpty())
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
                        if (userStack.IsFull())
                        {
                            Console.WriteLine("Stack is Full");
                        }
                        else
                        {
                            Console.WriteLine("Stack is not Full");
                        }
                        break;

                    case 4:
                        if (userStack.IsEmpty())
                        {
                            Console.WriteLine("Stack is Empty");
                        }
                        else
                        {
                            Console.WriteLine("Stack is not Empty");
                        }
                        break;
                    case 5:

                        if (userStack.IsEmpty())
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
 
    }
}
