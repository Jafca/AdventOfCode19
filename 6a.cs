using System;
using System.Collections.Generic;

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
K)L";
            var pairs = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var allObs = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                var obs = pair.Split(')');
                if (!allObs.ContainsKey(obs[1]))
                    allObs.Add(obs[1], obs[0]);
            }

            var count = 0;
            foreach (var ob in allObs)
            {
                var parent = ob.Value;
                count++;
                while (parent != "COM")
                {
                    parent = allObs[parent];
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
