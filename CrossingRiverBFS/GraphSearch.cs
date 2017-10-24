using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingRiverBFS
{
    class GraphSearch
    {
        public static Path BreadthFirstSearch(Node initial, Node goal)
        {
            bool found;
            Path initialState = new Path(initial, 0);
            Node goalState = goal;
            if (initial.Equals(goal))
            {
                initialState.PathToMe.Add(initial);
                return initialState;
            }

            //defining initial and final states
            List<Path> border = new List<Path>();
            List<Node> explored = new List<Node>();

            //adding initial state to the border
            border.Add(initialState);
            found = false;
            Path currentNode = null; //current node being explored
            while (!found)
            {
                if (border.Count == 0)
                {
                    //if there are no nodes in the border, we haven't found
                    break;
                }

                //removing the node that is currently being explored from the border
                currentNode = border[0];
                border.RemoveAt(0);
                //adding node to the explored set
                explored.Add(currentNode.Node);
                AddNeighbors(currentNode.Node);
                foreach (Neighbor neighbor in currentNode.Node.Neighbors)
                {
                    if (!IsInTheBorder(neighbor.Node, border) && !explored.Contains(neighbor.Node))
                    {
                        //new path created using the current node reached and the cost to reach it
                        Path newPath = new Path(neighbor.Node, currentNode.Cost + neighbor.Cost);

                        //saying that the path to me is the path to my father plus my father itself
                        newPath.PathToMe = currentNode.PathToMe.ToList();
                        newPath.PathToMe.Add(currentNode.Node); ;

                        if (neighbor.Node.Equals(goalState))
                        {
                            currentNode = newPath;
                            //adding the goal node to the path
                            currentNode.PathToMe.Add(currentNode.Node);
                            found = true;
                            break;
                        }
                        border.Add(newPath);
                        //foreach (Path p in border) {
                        //    Console.Write(p.Node+" c:"+p.Cost+"; ");                            
                        //}
                        //Console.WriteLine();
                        //Console.ReadKey();
                    }
                }
            }
            if (found) return currentNode;
            return null;
        }
        //exploring the possible neighbors of a node
        private static void AddNeighbors(Node node)
        {
            bool[] newState;
            //can always move the farmer
            newState = MoveFarmer(node.State);
            //only add it if it is not a dead state
            if (newState != null) node.Neighbors.Add(new Neighbor(new Node(newState), 1));

            //check if farmer and fox are on the same side of the river
            if (node.State[(int)label.FARMER] == node.State[(int)label.FOX]) {
                newState = MoveFarmerFox(node.State);
                //only add it if it is not a dead state
                if (newState != null) node.Neighbors.Add(new Neighbor(new Node(newState), 1));
            }

            //check if farmer and chicken are on the same side of the river
            if (node.State[(int)label.FARMER] == node.State[(int)label.CHICKEN])
            {
                newState = MoveFarmerChicken(node.State);
                //only add it if it is not a dead state
                if (newState != null) node.Neighbors.Add(new Neighbor(new Node(newState), 1));
            }

            //check if farmer and grains are on the same side of the river
            if (node.State[(int)label.FARMER] == node.State[(int)label.GRAINS])
            {
                newState = MoveFarmerGrains(node.State);
                //only add it if it is not a dead state
                if (newState != null) node.Neighbors.Add(new Neighbor(new Node(newState), 1));
            }

        }
        private static bool IsInTheBorder(Node node, List<Path> border)
        {
            foreach (Path path in border)
            {
                if (path.Node.Equals(node)) return true;
            }
            return false;
        }
        public static bool[] MoveFarmer(bool[] state) {
            bool[] newState = null;
            
            newState = state.ToArray();
            newState[(int)label.FARMER] = !newState[(int)label.FARMER]; //changing farmer's side

            if (IsDeadState(newState)) return null;

            return newState;
        }
        public static bool[] MoveFarmerFox(bool[] state)
        {
            bool[] newState = null;

            newState = state.ToArray();
            newState[(int)label.FARMER] = !newState[(int)label.FARMER]; //changing farmer's side
            newState[(int)label.FOX] = !newState[(int)label.FOX]; //changing fox's side

            if (IsDeadState(newState)) return null;

            return newState;
        }
        public static bool[] MoveFarmerChicken(bool[] state)
        {
            bool[] newState = null;

            newState = state.ToArray();
            newState[(int)label.FARMER] = !newState[(int)label.FARMER]; //changing farmer's side
            newState[(int)label.CHICKEN] = !newState[(int)label.CHICKEN]; //changing chicken's side

            if (IsDeadState(newState)) return null;

            return newState;
        }
        public static bool[] MoveFarmerGrains(bool[] state)
        {
            bool[] newState = null;

            newState = state.ToArray();
            newState[(int)label.FARMER] = !newState[(int)label.FARMER]; //changing farmer's side
            newState[(int)label.GRAINS] = !newState[(int)label.GRAINS]; //changing grain's side

            if (IsDeadState(newState)) return null;

            return newState;
        }
        //dead state: state where the game is over
        public static bool IsDeadState(bool[] state)
        {   //checking if the fox is alone with the chicken
            bool foxChicken = (state[(int)label.FOX] && state[(int)label.CHICKEN] && !state[(int)label.FARMER]) ||
                              (!state[(int)label.FOX] && !state[(int)label.CHICKEN] && state[(int)label.FARMER]);
            //checking if the grains are alone with the chicken
            bool chickenGrains = (state[(int)label.GRAINS] && state[(int)label.CHICKEN] && !state[(int)label.FARMER]) ||
                                 (!state[(int)label.GRAINS] && !state[(int)label.CHICKEN] && state[(int)label.FARMER]);

            return (foxChicken || chickenGrains);
        }
    }
}
