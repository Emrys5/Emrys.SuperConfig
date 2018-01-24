using Microsoft.VisualStudio.TestTools.UnitTesting;
using Emrys.SuperConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Emrys.SuperConfig.Tests.Models;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Tests
{
    [TestClass()]
    public class SuperConfigTests
    {
        [TestMethod()]
        public void GettingStarted()
        {
            var user = SuperConfig<UserInfo>.Value;


            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod()]
        public void TestSetSectionName()
        {
            SuperConfig<UserInfo>.Setting("user");
            var user = SuperConfig<UserInfo>.Value;


            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod()]
        public void TestSetConvertCase()
        {
            SuperConfig<UserInfo>.Setting(n => n);
            var user = SuperConfig<UserInfo>.Value;


            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod()]
        public void TestSetConfigFilePath()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "UserInfo.config");

            SuperConfig<UserInfo>.SettingFilePath(configFilePath);
            var user = SuperConfig<UserInfo>.Value;


            Assert.AreEqual(user.UserName, "FEmrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 17);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod()]
        public void TestSetSection()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "SetSection.config");

            SuperConfig<UserInfo>.Setting(configFilePath, (sectionName, filePath, convertCaseStrategy) =>
            {
                XElement xElement = XElement.Load(filePath);
                var caseSectionName = convertCaseStrategy.ConvertCase(sectionName);
                var sectionElement = xElement.Elements().Where(i => i.Name == caseSectionName).FirstOrDefault();
                if (sectionElement == null)
                {
                    throw new Exception("dot find section：" + sectionName);
                }

                return new Section() { XElement = sectionElement };
            });
            var user = SuperConfig<UserInfo>.Value;


            Assert.AreEqual(user.UserName, "CEmrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 17);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }


        [TestMethod()]
        public void TestSetSectionArray()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "SetSection.config");

            SuperConfig<string[]>.Setting("arrayString", configFilePath, null, (sectionName, filePath, convertCaseStrategy) =>
            {
                XElement xElement = XElement.Load(filePath);
                var caseSectionName = convertCaseStrategy.ConvertCase(sectionName);
                var sectionElement = xElement.Elements().Where(i => i.Name == caseSectionName).FirstOrDefault();
                if (sectionElement == null)
                {
                    throw new Exception("dot find section：" + sectionName);
                }

                return new Section() { XElement = sectionElement };
            });

            var array = SuperConfig<string[]>.Value;

            Assert.AreEqual(array.First(), "a");
        }

        [TestMethod()]
        public void TestSetSectionUserInfo()
        {
            var configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Cfg", "SectionUserInfo.config");

            SuperConfig<UserInfo>.Setting(configFilePath, (sectionName, filePath, convertCaseStrategy) =>
           { 
               return new Section() { XElement = XElement.Load(filePath) };
           });

            var user = SuperConfig<UserInfo>.Value;
             

            Assert.AreEqual(user.UserName, "SUEmrys"); 
        }


    }
}