using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_1
{
    class VariableTable
    {
        struct ATTRIBUTS
        {
            public string type;   // Определяет тип идентификатора
            public bool value;  // Определяет имеет ли идентификатор значение
            public bool change;  // Определяет можно ли менять значение идентификатора
        };

        // Словарь. Ключ - идентификатор. Значение - атрибуты
        private Dictionary<string, ATTRIBUTS> variable_table;

        VariableTable()     // Создание переменной таблицы
        {
            variable_table = new Dictionary<string, ATTRIBUTS>();
        }

        public bool Add(string id)   // Добавление элемента в таблицу
        {
            try
            {
                variable_table.Add(id, new ATTRIBUTS());
                return true;    // идентификатор добавлен
            }
            catch
            {
                return false;   // Такой идентификатор уже есть в таблице
            }
        }

        public bool SetType(string id, string type)    // Запись типа данного идентификатора
        {
            if (SearchIsExist(id))      // Есть ли такой идентификатор в таблице
            {
                // Запись атрибута
                ATTRIBUTS atr = variable_table[id];
                atr.type = type;
                return true;
            }
            else
            {
                Console.WriteLine("Данного элемента нет в таблице");
                return false;
            }
        }

        public bool SetValue(string id, bool value)  // Запись имеет ли значение данный идентификатор
        {
            if (SearchIsExist(id))    // Есть ли такой идентификатор в таблице
            {
                // Запись атрибута
                ATTRIBUTS atr = variable_table[id];
                atr.value = value;
                return true;
            }
            else
            {
                Console.WriteLine("Данного элемента нет в таблице");
                return false;
            }
        }

        public bool SetChange(string id, bool change)    // Запись может ли быть изменен данный идентификатор
        {
            if (SearchIsExist(id))     // Есть ли такой идентификатор в таблице
            {
                // Запись атрибута
                ATTRIBUTS atr = variable_table[id];
                atr.change = change;
                return true;
            }
            else
            {
                Console.WriteLine("Данного элемента нет в таблице");
                return false;
            }
        }
        public bool SearchIsExist(string id)   // Поиск по идентификатору
        {
            return variable_table.ContainsKey(id);
        }

        // what_search определяет по каким атрибутам производить поиск.
        // Первый символ определяет искать ли по ATTRIBUTS.type ('t' - искать; 'n' - не искать)
        // Второй символ определяет искать ли по ATTRIBUTS.value ('v' - искать; 'n' - не искать)
        // Третий символ определяет искать ли по ATTRIBUTS.change ('c' - искать; 'n' - не искать)
        public List<string> SearchAttribut(string type, bool value, bool change, char[] what_search)  // Поиск индентификаторов по атрибутам.
        {
            List<string> identifiers = new List<string>();

            foreach (string key in variable_table.Keys)
            {
                ATTRIBUTS atr_in_table = variable_table[key];   // Атрибуты данного ключа таблицы
                string find_key = key;
                for (int i = 0; i < 3 && find_key == key; i++)
                {
                    char flag = what_search[i];
                    switch(flag)
                    {
                        case 't':   // Поиск по типу
                            if(atr_in_table.type != type)
                                find_key = null;
                            break;

                        case 'v':   // Поиск по значению
                            if(atr_in_table.value != value)
                                find_key = null;
                            break;

                        case 'c':   // Поиск по изменению
                            if (atr_in_table.change != change)
                                find_key = null;
                            break;

                        case 'n':   // По этому атрибуту не идет поиск
                            break;

                        default:    // Неправильно ввели переменную what_search
                            Console.WriteLine("Невозможно определить что вы ищете");
                            break;
                    }
                }

                if (find_key != null)   // Если нашелся идентификатор соответствующий атрибутам
                { 
                    identifiers.Add(find_key);
                }
            }
            return identifiers;
        }
        public void WriteInfo(string id)     // Выводит информацию по идентификатору
        {
            if(SearchIsExist(id))
            {
                ATTRIBUTS atr = variable_table[id];
                Console.WriteLine($"Имя: {id}. Тип: {atr.type}. Имеет значение? {atr.value}. Можно изменять значение? {atr.change}");
            }
            else
            {
                Console.WriteLine("Данного элемента нет в таблице");
            }  
        }

    }
}
