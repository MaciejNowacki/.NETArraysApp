using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayClass array = new ArrayClass();
            array.printArray();
            array.add(1);
            array.printArray();
            array.add(2);
            array.printArray();
            array.add(3);
            array.printArray();
            Console.WriteLine(array.getElement(2));
            array.setElement(2, 4);
            array.printArray();
            array.setElement(10, 4);
            array.printArray();
            array.add(3);
            array.printArray();
            Console.ReadLine();
        }
    }
}
