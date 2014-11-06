using System;

namespace ixts.Ausbildung.Rhombs.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var m = int.Parse(args[0]);
            var n = int.Parse(args[1]);

            for (var r = 0; r < n; r++)
            {
                if (r > 0)
                {
                    for (var c = 0; c < m*n + n - 1; c++)
                    {
                        Console.Write('.');
                    }
                    Console.WriteLine();
                }

                for (var l = 0; l < m; l++)
                {
                    for (var c = 0; c < n; c++)
                    {
                        if (c > 0)
                        {
                            Console.Write('.');
                            
                        }

                        var ohs = l <= m/2 ? 2*l + 1 : 2*(m - l) - l;
                        var dots = (m - ohs)/2;
                        for (var i = 0; i < dots; i++)
                        {
                            Console.Write('.');
                        }
                        for (var i = 0; i < ohs; i++)
                        {
                            Console.Write('O');
                        }
                        for (var i = 0; i < dots; i++)
                        {
                            Console.Write('.');
                        }

                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
