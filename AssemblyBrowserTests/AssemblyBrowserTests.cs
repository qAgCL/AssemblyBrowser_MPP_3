using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using AssemblyInfoLib;
using System.Collections.Generic;
namespace AssemblyBrowserTests
{
    [TestClass]
    public class AssemblyBrowserTests
    {
        private AssemblyInformation AssemblyInformation;

        [TestInitialize]

        public void TestInit()
        {
            Assembly assembly = Assembly.LoadFrom("TestConsoleApp.exe");
            AssemblyBrowser assemblyBrowser = new AssemblyBrowser();
            AssemblyInformation = assemblyBrowser.GetAssemblyInformation(assembly);
        }
        [TestMethod]
        public void TestNamespace()
        {
            Assert.IsNotNull(AssemblyInformation.NamespacesInfo);
            CollectionAssert.AllItemsAreNotNull(AssemblyInformation.NamespacesInfo);
            Assert.AreEqual(AssemblyInformation.NamespacesInfo.Count, 3);
            Assert.AreEqual(AssemblyInformation.AssemblyName, "TestConsoleApp");
        }
        [TestMethod]
        public void TestExten()
        {
            List<TypeInformation> TypesInfo = AssemblyInformation.NamespacesInfo["ExtensionFunc"].TypesInfo;
            Assert.IsNotNull(TypesInfo);
            Assert.AreEqual(TypesInfo.Count, 2);
            CollectionAssert.AllItemsAreNotNull(TypesInfo);
            CollectionAssert.AllItemsAreNotNull(TypesInfo[1].MethodsInfo);
            CollectionAssert.AllItemsAreNotNull(TypesInfo[1].PropertiesInfo);
        }
        [TestMethod]
        public void TestExtened()
        {
            List<TypeInformation> TypesInfo = AssemblyInformation.NamespacesInfo["ExtensionFunc"].TypesInfo;
            CollectionAssert.AllItemsAreNotNull(TypesInfo);
            Assert.AreEqual(TypesInfo[1].MethodsInfo.Count,9);
            Assert.AreEqual(TypesInfo[0].MethodsInfo.Count, 7);
        }

        [TestMethod]
        public void TestName()
        {
            List<TypeInformation> TypesInfo = AssemblyInformation.NamespacesInfo["ExtensionFunc"].TypesInfo;
            CollectionAssert.AllItemsAreNotNull(TypesInfo);
            Assert.AreEqual(TypesInfo[1].MethodsInfo[0].Name,"Test1");
            Assert.AreEqual(TypesInfo[1].PropertiesInfo[0].Name, "Int");
        }
        [TestMethod]
        public void TestAnotherNamespace()
        {
            List<TypeInformation> TypesInfo = AssemblyInformation.NamespacesInfo["SimpleClasses"].TypesInfo;
            Assert.IsNotNull(TypesInfo);
            Assert.AreEqual(TypesInfo.Count, 4);
            CollectionAssert.AllItemsAreNotNull(TypesInfo);
            Assert.AreEqual(TypesInfo[0].MethodsInfo.Count,7);
            Assert.AreEqual(TypesInfo[0].PropertiesInfo.Count,1);
            Assert.AreEqual(TypesInfo[0].PropertiesInfo[0].Name, "Int");
        }
    }
}
