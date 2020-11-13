using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;
using System.Reflection;
namespace TreeViewWPF
{
  
    class InfoType
    {
        public static string GetTypeName(Type type)
        {
            string TypeName = type.Name;
            if (type.IsGenericType)
            {
                TypeName = TypeName.Remove(TypeName.IndexOf('`'));
                TypeName += '<';
                Type[] typeArgumetns = type.GetGenericArguments();
                foreach (Type argument in typeArgumetns)
                    {
                        TypeName += GetTypeName(argument) + ',';
                    }
                if (typeArgumetns.Count() > 0)
                {
                    TypeName = TypeName.Remove(TypeName.Length - 1);
                }
                TypeName += '>';
            }
            return TypeName;
        }
    }
    public class GetPropertyName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            PropertyInfo propertyInfo = (PropertyInfo)value;
            string PropertyInfoName= null;
            PropertyInfoName += InfoType.GetTypeName(propertyInfo.PropertyType)+" "+propertyInfo.Name;
            return PropertyInfoName;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
    public class GetTypeName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Type typeInfo = (Type)value;
            string TypeInfoName = null;
            if (typeInfo.IsPublic)
            {
                TypeInfoName += "public ";
            }
            else
            {
                TypeInfoName += "private ";
            }
            if (typeInfo.IsAbstract)
            {
                TypeInfoName += "abstract ";
            }
            if (typeInfo.IsSealed)
            {
                TypeInfoName += "sealed ";
            }
            if (typeInfo.IsClass)
            {
                TypeInfoName += "class ";
            }
            if (typeInfo.IsInterface)
            {
                TypeInfoName += "interface ";
            }
            TypeInfoName += InfoType.GetTypeName(typeInfo);
            return TypeInfoName;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
    public class GetMethodName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MethodInfo methodInfo = (MethodInfo)value;
            string MethodInfoName = null;
            if (methodInfo.IsPublic)
            {
                MethodInfoName += "public ";
            }
            else
            {
                MethodInfoName += "private ";
            }
            
            if (methodInfo.IsStatic)
            {
                MethodInfoName += "static ";
            }
            if (methodInfo.IsAbstract)
            {
                MethodInfoName += "abstract ";
            }
            if (methodInfo.IsVirtual)
            {
                MethodInfoName += "virtual ";
            }
            MethodInfoName += InfoType.GetTypeName(methodInfo.ReturnType) + " " + methodInfo.Name;
            MethodInfoName += "(";
            ParameterInfo[] Parametrs = methodInfo.GetParameters();
            foreach (ParameterInfo argument in Parametrs)
                {
                    MethodInfoName += InfoType.GetTypeName(argument.ParameterType)+' '+argument.Name+ ',';
                }
            if (Parametrs.Count() > 0) {
                MethodInfoName = MethodInfoName.Remove(MethodInfoName.Length - 1);
            };
            MethodInfoName += ")";
            return MethodInfoName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
    public class GetFieldName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FieldInfo fieldInfo = (FieldInfo)value;
            string FieldInfoName = null;
            if (fieldInfo.IsPublic)
            {
                FieldInfoName += "public ";
            }
            else
            {
                FieldInfoName += "private ";
            }
            if (fieldInfo.IsStatic)
            {
                FieldInfoName += "static ";
            }
            FieldInfoName += InfoType.GetTypeName(fieldInfo.FieldType) + " " + fieldInfo.Name;
            return FieldInfoName;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Windows.DependencyProperty.UnsetValue;
        }
    }
}


