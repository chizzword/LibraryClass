using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class OptoList<T> : IEnumerable<T>
{
    private readonly List<T> items = new List<T>();

    // Добавление элемента в список
    public void Add(T item) => items.Add(item);

    // Добавление диапазона элементов
    public void AddRange(IEnumerable<T> itemsToAdd) => items.AddRange(itemsToAdd);

    // Удаление элемента из списка
    public bool Remove(T item) => items.Remove(item);

    // Удаление элемента по индексу
    public void RemoveAt(int index) => items.RemoveAt(index);

    // Удаление диапазона элементов
    public void RemoveRange(int index, int count) => items.RemoveRange(index, count);

    // Чтение элемента по индексу
    public T Get(int index) => items[index];

    // Обновление элемента по индексу
    public void Update(int index, T newItem) => items[index] = newItem;

    // Сортировка списка по критерию
    public void Sort(Comparison<T> comparison) => items.Sort(comparison);

    // Поиск первого элемента, удовлетворяющего условию
    public T FirstOrDefault(Func<T, bool> predicate) => items.FirstOrDefault(predicate);

    // Поиск всех элементов, удовлетворяющих условию
    public IEnumerable<T> Find(Func<T, bool> predicate) => items.Where(predicate);

    // Получение всех элементов списка
    public List<T> GetAll() => new List<T>(items);

    // Предоставление доступа к элементам по индексу
    public T this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    // Получение количества элементов в списке
    public int Count => items.Count;

    // Реализация IEnumerable<T> для поддержки итерации
    public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Предоставление только для чтения представления списка
    public ReadOnlyCollection<T> AsReadOnly() => items.AsReadOnly();
}

//Ключевые Особенности:
//Обобщённость: Класс является обобщённым, что позволяет использовать его с любым типом данных.
//Добавление и Удаление: Поддерживаются операции добавления и удаления одного элемента, диапазона элементов, а также удаление по индексу.
//Поиск и Фильтрация: Методы FirstOrDefault и Find позволяют искать элементы по условию.
//Сортировка: Метод Sort позволяет сортировать список на месте.
//Итерация: Реализация IEnumerable<T> обеспечивает совместимость с LINQ и позволяет использовать объекты OptoList<T> в циклах foreach.
//ReadOnly Представление: Метод AsReadOnly предоставляет безопасный доступ к данным, предотвращая их изменение.