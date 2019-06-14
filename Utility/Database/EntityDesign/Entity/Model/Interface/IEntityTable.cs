using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDEN.Utility.Data.Entity
{
    public interface IEntityTable
    {
        /// <summary>
        /// Table의 이름
        /// </summary>
        string TableName { get; }
        /// <summary>
        /// Table의 ID Column name
        /// </summary>
        string PrivateKey { get; }
        /// <summary>
        /// Table의 Column names
        /// </summary>
        string[] Columns { get; }
    }
}
