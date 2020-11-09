using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyInfoLib
{
    public class AssemblyInformation
    {
        public string AssemblyName { get; private set; }
        public Dictionary<string,NamespaceInformation> NamespacesInfo { get; private set; }
        public AssemblyInformation(string assemblyname)
        {
            AssemblyName = assemblyname;
            NamespacesInfo = new Dictionary<string, NamespaceInformation>();
        }
    }

    public class NamespaceInformation
    {
        public string NamespaceName { get; private set; }
        public List<TypeInformation> TypesInfo { get; private set; }
        public NamespaceInformation(string namespaceName)
        {
            NamespaceName = namespaceName;
            TypesInfo = new List<TypeInformation>();
        }
    }

    public class TypeInformation
    {
        public Type TypeName { get; private set; }

        public List<MethodInfo> MethodsInfo { get; private set; }

        public List<PropertyInfo> PropertiesInfo { get; private set; }
        public List<FieldInfo> FieldsInfo { get; private set; }

        public TypeInformation(Type Type)
        {
            TypeName = Type;
            MethodsInfo = new List<MethodInfo>();
            PropertiesInfo = new List<PropertyInfo>();
            FieldsInfo = new List<FieldInfo>();
        }
    }
    
}
