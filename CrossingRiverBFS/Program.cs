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
