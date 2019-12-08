using System;
using System.Linq;

namespace AoC19
{
    class Program
    {
        static void Main()
        {
            int c = 3 * 2;
            var s = "123456789012";
            var l = Enumerable.Range(0, s.Length / c).Select(i => s.Substring(i * c, c));
            var z = l.OrderBy(x => x.Count(y => y == '0')).First();
            Console.WriteLine(z.Count(x => x == '1') * z.Count(x => x == '2'));
        }
    }
}
