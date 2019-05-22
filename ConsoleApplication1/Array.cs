using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public delegate void MyDelegate(int sizeOfArray);
    public class ArrayClass
    {
        private MyDelegate m_oMyDelegate = null;
        private int[] num = new int[1];
        private int index = 0;

        public ArrayClass()
        {
            m_oMyDelegate += displaySizeOfArray;
        }

        public void displaySizeOfArray(int sizeOfArray)
        {
            Console.WriteLine("Rozmiar tablicy: " + sizeOfArray);
        }

        public void add(int value)
        {
            if (index < num.Length)
            {
                num[index++] = value;
            }
            else
            {
                resizeArrayTo(2 * num.Length);
                num[index++] = value;
            }
            m_oMyDelegate(num.Length);
        }

        public void resizeArrayTo(int newSize)
        {
            int[] tmp = new int[num.Length];
            Array.Copy(num, tmp, index);
            num = new int[newSize];
            Array.Copy(tmp, num, index);
            m_oMyDelegate(num.Length);
        }


        public int getElement(int i)
        {
            if (i >= index) //moze num.Length? Czy mamy pobierac obszar zarezerwowany wartosciami domyslnymi, czy jedynie ten nadpisany przez nas?
            {
                throw new System.ArgumentException("Index poza zakresem!");
            }
            return num[i];
        }

        public void setElement(int i, int value)
        {
            if (num.Length < i)
            {
                resizeArrayTo(i + 1);
            }
            num[i] = value;
            index = i + 1;
        }

        public void printArray()
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
