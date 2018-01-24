using Emrys.SuperConfig.Tests.Models;
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
    public class MappingerTests
    {
        [TestMethod]
        public void TestValueAttributes()
        {
            string xml = @"<userInfo 
                                userName='Emrys' 
                                email='i@emrys.me' 
                                age='27' 
                                blogUrl='http://www.cnblogs.com/emrys5/' 
                                favoriteColor='Blue'
                                dislikeColor='2'
                            ></userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod]
        public void TestValueElements()
        {
            string xml = @"<userInfo>
                                <userName>Emrys</userName>
                                <email>i@emrys.me</email>
                                <age>27</age>
                                <blogUrl>http://www.cnblogs.com/emrys5/</blogUrl>
                                <favoriteColor>Blue</favoriteColor>
                                <dislikeColor>2</dislikeColor> 
                            </userInfo>";


            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod]
        public void TestValueAttributesElements()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <blogUrl>http://www.cnblogs.com/emrys5/</blogUrl>
                                <favoriteColor>Blue</favoriteColor>
                                <dislikeColor>2</dislikeColor> 
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);
            Assert.AreEqual(user.BlogUrl, "http://www.cnblogs.com/emrys5/");
            Assert.AreEqual(user.FavoriteColor, Color.Blue);
            Assert.AreEqual(user.DislikeColor, Color.Black);
        }

        [TestMethod]
        public void TestKeyValueAttributes()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <sports key='1' value='PingPong'></sports>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Sports.Key, 1);
            Assert.AreEqual(user.Sports.Value, "PingPong");
        }

        [TestMethod]
        public void TestKeyValueElements()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <sports>
                                    <key>1</key>
                                    <value>PingPong</value>
                                </sports>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Sports.Key, 1);
            Assert.AreEqual(user.Sports.Value, "PingPong");
        }

        [TestMethod]
        public void TestKeyValueAttributesElements()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <sports key='1'> 
                                    <value>PingPong</value>
                                </sports>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Sports.Key, 1);
            Assert.AreEqual(user.Sports.Value, "PingPong");
        }

        [TestMethod]
        public void TestKeyValueNoEntity()
        {
            string xml = @"<sports  key='1' value='PingPong'>
                           </sports>";

            KeyValuePair<int, string> keyValue = SuperConfig.Mapping<KeyValuePair<int, string>>(XElement.Parse(xml));


            Assert.AreEqual(keyValue.Key, 1);
            Assert.AreEqual(keyValue.Value, "PingPong");
        }

        [TestMethod]
        public void TestListSimple()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <language> 
                                    <value>Putonghua</value>
                                    <value>Huaipu</value>
                                    <value>English</value>
                                </language>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Language.First(), "Putonghua");
            Assert.AreEqual(user.Language.Last(), "English");
        }

        [TestMethod]
        public void TestList()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <family> 
                                    <item userName='lcz' email='xxx@qq.com' age='50'></item>
                                    <item>
                                        <userName>ly</userName>
                                        <email>ly@qq.com</email>
                                        <age>30</age> 
                                    </item> 
                                </family>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Family.First().Age, 50);
            Assert.AreEqual(user.Family.Last().UserName, "ly");
        }

        [TestMethod]
        public void TestListNoEntity()
        {
            string xml = @"<list>   
                                <item>1</item>
                                <item>2</item>                
                                <item>3</item>                
                                <item>4</item>                
                                <item>5</item>                
                                <item>6</item>                
                            </list>";

            var list = SuperConfig.Mapping<List<int>>(XElement.Parse(xml));

            Assert.AreEqual(list.First(), 1);
            Assert.AreEqual(list.Count, 6);
        }

        [TestMethod]
        public void TestArray()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <friends> 
                                    <friend userName='hx' email='xxx@qq.com' age='35'></friend>
                                    <friend>
                                        <userName>wy</userName>
                                        <email>ly@qq.com</email>
                                        <age>30</age> 
                                    </friend> 
                                </friends>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Friends.First().Age, 35);
            Assert.AreEqual(user.Friends.Last().UserName, "wy");
        }

        [TestMethod]
        public void TestArrayNoEntity()
        {
            string xml = @"<users> 
                                <user userName='hx' email='xxx@qq.com' age='35'></user>
                                <user>
                                    <userName>wy</userName>
                                    <email>ly@qq.com</email>
                                    <age>30</age> 
                                </user> 
                            </users>";

            var array = SuperConfig.Mapping<UserInfo[]>(XElement.Parse(xml));


            Assert.AreEqual(array.First().UserName, "hx");
            Assert.AreEqual(array.Last().Age, 30);
        }

        [TestMethod]
        public void TestDictionary()
        {
            string xml = @"<userInfo userName='Emrys' email='i@emrys.me' age='27'>   
                                <colleagues> 
                                     <colleague>
                                        <key>1</key>
                                        <value>
                                            <userName>zfx</userName>
                                            <email>wy@qq.com</email>
                                            <age>100</age> 
                                        </value>
                                    </colleague>
                                    <colleague>
                                        <key>2</key>
                                        <value>
                                            <userName>zk</userName>
                                            <email>zk@qq.com</email>
                                            <age>30</age> 
                                        </value>
                                    </colleague>
                                </colleagues>   
                            </userInfo>";

            UserInfo user = SuperConfig.Mapping<UserInfo>(XElement.Parse(xml));

            Assert.AreEqual(user.UserName, "Emrys");
            Assert.AreEqual(user.Email, "i@emrys.me");
            Assert.AreEqual(user.Age, 27);

            Assert.AreEqual(user.Colleagues[1].Age, 100);
            Assert.AreEqual(user.Colleagues[1].UserName, "zfx");
            Assert.AreEqual(user.Colleagues[2].Email, "zk@qq.com");


        }
         
        [TestMethod]
        public void TestDictionaryNoEntity()
        {
            string xml = @"<colleagues> 
                              <colleague>
                                <key>1</key>
                                <value>
                                    <userName>zfx</userName>
                                    <email>wy@qq.com</email>
                                    <age>100</age> 
                                </value>
                            </colleague>
                            <colleague>
                                <key>2</key>
                                <value>
                                    <userName>zk</userName>
                                    <email>zk@qq.com</email>
                                    <age>30</age> 
                                </value>
                            </colleague>
                         </colleagues>";

            var dic = SuperConfig.Mapping<Dictionary<int, UserInfo>>(XElement.Parse(xml));

     

            Assert.AreEqual(dic[1].Age, 100);
            Assert.AreEqual(dic[1].UserName, "zfx");
            Assert.AreEqual(dic[2].Email, "zk@qq.com");


        }

    }
}
