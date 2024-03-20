using System;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var intTree = new BinaryTree<int>(10);
            intTree.Add(1);
            intTree.Add(20);
            intTree.Add(0);
            intTree.Add(12);

            intTree.PrintTree();
        }
    }
}
