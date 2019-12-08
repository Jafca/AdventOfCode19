using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC19
{
    class Program
    {
        static void Main()
        {
            var input =
@"COM)B
B)C
C)D
D)E
E)F
B)G
G)H
D)I
E)J
J)K
K)L
K)YOU
I)SAN";
            var pairs = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var allObs = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                var obs = pair.Split(')');
                if (!allObs.ContainsKey(obs[1]))
                    allObs.Add(obs[1], obs[0]);
            }

            var parentsYou = new List<string>();
            var parent = allObs["YOU"];
            while (parent != "COM")
            {
                parentsYou.Add(parent);
                parent = allObs[parent];
            }

            var parentsSan = new List<string>();
            parent = allObs["SAN"];
            while (parent != "COM")
            {
                parentsSan.Add(parent);
                parent = allObs[parent];
            }

            var common = parentsYou.Intersect(parentsSan).First();
            Console.WriteLine(parentsYou.IndexOf(common) + parentsSan.IndexOf(common));
        }
    }
}
