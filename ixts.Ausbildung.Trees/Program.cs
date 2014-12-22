using System;
using System.Linq;

namespace ixts.Ausbildung.Trees
{
    class Program
    {
        static void Main(string[] args)
        {            
            var tree = new Node<string>("A",
                                        new Node<string>("B",
                                                         new Node<string>("C"),
                                                         new Node<string>("D",
                                                                          new Node<string>("E"),
                                                                          new Node<string>("F")),
                                                         new Node<string>("G")),
                                        new Node<string>("H",
                                                         new Node<string>("I"),
                                                         new Node<string>("J",
                                                                          new Node<string>("K")))
                );

            Console.WriteLine("ToString: ");
            Console.WriteLine(tree);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Iterator: ");
            tree.Select(n => n.Data).ToList().ForEach(Console.Write);
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Traverse:");
            tree.Traverse(node => Console.Write(node.Data));
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Height: {0}", tree.Height);

            Console.WriteLine("Subst G -> H:");
            Console.WriteLine(tree.Subst(tree.Children.ElementAt(0).ElementAt(2), tree.Children.ElementAt(1)));

            Console.ReadKey();
        }
    }

    
}
