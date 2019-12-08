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
    }
}
