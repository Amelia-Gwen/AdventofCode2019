using System;
using System.Collections.Generic;

namespace AdventofCode2019
{
    internal class OrbitalMapCalculator
    {
        private class Node
        {
            public Node orbitingNode;
            public int numberOfOrbits;
            public string ID;

            public Node(string id)
            {
                orbitingNode = null;
                numberOfOrbits = 0;
                ID = id;
            }

            public Node(Node orbiting, string id)
            {
                orbitingNode = orbiting;
                numberOfOrbits = orbiting.numberOfOrbits + 1;
                ID = id;
            }
        }

        private List<Node> orbitalMap = new List<Node>();

        public void ReadTokens(List<Tuple<string, string>> orbitalPairs)
        {
            string centerOfMass = "COM";
            Node centerNode = new Node(centerOfMass);
            orbitalMap.Add(centerNode);
            Queue<string> centerNames = new Queue<string>();
            centerNames.Enqueue(centerOfMass);

            while (centerNames.Count > 0)
            {
                centerOfMass = centerNames.Dequeue();

                foreach (Node node in orbitalMap)
                {
                    if (node.ID == centerOfMass)
                    {
                        centerNode = node;
                        break;
                    }
                }

                foreach (Tuple<string, string> pair in orbitalPairs)
                {
                    if (centerOfMass == pair.Item1)
                    {
                        orbitalMap.Add(new Node(centerNode, pair.Item2));
                        centerNames.Enqueue(pair.Item2);
                    }
                }
            }
        }

        public int CountOrbits()
        {
            int orbits = 0;
            foreach (Node node in orbitalMap)
            {
                orbits += node.numberOfOrbits;
            }
            return orbits;
        }

        public int DistanceToSanta()
        {
            string yourID = "YOU";
            string santasID = "SAN";
            Node you = null;
            Node santa = null;
            
            foreach (Node node in orbitalMap)
            {
                if (node.ID == yourID)
                {
                    you = node;
                }
                if (node.ID == santasID)
                {
                    santa = node;
                }
            }

            List<Node> youToCenter = new List<Node>();
            List<Node> santaToCenter = new List<Node>();
            AddNodesTilCenter(you, youToCenter);
            AddNodesTilCenter(santa, santaToCenter);
            Node pivotNode = FindPivotNode(youToCenter, santaToCenter);

            int youToPivot = you.numberOfOrbits - pivotNode.numberOfOrbits - 1;
            int santaToPivot = santa.numberOfOrbits - pivotNode.numberOfOrbits - 1;

            return youToPivot + santaToPivot;
        }

        private void AddNodesTilCenter(Node sentinal, List<Node> nodes)
        {
            while (sentinal.orbitingNode != null)
            {
                nodes.Add(sentinal);
                sentinal = sentinal.orbitingNode;
            }
        }

        private Node FindPivotNode(List<Node> lhs, List<Node> rhs)
        {
            foreach (Node leftNode in lhs)
            {
                foreach (Node rightNode in rhs)
                {
                    if (leftNode.ID == rightNode.ID)
                    {
                        return leftNode;
                    }
                }
            }
            return null;
        }
    }
}
