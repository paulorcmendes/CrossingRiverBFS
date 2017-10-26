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
        public static bool[] ReadState() {
            string[] names = { "Farmer", "Grains", "Chicken", "Fox" };
            bool[] state = new bool[4];
            string aux;

            for (int i = 0; i < 4; i++)
            {
                Console.Write("Side of {0}: ", names[i]);
                aux = Console.ReadLine();
                while (aux != "L" && aux != "R")
                {
                    Console.Beep();
                    Console.WriteLine("Try Again!!!!");
                    Console.Write("Side of Farmer: ");
                    aux = Console.ReadLine();
                }
                state[i] = (aux == "R");
            }

            return state;
        }
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
            Console.WriteLine("Use: L - Left R - Right");
            Console.WriteLine("\nInform values of initial state");
            bool[] init = ReadState();

            while (GraphSearch.IsDeadState(init)) {
                Console.WriteLine("\nInvalid State! Try again");
                Console.WriteLine("\nInform values of initial state");
                init = ReadState();
            }
            
            Console.WriteLine("\nInform values of goal state");
            bool[] goal = ReadState();
            
            Node n1 = new Node(init);
            Node n2 = new Node(goal);

            Console.WriteLine("\n\n########## RESULT ###########\n");
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
