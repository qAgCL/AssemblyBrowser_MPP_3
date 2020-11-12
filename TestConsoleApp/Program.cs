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
            AssemblyInformation AssemblyInformation = assemblyBrowser.GetAssemblyInformation(Assembly.GetExecutingAssembly());
        }
    
    }


    class testThis
    {
        int k;
        int kas;
    }
}
