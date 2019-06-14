using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    /// <summary>
    /// 테이블의 스키마 정보를 담는 객체
    /// </summary>
    internal class EntityInfo
    {
        internal static bool IsLoaded { get; set; }
        internal static bool Load(EntityConnection conn)
        {
            if (IsLoaded)
                return true;

            if (conn.IsConnected == false)
                return false;

            TableScheme.SAMPLE = conn.GetScheme(TableName.SAMPLE);

            return IsLoaded = true;
        }

        internal static void Release()
        {
            IsLoaded = false;
        }

        internal class TableName
        {
            internal static string SAMPLE = "TB_SAMPLE";
        }

        internal class PrimaryKey
        {
            internal static string SAMPLE = "";
        }

        internal class Columns
        {
            internal static string[] SAMPLE = null;
        }

        internal class TableScheme
        {
            private static DataTable sample = null;

            internal static DataTable SAMPLE
            {
                get { return sample; }
                set
                {
                    PrimaryKey.SAMPLE = value.PrimaryKey[0].ColumnName;

                    List<string> names = new List<string>();
                    foreach (DataColumn column in value.Columns)
                        names.Add(column.ColumnName);
                    Columns.SAMPLE = names.ToArray();

                    sample = value;
                }
            }
        }
    }
}
