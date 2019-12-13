using System;
using System.Collections.Generic;

namespace AoC19
{
    class Program
    {
        class Val
        {
            public int X = 0;
            public int Y = 0;
            public int Z = 0;
        }

        class Moon
        {
            public Val Pos;
            public Val Vel;
        }

        static void Main(string[] args)
        {
            var moons = new List<Moon>
            {
                new Moon
                {
                    Pos = new Val
                    {
                        X = -1,
                        Y = 0,
                        Z = 2
                    },
                    Vel = new Val()
                },
                new Moon
                {
                    Pos = new Val
                    {
                        X = 2,
                        Y = -10,
                        Z = -7
                    },
                    Vel = new Val()
                },
                new Moon
                {
                    Pos = new Val
                    {
                        X = 4,
                        Y = -8,
                        Z = 8
                    },
                    Vel = new Val()
                },
                new Moon
                {
                    Pos = new Val
                    {
                        X = 3,
                        Y = 5,
                        Z = -1
                    },
                    Vel = new Val()
                }
            };

            var steps = 0;
            while (steps < 10)
            {
                CalcVel(moons[0], moons[1]);
                CalcVel(moons[0], moons[2]);
                CalcVel(moons[0], moons[3]);
                CalcVel(moons[1], moons[2]);
                CalcVel(moons[1], moons[3]);
                CalcVel(moons[2], moons[3]);
                steps++;

                foreach (var moon in moons)
                {
                    moon.Pos.X += moon.Vel.X;
                    moon.Pos.Y += moon.Vel.Y;
                    moon.Pos.Z += moon.Vel.Z;
                }
            }

            var energy = 0;
            foreach (var moon in moons)
            {
                energy += (Math.Abs(moon.Pos.X) + Math.Abs(moon.Pos.Y) + Math.Abs(moon.Pos.Z))
                        * (Math.Abs(moon.Vel.X) + Math.Abs(moon.Vel.Y) + Math.Abs(moon.Vel.Z));
            }
            Console.WriteLine(energy);
        }

        static void CalcVel(Moon moon, Moon other)
        {
            var dir = 0;
            if (moon.Pos.X > other.Pos.X)
                dir = -1;
            else if (moon.Pos.X < other.Pos.X)
                dir = 1;

            moon.Vel.X += dir;
            other.Vel.X -= dir;

            dir = 0;
            if (moon.Pos.Y > other.Pos.Y)
                dir = -1;
            else if (moon.Pos.Y < other.Pos.Y)
                dir = 1;

            moon.Vel.Y += dir;
            other.Vel.Y -= dir;

            dir = 0;
            if (moon.Pos.Z > other.Pos.Z)
                dir = -1;
            else if (moon.Pos.Z < other.Pos.Z)
                dir = 1;

            moon.Vel.Z += dir;
            other.Vel.Z -= dir;
        }
    }
}
