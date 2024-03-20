using System;


namespace Generics
{
    public enum Side
    {
        Left,
        Right
    }

    interface IDisplay<dType>
    {

    }

    public class NodeItem<dType>
    {
        public dType Item { get; set; }
        public NodeItem<dType> Left { get; set; }
        public NodeItem<dType> Right { get; set; }

        public NodeItem(dType Item)
        {
            this.Item = Item;
            this.Right = null;
            this.Left = null;
        }
    }
    public class BinaryTree<dType>
        where dType : IComparable
    {
        public NodeItem<dType> Root { get; private set; }

        public BinaryTree(dType item)
        {
            Root = new NodeItem<dType>(item);
        }

        public void Add(dType item)
        {
            Root = AddInValidPos(Root, item);
        }

        private NodeItem<dType> AddInValidPos(NodeItem<dType> node, dType item)
        {
            if (node == null)
            {
                node = new NodeItem<dType>(item);
                return node;
            }

            if (item.CompareTo(node.Item) > 0)
                if (node.Right == null) node.Right = new NodeItem<dType>(item);
                else node.Right = AddInValidPos(node.Right, item);

            else if (item.CompareTo(node.Item) < 0)
                if (node.Left == null) node.Left = new NodeItem<dType>(item);
                else node.Left = AddInValidPos(node.Left, item);

            return node;
        }

        public void PrintTree()
        {
            PrintTree(Root, "", null);
        }

        private void PrintTree(NodeItem<dType> startNode, string indentation, Side? side)
        {
            if (startNode != null)
            {
                var nodeSide = side == null ? "+" : side == Side.Left ? "L" : "R";
                Console.WriteLine($"{indentation} [{nodeSide}]- {startNode.Item}");
                indentation += new string(' ', 3);

                PrintTree(startNode.Left, indentation, Side.Left);
                PrintTree(startNode.Right, indentation, Side.Right);
            }
        }
        //ToDo Удаление и поиск
    }
}
