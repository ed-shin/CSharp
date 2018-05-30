using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utility.Parser
{
    public class JsonParser
    {
        //**
        //** Example
        //**
        //public static List<object> GetCameras(string fileName)
        //{
        //    string text = null;

        //    using (StreamReader sr = new StreamReader(fileName))
        //    {
        //        text = sr.ReadToEnd();
        //    }

        //    List<object> datas = Deserializer<List<object>>(text);

        //    return datas;
        //}

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
