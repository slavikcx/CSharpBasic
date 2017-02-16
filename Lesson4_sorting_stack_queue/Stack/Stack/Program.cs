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

            int arraySize = 5;
            int top = -1;

            int choice = 0;
            int value = 0;

            int[] array = new int[arraySize]; // creating array
            Random rnd = new Random();

            Console.Write("Empty stack created.");

            Console.WriteLine("");

            do {
                
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
                        if (!IsFull(array, ref top))
                        {
                            value = rnd.Next(100);
                            array = Push(array, value, ref top);
                            Print(array, ref top);
                        }
                        else
                        {
                            Console.WriteLine("Unable to push value. Stack is Full.");
                        }
                        break;

                    case 2:
                        if (!IsEmpty(array, ref top))
                        {
                            Pop(array, ref top);
                            Print(array, ref top);
                        }
                        else
                        {
                            Console.WriteLine("Unable to pop value, Stack is Empty");
                        }
                        break;

                    case 3:
                        if (IsFull(array, ref top))
                        {
                            Console.WriteLine("Stack is Full");
                        } else
                        {
                            Console.WriteLine("Stack is not Full");
                        }
                        break;

                    case 4:
                        if (IsEmpty(array,ref top))
                        {
                            Console.WriteLine("Stack is Empty");
                        } else
                        {
                            Console.WriteLine("Stack is not Empty");
                        }
                        break;
                    case 5:

                        if (IsEmpty(array, ref top))
                        {
                            Console.WriteLine("Unable to Peek value. Array is empty.");
                        } else
                        {
                            Console.WriteLine("Last value in stack is {0}", Peek(array, ref top));
                        }
                        break;

                    case 6:

                        Print(array, ref top);
                        break;

                    case 0:

                        break;
                        
                    default:
                        Console.WriteLine("Please enter valid value");
                        break;
                }

            } while (choice != 0);


            Console.ReadKey();
        }

        static int[] Push(int[] array, int value, ref int top)
        {
                top++;
                array[top] = value;
            
            return array;

        }

        static void Pop(int[] array, ref int top)
        {

            Console.WriteLine("Poped value is {0}", array[top]);
            top--;

        }

        static bool IsEmpty(int[] array, ref int top)
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

        static bool IsFull(int[] array, ref int top)
        {
            bool isFull = false;

            if (top >= array.Length-1)
            {
                isFull = true;
            } else
            {
                isFull = false;
            }

            return isFull;
        }

        static int Peek(int[] array, ref int top)
        {
            int value = 0;


            value = array[top];

            return value;
        }

        //Array printing method
        static void Print(int[] array, ref int top)
        {
            
            for (int i=0; i <= top; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine("");
        }
    }
}
