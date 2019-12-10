using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC19
{
    class Program
    {
        class Pos
        {
            public int X, Y;

            public override bool Equals(object obj)
            {
                return obj is Pos pos &&
                       X == pos.X &&
                       Y == pos.Y;
            }

            public override int GetHashCode()
            {
                var hashCode = 1861411795;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                return hashCode;
            }
        }

        static int Gcd(int x, int y) => y == 0 ? x : Gcd(y, x % y);

        static void Main()
        {
            var input =
@".#..#
.....
#####
....#
...##";

            var lines = input.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var asteroids = new List<Pos>();
            for (int y = 0; y < lines.Count(); y++)
            {
                var line = lines[y];
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        asteroids.Add(new Pos { X = x, Y = y });
                    }
                }
            }

            var best = 0;
            var seen = new HashSet<Pos>();
            foreach (var asteroid in asteroids)
            {
                seen.Clear();
                foreach (var other in asteroids)
                {
                    if (other == asteroid) continue;

                    var diffX = asteroid.X - other.X;
                    var diffY = asteroid.Y - other.Y;

                    var gcd = Gcd(Math.Abs(diffX), Math.Abs(diffY));
                    seen.Add(new Pos { X = diffX / gcd, Y = diffY / gcd });
                }

                if (seen.Count > best)
                    best = seen.Count;
            }
            Console.WriteLine(best);
        }
    }
}
