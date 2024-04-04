using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeLibrary
{
    public class OptoTree
    {
        public OptoTreeNode Root { get; private set; }

        public OptoTree(OptoTreeNode root)
        {
            Root = root;
        }

        // Добавляет узел к дереву относительно родителя
        public void AddNode(OptoTreeNode parentNode, OptoTreeNode newNode)
        {
            if (parentNode != null)
            {
                parentNode.AddChild(newNode);
            }
            else
            {
                // Если parentNode == null, можно рассматривать newNode как новый корень,
                // или обработать эту ситуацию по-другому в зависимости от требований к логике дерева
            }
        }

        // Удаляет узел и все его поддерево
        public bool RemoveNode(OptoTreeNode nodeToRemove)
        {
            if (Root == nodeToRemove)
            {
                Root = null;
                return true;
            }

            return RemoveNodeRecursive(Root, nodeToRemove);
        }

        private bool RemoveNodeRecursive(OptoTreeNode currentNode, OptoTreeNode nodeToRemove)
        {
            foreach (var child in currentNode.Children)
            {
                if (child == nodeToRemove || RemoveNodeRecursive(child, nodeToRemove))
                {
                    currentNode.RemoveChild(child);
                    return true;
                }
            }
            return false;
        }

        // Находит узел по значению
        public OptoTreeNode FindNode(string value)
        {
            return FindNodeRecursive(Root, value);
        }

        private OptoTreeNode FindNodeRecursive(OptoTreeNode currentNode, string value)
        {
            if (currentNode.Value == value) return currentNode;

            foreach (var child in currentNode.Children)
            {
                var foundNode = FindNodeRecursive(child, value);
                if (foundNode != null) return foundNode;
            }

            return null; // Узел не найден
        }
    }

}
