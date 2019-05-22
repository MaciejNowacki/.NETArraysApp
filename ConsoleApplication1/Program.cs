using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public delegate void MyDelegate(int sizeOfArray);
    class Program
    {
        private static MyDelegate m_oMyDelegate = null;
        private static int[] num = new int[1];
        private static int index = 0;
        
        static void Main(string[] args)
        {
            m_oMyDelegate += displaySizeOfArray;
            m_oMyDelegate(num.Length);
            printArray();
            add(1);
            m_oMyDelegate(num.Length);
            printArray();
            add(2);
            m_oMyDelegate(num.Length);
            printArray();
            add(3);
            m_oMyDelegate(num.Length);
            printArray();
            Console.WriteLine(getElement(2));
            setElement(2, 4);
            m_oMyDelegate(num.Length);
            printArray();
            setElement(10, 4);
            m_oMyDelegate(num.Length);
            printArray();
            add(3);
            m_oMyDelegate(num.Length);
            printArray();
            Console.ReadLine();
        }

        static void displaySizeOfArray(int sizeOfArray)
        {
            Console.WriteLine("Rozmiar tablicy: " + sizeOfArray);
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
