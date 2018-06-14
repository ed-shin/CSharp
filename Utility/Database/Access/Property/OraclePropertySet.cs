using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Database.Access
{
    public class OraclePropertySet : IPropertySet
    {
        public eServiceType ServiceType { get { return eServiceType.Oracle; } }
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
                return string.Format(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1})))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME={2})));User ID={3};Password={4};",
                                                        Host,
                                                        Port,
                                                        "orcl", //service name
                                                        User,
                                                        Password);
            }
        }
    }
}
