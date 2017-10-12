using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingRiverBFS
{
	//Class Node
    class Node
    {
        private List<Neighbor> neighbors;
        private bool[] state;

        public Node(bool[] state)
        {
            this.State = state;
            this.neighbors = new List<Neighbor>();
        }
        public bool[] State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
            }
        }
        public List<Neighbor> Neighbors
        {
            get
            {
                return this.neighbors;
            }
        }
        public string ShowState(bool[] s)
        {
            if (s == null) return null;
            string msg0 = "";
            string msg1 = "";

            if (s[(int)label.FARMER]) msg1 += label.FARMER.ToString() + " ";
            else msg0 += label.FARMER.ToString() + " ";

            if (s[(int)label.GRAINS]) msg1 += label.GRAINS.ToString() + " ";
            else msg0 += label.GRAINS.ToString() + " ";

            if (s[(int)label.CHICKEN]) msg1 += label.CHICKEN.ToString() + " ";
            else msg0 += label.CHICKEN.ToString() + " ";

            if (s[(int)label.FOX]) msg1 += label.FOX.ToString() + " ";
            else msg0 += label.FOX.ToString() + " ";
            
            return msg0 + " | " + msg1;
        }
        public override String ToString()
        {
            return ShowState(this.State);
        }
        public override bool Equals(object obj)
        {
            return State.SequenceEqual(((Node)obj).State);
        }
    }
}
