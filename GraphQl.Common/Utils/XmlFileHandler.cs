using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GraphQl.Common.Utils
{
    public class XmlFileHandler
    {
        /// <summary>
        /// 
        /// </summary>
        public static T ReadXmlInput<T>(String inputFilePath)
        {
            T masterdata = default(T);
            try
            {
                TextReader reader = new StreamReader(@"D:\git\GraphQl-EF-Dotnet-Example\GraphQl.Common\SchemaData\master\Master (1).xml");
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                masterdata = (T)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return masterdata;
        }
    }
}
