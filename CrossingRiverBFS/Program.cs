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
            bool[] init = { false, true, false, true };

            Console.WriteLine(Node.ShowState(init));
            //Console.Write(GraphSearch.BreadthFirstSearch(n1, n2));
            Console.ReadKey();
        }        
    }
}
