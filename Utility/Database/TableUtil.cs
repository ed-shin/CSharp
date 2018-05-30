
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Utiltiy.Database
{
    public static class TableUtil
    {
        public static string GetTableName<T>(this T table) where T : class
        {
            Type type = table.GetType();
            object[] temp = type.GetCustomAttributes(typeof(TableAttribute), true);
            if (temp.Length == 0)
                return null;
            else
                return (temp[0] as TableAttribute).Name;
        }

        public static ColumnProperty[] GetColumns<T>(this T table) where T : class
        {
            Type type = table.GetType();
            var properties = type.GetProperties();
            if (properties.Length > 0)
            {
                List<ColumnProperty> columns = new List<ColumnProperty>();
                foreach (var property in properties)
                {
                    object[] attributes = property.GetCustomAttributes(typeof(ColumnAttribute), true);
                    if (attributes.Length > 0)
                    {
                        ColumnAttribute columnAttribute = attributes[0] as ColumnAttribute;

                        ColumnProperty column = new ColumnProperty();
                        column.Name = columnAttribute.Name;
                        column.DbType = columnAttribute.DbType;

                        columns.Add(column);
                    }

                }

                return columns.ToArray();
            }

            return null;
        }

    }

    public class ColumnProperty
    {
        public string Name { get; set; }
        public string DbType { get; set; }
        public object Value { get; set; }
    }
}
