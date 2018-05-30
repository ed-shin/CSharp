using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Database.Access
{
    public enum eServiceType
    {
        SQLite,
        Oracle
    }

    public interface IPropertySet
    {
        eServiceType ServiceType { get; }
        string Name { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        string Database { get; set; }
        string User { get; set; }
        string Password { get; set; }
        string ConnectionString { get; }
    }
}
