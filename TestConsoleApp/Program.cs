using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using AssemblyInfoLib;
namespace MainFunc
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
namespace ExtensionFunc
{
    public static class ExtensionClass
    {
        static private char Char;

        static int Test(bool das)
        {
            return 4;
        }
        public static int Test3(this ExtendedClass test, bool bol,int tes)
        {
            return 4;
        }
    }
    public class ExtendedClass
    {
        public char Char;
        private int Int { get; set; }

        public void Test1(int a, int b)
        {
        }

        public float Test2(int a, int b)
        {
            return a + b;
        }
    }
}
namespace SimpleClasses
{
    public class TestClass
    {
        public char Char;
        private int Int { get; set; }

        public float Test(int a, int b)
        {
            return a + b;
        }
    }
    abstract class AbstractClass
    {
        public char Char;
        private int Int;
    }

    static class StaticClass
    {
        static public float Test(float a, float b)
        {
            return a - b;
        }
    }
    struct TestStruct
    {
        public char Char;
        private int Int { get; set; }

        public float Test(int a,int b)
        {
            return a + b;
        }
    }
}