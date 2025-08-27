using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace StreamWriterReaderUsing
{
    internal class Program
    {
        static string path = @"C:\Users\dilsa\OneDrive\Masaüstü\VSrep\StreamWriterReaderUsing\name.json";
        static void Main(string[] args)
        {


            List<string> list = new()
            {
                "salam","necesen"
            };


            string result = JsonConvert.SerializeObject(list);

            using (StreamWriter sw = new(path))
            {
                sw.Write(result);
            }
            Add("yaxsi");


            Console.WriteLine(Search("yaxsi"));

            Delete("yaxsi");
        }

        static void Add(string name)
        {
            List<string> names = GetJsonConvert();

            names.Add(name);

            File.WriteAllText(path, JsonConvert.SerializeObject(names));
        }
        static bool Search(string name)
        {
            List<string> names = GetJsonConvert();

            return names.Contains(name);
        }
        static void Delete(string name)
        {
            List<string> names = GetJsonConvert();

            names.Remove(name);
            File.WriteAllText(path, JsonConvert.SerializeObject(names));
        }
        static List<string> GetJsonConvert()
        {
            if (File.Exists(path))
            {
                string result = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<string>>(result);
            }
            return new List<string>();
        }
    }

}



