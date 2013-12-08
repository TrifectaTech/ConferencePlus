using System;
using System.Linq;

namespace ConferencePlus.Entities.Common
{
    public class SqlName : Attribute
    {
        public string SqlColumn { get; set; }

        public SqlName(string name)
        {
            SqlColumn = name;   
        }
        public static string GetSqlName(object t)
        {
            string value= string.Empty;
            Attribute[] attrs = GetCustomAttributes(t.GetType());  // Reflection.
            foreach (SqlName a in attrs.OfType<SqlName>())
            {
                value =  a.SqlColumn;
            }
            return value;
        }
    }
    
}

