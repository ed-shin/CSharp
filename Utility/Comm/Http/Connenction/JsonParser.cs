using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EDEN.Utility.Comm.Http
{
    public class JsonParser
    {
        public static T FromJson<T>(string json)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = int.MaxValue;

                T data = ser.Deserialize<T>(json);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine("fail... json deserialize");
            }

            return default(T);
        }

        public static string ToJson<T>(T data)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = int.MaxValue;

                return ser.Serialize(data);
            }
            catch(Exception ex)
            {
                Console.WriteLine("fail... json serialize");
            }

            return null;
        }
    }
}
