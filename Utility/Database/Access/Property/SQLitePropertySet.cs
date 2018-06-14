using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Database.Access
{
    public class SQLitePropertySet : IPropertySet
    {
        public eServiceType ServiceType { get { return eServiceType.SQLite; } }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string ConnectionString
        {
            get
            {
                return string.Format("Data Source={0}", Database);
            }
        }
    }
}
