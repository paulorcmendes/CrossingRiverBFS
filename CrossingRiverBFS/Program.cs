using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossingRiverBFS
{
    public enum label {
        FARMER = 0,
        GRAINS = 1,
        CHICKEN = 2,
        FOX = 3
    }
    class Program
    {
        static void Main(string[] args)
        {
            //each position of the vector represents the side of each item
            /* 0 - farmer
             * 1 - grains
             * 2 - chicken
             * 3 - fox
             * if the value in the position is false, it means it is on the left side of the river
             * if it is true, it is on the right side
             * */
            bool[] init = { false, false, false, false};
            bool[] goal = { true, true, true, true};

            Node n1 = new Node(init);
            Node n2 = new Node(goal);

            //Console.WriteLine(Node.ShowState(init));
            Path path = GraphSearch.BreadthFirstSearch(n1, n2);
            if (path != null)
            {
                Console.WriteLine(path);
            }
            else
            {
                Console.WriteLine("Path not found :(");
            }

            Console.ReadKey();
        }        
    }
}
