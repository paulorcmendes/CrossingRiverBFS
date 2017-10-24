using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingRiverBFS
{
    //Developed by Paulo Renato Conceição Mendes
    //Based on professor Bruno Feres' slides
    //more info: https://github.com/paulorcmendes/CrossingRiverBFS
    //based also on my implementation of the Romanian cities: https://github.com/paulorcmendes/GraphSearchAlgorithms
    public enum CATEGORY{BREADTH_FIRST, UNIFORM_COST, A_STAR}
    class Path : Neighbor, IComparable<Path>
    {
        private List<Node> pathToMe; //all the path to reach me
        private CATEGORY myCategory; //category of search
        public Path(Node node, int cost) : base(node, cost)
        {
            pathToMe = new List<Node>();
            MyCategory = CATEGORY.BREADTH_FIRST;
        }
        public Path(Node node, int cost, CATEGORY myCategory) : base(node, cost)
        {
            pathToMe = new List<Node>();
            MyCategory = myCategory;
        }

        public List<Node> PathToMe 
        {
            get
            {
                return pathToMe;
            }
            set
            {
                pathToMe = value;
            }
        }
        public CATEGORY MyCategory
        {
            get
            {
                return myCategory;
            }
            set
            {
                myCategory = value;
            }
        }

        private string PathToString(List<Node> path)
        {
            string msg = "";
            foreach (Node node in path)
            {
                msg += node+"\n\n";
            }
            return msg;
        }

        public override string ToString()
        {
            return PathToString(PathToMe) + " with cost: " + base.Cost;
        }

        public int CompareTo(Path other)
        {   
            return Cost.CompareTo(other.Cost);
        }
    }
}
