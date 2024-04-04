using System;
using System.Collections.Generic;
using System.Linq;

public class OptoTreeNode
{
    public string Value { get; set; }
    public int Index { get; set; }
    public List<OptoTreeNode> Children { get; set; } = new List<OptoTreeNode>();

    public OptoTreeNode(string value)
    {
        Value = value;
    }


    // Добавление дочернего узла
    public void AddChild(OptoTreeNode child)
    {
        Children.Add(child);
    }

    // Удаление дочернего узла
    public bool RemoveChild(OptoTreeNode child)
    {
        return Children.Remove(child);
    }

    public void Expand(bool deepExpand = false)
    {
        // Ваша логика для раскрытия узла (например, отображение дочерних элементов в UI)
        if (deepExpand)
        {
            foreach (var child in Children)
            {
                child.Expand(true);
            }
        }
    }

    public void Collapse(bool deepCollapse = false)
    {
        // Логика для сворачивания узла
        if (deepCollapse)
        {
            foreach (var child in Children)
            {
                child.Collapse(true);
            }
        }
    }

    // Метод поиска узла по значению
    public OptoTreeNode FindNodeByValue(string value)
    {
        if (Value.Equals(value, StringComparison.OrdinalIgnoreCase))
        {
            return this;
        }

        foreach (var child in Children)
        {
            var found = child.FindNodeByValue(value);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }

    // Метод поиска узла по индексу
    public OptoTreeNode FindNodeByIndex(int index)
    {
        if (Index == index)
        {
            return this;
        }

        foreach (var child in Children)
        {
            var found = child.FindNodeByIndex(index);
            if (found != null)
            {
                return found;
            }
        }

        return null;
    }

    //Метод, который ищет узел по значению и индексу одновременно
    public OptoTreeNode FindNodeByValueAndIndex(string value, int index)
    {
        // Проверяем текущий узел на соответствие искомым параметрам
        if (Value.Equals(value, StringComparison.OrdinalIgnoreCase) && Index == index)
        {
            return this;
        }

        // Рекурсивно ищем среди дочерних узлов
        foreach (var child in Children)
        {
            var found = child.FindNodeByValueAndIndex(value, index);
            if (found != null)
            {
                return found;
            }
        }

        // Если узел не найден, возвращаем null
        return null;
    }
}
