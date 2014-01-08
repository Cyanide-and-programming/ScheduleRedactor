using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using SheduleRedactor;

namespace Serializer
{
    static class ObjectSerializer
    {

        public static void SerializeTo(IEnumerable<Object> objects, string path)
        {
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, objects);
            }
        }
        public static IEnumerable<Object> DeserializeFrom(string path)
        {
            IEnumerable<Object> objects = null;
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                objects = (IEnumerable<Object>)formatter.Deserialize(stream);
            }
            return objects;
        }
    }

    static class FileParser
    {
        static private IEnumerable<String> Lines(string path)
        {
            List<String> strings = new List<string>();
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    String tmp;
                    while ((tmp = reader.ReadLine()) != null)
                        strings.Add(tmp);
                }
            }
            return strings;
        }
        static public IEnumerable<String> TeachersFromFile(string path)
        {
            return  FileParser.Lines(path);

        }
        static public IEnumerable<Audience> AudiencesFromFile(string path)
        {
            IEnumerable<String> lines = FileParser.Lines(path);
            List<Audience> audiences = new List<Audience>();
            foreach (var item in lines)
            {
                var tmp = item.Split(new[]{'$'}, StringSplitOptions.RemoveEmptyEntries);
                audiences.Add(new Audience(
                    tmp[0], 
                    tmp[2].Equals("0") ? false : true, 
                    ushort.Parse(tmp[1])
                    ));
            }
            return audiences;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            try 
            {
                var aud = FileParser.AudiencesFromFile("aud.txt");
                ObjectSerializer.SerializeTo(aud, "Audiences.srp");
                
                var strings = ObjectSerializer.DeserializeFrom("Audiences.srp");
                foreach(var item in strings)
                    Console.WriteLine(item.ToString());
           
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            Console.ReadKey();
        }
    }
}
