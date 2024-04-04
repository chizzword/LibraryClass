using System;
using System.Collections.Generic;
using System.Linq;

public class OptoTable
{
    // Хранилище строк таблицы в виде списка словарей.
    private List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

    // Метод для добавления новой строки. Принимает словарь, где ключ - это название столбца, а значение - это значение ячейки.
    public void AddRow(Dictionary<string, object> row)
    {
        rows.Add(row);
    }

    // Метод для получения строки по индексу. Возвращает null, если индекс вне диапазона, избегая исключения.
    public Dictionary<string, object> GetRow(int index)
    {
        return index >= 0 && index < rows.Count ? rows[index] : null;
    }

    // Метод для обновления строки по указанному индексу новыми данными.
    // Если индекс вне диапазона, операция не выполняется, предотвращая возникновение исключения.
    public void UpdateRow(int index, Dictionary<string, object> newRow)
    {
        if (index >= 0 && index < rows.Count)
        {
            rows[index] = newRow;
        }
    }

    // Метод для удаления строки по индексу. Проверяет диапазон индекса, чтобы избежать исключений.
    public void RemoveRow(int index)
    {
        if (index >= 0 && index < rows.Count)
        {
            rows.RemoveAt(index);
        }
    }

    // Метод для поиска строк, удовлетворяющих условию: значение в указанном столбце равно заданному.
    // Использует TryGetValue для избежания исключений, если столбец отсутствует.
    public IEnumerable<Dictionary<string, object>> FindRowsByColumnValue(string columnName, object value)
    {
        return rows.Where(row => row.TryGetValue(columnName, out var cellValue) && Equals(cellValue, value));
    }

    // Метод для получения всех строк таблицы. Возвращает новый список, предотвращая изменение оригинального списка извне.
    public List<Dictionary<string, object>> GetAllRows()
    {
        return new List<Dictionary<string, object>>(rows);
    }
}
