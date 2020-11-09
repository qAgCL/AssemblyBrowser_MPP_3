using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using AssemblyInfoLib;
namespace TestConsoleApp
{
    class Program
    {
        int j;
        static void Main(string[] args)
        {
            

            AssemblyBrowser assemblyBrowser = new AssemblyBrowser();
            AssemblyInformation test = assemblyBrowser.GetAssemblyInformation(Assembly.GetExecutingAssembly());

            foreach(KeyValuePair<string, NamespaceInformation> keyValue in test.NamespacesInfo)
            {
                Console.WriteLine(keyValue.Key);
                foreach (TypeInformation type in keyValue.Value.TypesInfo)
                {
                    Console.WriteLine(type.TypeName);
                    foreach (FieldInfo field in type.FieldsInfo)
                    {
                        Console.WriteLine(field.Name);
                    }
                }
            }
            Console.ReadLine();
        }
    }

    class testThis
    {
        int k;
        int kas;
    }
}
