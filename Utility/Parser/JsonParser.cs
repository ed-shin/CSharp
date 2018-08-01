using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utility.Parser
{
    /// <summary>
    /// Basic Json Parser (But, Newton's library is better)
    /// </summary>
    public class JsonParser
    {
        public static T Deserializer<T>(string json)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                T user = ser.Deserialize<T>(json);

                return user;
            }
            catch
            {
                Console.WriteLine("fail... json deserializer");
            }

            return default(T);
        }

        public static string Serializer<T>(T data)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();

                return ser.Serialize(data);
            }
            catch
            {
                Console.WriteLine("fail... json serializer");
            }

            return null;
        }
    }
}
