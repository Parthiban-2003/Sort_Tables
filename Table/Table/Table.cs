using System;
using System.Collections.Generic;

namespace TableCollections
{
    public class Table
    {
        public string strTableName { get; }
        public List<string> strParentTable { get; }

        public Table(string name, List<string> parents)
        {
            strTableName = name;
            strParentTable = parents;
        }
    }
}
