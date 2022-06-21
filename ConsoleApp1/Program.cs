using System;
using System.IO;
using System.Xml.Serialization;
using GraphQl.Common;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextReader reader = new StreamReader(@"D:\git\GraphQl-EF-Dotnet-Example\GraphQl.Common\SchemaData\master\Master (1).xml");
                XmlSerializer serializer = new XmlSerializer(typeof(MasterData));
                MasterData masterdata = serializer.Deserialize(reader) as MasterData;
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
