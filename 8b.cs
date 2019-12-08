using System;
using System.Linq;

namespace AoC19
{
    class Program
    {
        static void Main()
        {
            var w = 2;
            int c = w * 2;
            var s = "0222112222120000";
            var l = Enumerable.Range(0, s.Length / c).Select(i => s.Substring(i * c, c));
            var f = "";
            for (int i = 0; i < c; i++)
            {
                foreach (var b in l)
                {
                    if (b[i] == '2')
                        continue;
                    else
                    {
                        if (b[i] == '0')
                            f += '0';
                        else if (b[i] == '1')
                            f += '1';

                        break;
                    }
                }
            }
            var a = Enumerable.Range(0, f.Length / w).Select(i => f.Substring(i * w, w));
            foreach (var r in a)
            {
                foreach (var n in r)
                {
                    if (n == '0')
                        Console.Write(' ');
                    else
                        Console.Write('■');
                }
                Console.WriteLine();
            }
        }
    }
}
