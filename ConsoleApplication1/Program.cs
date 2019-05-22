using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        private static int[] num = new int[1];
        private static int index = 0;
        
        static void Main(string[] args)
        {      
            Console.WriteLine("Rozmiar: "+num.Length);
            printArray();
            add(1);
            Console.WriteLine("Rozmiar: " + num.Length);
            printArray();
            add(2);
            Console.WriteLine("Rozmiar: " + num.Length);
            printArray();
            add(3);
            Console.WriteLine("Rozmiar: " + num.Length);
            printArray();
            Console.WriteLine(getElement(2));
            setElement(2, 4);
            Console.WriteLine("Rozmiar: " + num.Length);
            printArray();
            setElement(10, 4);
            Console.WriteLine("Rozmiar: " + num.Length);
            printArray();
            add(3);
            Console.WriteLine("Rozmiar: " + num.Length);
            printArray();
            Console.ReadLine();
        }

        static void add(int value)
        {
            if(index < num.Length)
            {
                num[index++] = value;
            }
            else
            {
                resizeArrayTo(2*num.Length);
                num[index++] = value;
            }
        }

        static void resizeArrayTo(int newSize)
        {
            int[] tmp = new int[num.Length];
            Array.Copy(num, tmp, index);
            num = new int[newSize];
            Array.Copy(tmp, num, index);
        }


        static int getElement(int i)
        {
            if (i >= index) //moze num.Length? Czy mamy pobierac obszar zarezerwowany wartosciami domyslnymi, czy jedynie ten nadpisany przez nas?
            {
                throw new System.ArgumentException("Index poza zakresem!");
            }
            return num[i];
        }

        static void setElement(int i, int value)
        {
            if(num.Length < i)
            {
                resizeArrayTo(i + 1);
            }
            num[i] = value;
            index = i + 1;
        }

        static void printArray()
        {
            Console.WriteLine("-------- [START] -------");
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(num[i]);
            }
            Console.WriteLine("--------- [STOP] -------");
        }
    }
}
