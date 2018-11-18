using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Program
    {
        static void Main(string[] args)
        {
            //GFunctionalityTest();

            //Console.WriteLine("TESTING OVERLOADED OPERATORS FOR POSITIONS");
            //Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            //Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            //Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            //Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            //Console.WriteLine("TESTING CREATION AND REMOVAL OF POSITIONS IN LIST");
            //SortedPosList list1 = new SortedPosList();
            //SortedPosList list2 = new SortedPosList();
            //list1.Add(new Position(3, 7));
            //list1.Add(new Position(1, 4));
            //list1.Add(new Position(2, 6));
            //list1.Add(new Position(2, 3));
            //Console.WriteLine(list1 + "\n");
            //Console.WriteLine(list1[2]);
            //list1.Remove(new Position(2, 6));
            //Console.WriteLine(list1 + "\n");
            
            //Console.WriteLine("TESTING ADDING CONTENTS OF TWO LISTS");
            //list2.Add(new Position(3, 7));
            //list2.Add(new Position(1, 2));
            //list2.Add(new Position(3, 6));
            //list2.Add(new Position(2, 3));
            //Console.WriteLine((list2 + list1) + "\n");

            /*
            Console.WriteLine("TESTING CLONE");
            SortedPosList c1 = list1.Clone();
            Console.WriteLine("List one:\n" + list1);
            Console.WriteLine("Cloned list:\n" + c1);
            list1.Remove(new Position(2, 3));
            Console.WriteLine("List one after one position removed:\n" + list1);
            Console.WriteLine("Cloned list:\n" + c1);

            Console.WriteLine("TEST: VALUES W/IN CIRCLE");
            SortedPosList list3 = new SortedPosList();
            list3.Add(new Position(1, 1));
            list3.Add(new Position(2, 2));
            list3.Add(new Position(3, 3));
            list3.CircleContent(new Position(5, 5), 4);
            */

            /*
            // VG 1 - Overload -
            // Test: L1 - L2 (Test should show that equal values are removed)
            // L1 = { (3, 7), (1, 4), (2, 6), (2, 3) }
            // L2 = { (3, 7), (1, 2), (3, 6), (2, 3) }
            // Expected results:
            // L1 - L2 = { (1, 4), (2, 6) }
            // L2 - L1 = { (1, 2), (3, 6) }
            Console.WriteLine("\nL1 - L2");
            SortedPosList test1 = new SortedPosList();
            test1.Add(new Position(3, 7));
            test1.Add(new Position(1, 4));
            test1.Add(new Position(2, 6));
            test1.Add(new Position(2, 3));

            SortedPosList test2 = new SortedPosList();
            test2.Add(new Position(3, 7));
            test2.Add(new Position(1, 2));
            test2.Add(new Position(3, 6));
            test2.Add(new Position(2, 3));

            Console.WriteLine($"List1: {test1}");
            Console.WriteLine($"List2: {test2}");
            Console.WriteLine($"Final result L1-L2: {test1 - test2}");
            Console.WriteLine($"Final result L2-L1: {test2 - test1}");
            Console.WriteLine();
            */

            // VG 2 - Write to external text file when list updated -
            /*Console.WriteLine("Create new file");
            SortedPosList fileTest = new SortedPosList("positions.txt");

            Console.WriteLine("Create new list");
            SortedPosList test1 = new SortedPosList();
            test1.Add(new Position(3, 7));
            test1.Add(new Position(1, 4));
            test1.Add(new Position(2, 6));
            test1.Add(new Position(2, 3));

            Console.WriteLine("Add value (6,6)");
            fileTest.Add(new Position(6, 6));

            Console.WriteLine("Add value (1,1)");
            fileTest.Add(new Position(1, 1));*/

            // VG 3 - Load from external text file -
            //SortedPosList loadTest = new SortedPosList("positions.txt");
            //loadTest.Add(new Position(7, 10));
            //loadTest.Add(new Position(1, 6));
            //loadTest.Add(new Position(1, 1));
            //Console.WriteLine($"Positions loaded: {loadTest}");
        }

        // The result of this test is the same as
        // on page 1 of the lab PM.
        public static void GFunctionalityTest()
        {
            Console.WriteLine(new Position(2, 4) + new Position(1, 2) + "\n");
            Console.WriteLine(new Position(2, 4) - new Position(1, 2) + "\n");
            Console.WriteLine(new Position(1, 2) - new Position(3, 6) + "\n");
            Console.WriteLine(new Position(3, 5) % new Position(1, 3) + "\n");

            SortedPosList list1 = new SortedPosList();
            SortedPosList list2 = new SortedPosList();
            list1.Add(new Position(3, 7));
            list1.Add(new Position(1, 4));
            list1.Add(new Position(2, 6));
            list1.Add(new Position(2, 3));
            Console.WriteLine(list1 + "\n");
            list1.Remove(new Position(2, 6));
            Console.WriteLine(list1 + "\n");

            list2.Add(new Position(3, 7));
            list2.Add(new Position(1, 2));
            list2.Add(new Position(3, 6));
            list2.Add(new Position(2, 3));
            Console.WriteLine((list2 + list1) + "\n");

            SortedPosList circleList = new SortedPosList();
            circleList.Add(new Position(1, 1));
            circleList.Add(new Position(2, 2));
            circleList.Add(new Position(3, 3));
            Console.WriteLine(circleList.CircleContent(new Position(5, 5), 4) + "\n");
        }
    }
}
