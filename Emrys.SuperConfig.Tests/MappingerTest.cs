using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Tests
{


    [TestClass]
    public class MappingerTest
    {

        [TestMethod]
        public void TestValueAttributes()
        {
            string xml = "<testValueClass name='Emrys' age='18'><colors>1</colors></testValueClass>";
            XElement XElement = XElement.Parse(xml);
            TestValueClass testValueClass = SuperConfig.Mapping(typeof(TestValueClass), XElement) as TestValueClass;

            Assert.AreEqual(testValueClass.Name, "Emrys");
            Assert.AreEqual(testValueClass.Age, 18);
        }


        [TestMethod]
        public void TestValueElement()
        {
            string xml = "<testValueClass><name>Emrys</name><age>18</age></testValueClass>";
            XElement XElement = XElement.Parse(xml);
            TestValueClass testValueClass = SuperConfig.Mapping(typeof(TestValueClass), XElement) as TestValueClass;

            Assert.AreEqual(testValueClass.Name, "Emrys");
            Assert.AreEqual(testValueClass.Age, 18);
        }

        [TestMethod]
        public void TestKeyValue()
        {
            string xml = @"<TestKeyValueClass>
                            <keyValueTest>
                                <key>Emrys</key>
                                <value>18</value>
                            </keyValueTest>
                            </TestKeyValueClass>";
            XElement XElement = XElement.Parse(xml);
            TestKeyValueClass testValueClass = (TestKeyValueClass)SuperConfig.Mapping(typeof(TestKeyValueClass), XElement);

            Assert.AreEqual(testValueClass.KeyValueTest.Key, "Emrys");
            Assert.AreEqual(testValueClass.KeyValueTest.Value, 18);
        }


        //[TestMethod]
        //public void TestKeyValue2()
        //{
        //    string xml = @"
        //                    <keyValueTest>
        //                        <key>Emrys</key>
        //                        <value>18</value>
        //                    </keyValueTest>
        //                   ";
        //    XElement XElement = XElement.Parse(xml);
        //    KeyValuePair<string, int> testValueClass = SuperConfig<KeyValuePair<string, int>>.Mapping(XElement);

        //    Assert.AreEqual(testValueClass.Key, "Emrys");
        //    Assert.AreEqual(testValueClass.Value, 18);
        //}


        [TestMethod]
        public void TestListSimple()
        {
            string xml = @"<testListClass>
                            <colors>
                             <item>blue</item>
                             <item>red</item>
                             <item>orgin</item>
                           </colors>
                            </testListClass>";
            XElement XElement = XElement.Parse(xml);
            TestListClass t = (TestListClass)SuperConfig.Mapping(typeof(TestListClass), XElement);

            Assert.AreEqual(t.Colors.First(), "blue");
            Assert.AreEqual(t.Colors.Last(), "orgin");
        }

        [TestMethod]
        public void TestListModel()
        {
            string xml = @"<TestListModel>
                            <testValue>
                                <item name='Emrys' age='18'><colors>1</colors></item>
                               <item name='Emrys' age='18'><colors>1</colors></item>
                               <item name='Emrys' age='180'><colors>1</colors></item>
                           </testValue>
                          </TestListModel>";

            XElement XElement = XElement.Parse(xml);
            TestListModel t = (TestListModel)SuperConfig.Mapping(typeof(TestListModel), XElement);

            Assert.AreEqual(t.TestValue.First().Name, "Emrys");
            Assert.AreEqual(t.TestValue.Last().Age, 180);
        }


        [TestMethod]
        public void TestArrayModel()
        {
            string xml = @"<TestArrayModel>
                            <testValue>
                                <item name='Emrys' age='18'><colors>1</colors></item>
                               <item name='Emrys' age='18'><colors>1</colors></item>
                               <item name='Emrys' age='180'><colors>1</colors></item>
                           </testValue>
                          </TestArrayModel>";

            XElement XElement = XElement.Parse(xml);
            TestArrayModel t = (TestArrayModel)SuperConfig.Mapping(typeof(TestArrayModel), XElement);
            Assert.AreEqual(t.TestValue.First().Name, "Emrys");
            Assert.AreEqual(t.TestValue.Last().Age, 180);
        }


        [TestMethod]
        public void TestDictionaryClass()
        {
            string xml = @"<testDictionary>
                            <testDictionary>
                                <item key='emrys'>
                                   <value name='Emrys' age='18' colors='Blue'></value>
                                </item> 
                           </testDictionary>
                          </testDictionary>";

            XElement XElement = XElement.Parse(xml);

            TestDictionaryClass t = SuperConfig<TestDictionaryClass>.Mapping(XElement);


            Assert.AreEqual(t.TestDictionary["emrys"].Name, "Emrys");
            Assert.AreEqual(t.TestDictionary["emrys"].Colors, Colors.Blue);
        }
    }


    public class TestValueClass
    {
        public string Name { get; set; }
        public int Age { get; set; }


        public Colors Colors { get; set; }
    }

    public enum Colors
    {
        Red, Blue
    }

    public class TestKeyValueClass
    {
        public KeyValuePair<string, int> KeyValueTest { get; set; }
    }


    public class TestListClass
    {
        public List<string> Colors { get; set; }
    }

    public class TestListModel
    {
        public List<TestValueClass> TestValue { get; set; }

    }

    public class TestArrayModel
    {
        public TestValueClass[] TestValue { get; set; }

    }

    public class TestDictionaryClass
    {

        public Dictionary<string, TestValueClass> TestDictionary { get; set; }
    }

}
