using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_1
{
    class ConstantTable
    {
        private SortedSet<string> constant_table; // Постоянная таблица
        public ConstantTable()  // Создание пустой постоянной таблицы
        {
            constant_table = new SortedSet<string>();
        }
        public bool Add(string elem)   // Добавляет элемент в таблицу
        {
            // Возвращает true - элемент добавлен; false - такой элемент уже существует в таблице.
            return constant_table.Add(elem);
        }

        public void ReadFromFile(string name_file)    // Запись элементов в таблицу из файла
        {
            string[] elems = File.ReadAllLines(name_file);

            foreach (string elem in elems)
            {
                Add(elem);
            }
        }
        public bool SearchIsExist(string elem)    // Проверяет существует ли данный элемент в таблице
        {
            return constant_table.Contains(elem);   // Возвращает true - элемент найден; false - элемент не найден
        }

        public void WriteTable()    // Вывод постоянной таблицы
        {
            foreach (string elem in constant_table)
            {
                Console.WriteLine($"Ключ: {elem}");
            }
        }
    }
}
