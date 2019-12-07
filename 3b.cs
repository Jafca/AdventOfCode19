using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC19
{
    class Program
    {
        public class Step
        {
            public int X;
            public int Y;

            public Step(int x, int y)
            {
                X = x;
                Y = y;
            }

            public override bool Equals(object obj)
            {
                return obj is Step step &&
                       X == step.X &&
                       Y == step.Y;
            }

            public override int GetHashCode()
            {
                var hashCode = 1861411795;
                hashCode = hashCode * -1521134295 + X.GetHashCode();
                hashCode = hashCode * -1521134295 + Y.GetHashCode();
                return hashCode;
            }
        }

        static void Main()
        {
            var s1 = "R8,U5,L5,D3";
            var s2 = "U7,R6,D4,L4";

            var steps1 = AddSteps(s1.Split(','));
            var steps2 = AddSteps(s2.Split(','));

            var steps = steps1.Intersect(steps2).Min(s => steps1.IndexOf(s) + steps2.IndexOf(s) + 2);
            Console.WriteLine(steps);
        }

        public static List<Step> AddSteps(string[] paths)
        {
            var current = new Step(0, 0);
            var steps = new List<Step>();

            foreach (var path in paths)
            {
                var direction = path[0];
                var length = int.Parse(path.Substring(1));

                switch (direction)
                {
                    case 'R':
                        for (int i = 1; i <= length; i++)
                        {
                            steps.Add(new Step(current.X + i, current.Y));
                        }
                        current.X += length;
                        break;
                    case 'L':
                        for (int i = 1; i <= length; i++)
                        {
                            steps.Add(new Step(current.X - i, current.Y));
                        }
                        current.X -= length;
                        break;
                    case 'U':
                        for (int i = 1; i <= length; i++)
                        {
                            steps.Add(new Step(current.X, current.Y + i));
                        }
                        current.Y += length;
                        break;
                    case 'D':
                        for (int i = 1; i <= length; i++)
                        {
                            steps.Add(new Step(current.X, current.Y - i));
                        }
                        current.Y -= length;
                        break;
                }
            }
            return steps;
        }
    }
}
