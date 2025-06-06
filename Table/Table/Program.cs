using System;
using TableCollections;
using System.Collections.Generic;

namespace SortingTables
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var TablesContains = new List<Table>
            {
                new Table("Table1", new List<string>()),
                new Table("Table2", new List<string> {"Table1","Table2"}),
                new Table("Table3", new List<string> {"Table2"}),
                new Table("Table4", new List<string> {"Table3"})
            };

            var sortedTablesOrder = SortTables(TablesContains);
            sortedTablesOrder.ForEach(table => Console.WriteLine($"Table Order List: {table}"));
        }

        public static List<string> SortTables(List<Table> tables)
        {
            var sortingTable = new List<string>();
            var visitingTable = new Dictionary<string, bool>();
            var mapingTable = new Dictionary<string, Table>();

            tables.ForEach(t => mapingTable[t.strTableName] = t);

            foreach (var table in tables)
            {
                if (!visitingTable.ContainsKey(table.strTableName))
                {
                    Visit(table, visitingTable, sortingTable, mapingTable);
                }
            }

            return sortingTable;
        }

        public static void Visit(Table table, Dictionary<string, bool> visitingTable, List<string> sortingTable, Dictionary<string, Table> mapingTable)
        {
            if (visitingTable.ContainsKey(table.strTableName))
            {
                if (visitingTable[table.strTableName])
                {
                    Console.WriteLine($"Cycle Detected: {table.strTableName}");
                }
                return;
            }

            visitingTable[table.strTableName] = true;

            foreach (var parentName in table.strParentTable)
            {
                Visit(mapingTable[parentName], visitingTable, sortingTable, mapingTable);
            }

            visitingTable[table.strTableName] = false;
            sortingTable.Add(table.strTableName);
        }
    }
}
