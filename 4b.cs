using System;
using System.Linq;

namespace AoC19
{
    class Program
    {
        static void Main()
        {
            var count = 0;
            for (int i = 231832; i <= 767346; i++)
            {
                var s = i.ToString().ToList();
                if (i == int.Parse(string.Concat(s.OrderBy(x => x))))
                {
                    for (int j = 0; j < s.Count - 1; j++)
                    {
                        if (s[j] == s[j + 1])
                        {
                            if (s.Count(x => x == s[j]) == 2)
                            {
                                count++;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(count);
        }
    }
}
