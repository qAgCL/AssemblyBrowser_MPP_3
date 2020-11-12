using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace AssemblyInfoLib
{
    public class AssemblyBrowser
    {
        public AssemblyInformation GetAssemblyInformation(Assembly assembly)
        {
            AssemblyInformation InfoAssembly = new AssemblyInformation(assembly.GetName().Name);
            Type[] AssemblyType = assembly.GetTypes();
            List<MethodInfo> ExtenMethod = new List<MethodInfo>();

            foreach (Type type in AssemblyType)
            {
               if (!type.GetTypeInfo().IsDefined(typeof(CompilerGeneratedAttribute), false))
                {
                    string NameSpace = type.Namespace;
          
                    if (!InfoAssembly.NamespacesInfo.ContainsKey(NameSpace))
                    {
                        InfoAssembly.NamespacesInfo.Add(NameSpace, new NamespaceInformation(NameSpace));
                    }
                    TypeInformation typeInformation = new TypeInformation(type);
                    FieldInfo[] Fields = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (FieldInfo fieldInfo in Fields)
                    {
                        if (!fieldInfo.IsDefined(typeof(CompilerGeneratedAttribute), false))
                        {
                            typeInformation.FieldsInfo.Add(fieldInfo);
                        }
                    }
                    PropertyInfo[] Properties = type.GetProperties(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (PropertyInfo propertyInfo in Properties)
                    {
                        if (!propertyInfo.IsDefined(typeof(CompilerGeneratedAttribute), false))
                        {
                            typeInformation.PropertiesInfo.Add(propertyInfo);
                        }
                    }
                    MethodInfo[] Methods = type.GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                    foreach (MethodInfo methodInfo in Methods)
                    {
                        if (!methodInfo.IsDefined(typeof(CompilerGeneratedAttribute), false))
                        {
                           if(methodInfo.IsDefined(typeof(ExtensionAttribute), false))
                           {
                                ExtenMethod.Add(methodInfo);
                           }
                           else {
                                typeInformation.MethodsInfo.Add(methodInfo);
                           }
                        }
                    }
                    InfoAssembly.NamespacesInfo[NameSpace].TypesInfo.Add(typeInformation);
                }
            }
            foreach (MethodInfo method in ExtenMethod)
            {
                Type ExtendedClass = method.GetParameters()[0].ParameterType;
                foreach (TypeInformation type in InfoAssembly.NamespacesInfo[ExtendedClass.Namespace].TypesInfo)
                {
                   if (type.TypeName == ExtendedClass)
                   {
                        type.MethodsInfo.Add(method);
                   }
                };
            }
            return InfoAssembly;
        }
    }
}
