using Emrys.SuperConfig.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Mapping.Mappingers
{
    /// <summary>
    /// List Mappinger
    /// </summary>
    public class DictionaryMappinger : BaseMappinger, IMappinger
    {

        const string keyName = "Key";
        const string valueName = "Value";

        public object Mapping(XElement element, Type type)
        {
            // Dictionary
            var listTypeInstance = (IDictionary)Activator.CreateInstance(type);

            var genericArg = type.GetGenericArguments();

            var keyType = genericArg.First();
            var valueType = genericArg.Last();

            var mappingerKey = MappingerSelector.Get(keyType, ConvertCaseStrategy);
            var mappingerValue = MappingerSelector.Get(valueType, ConvertCaseStrategy);

            var convertCaseKeyName = ConvertCaseStrategy.ConvertCase(keyName);
            var convertCaseValueName = ConvertCaseStrategy.ConvertCase(valueName);

            // 获取所有的element子项
            foreach (var item in element.Elements())
            { 
                var key = GetValue(item, mappingerKey, keyType, convertCaseKeyName);
                var value = GetValue(item, mappingerValue, valueType, convertCaseValueName);

                if (key != null && value != null)
                {
                    object keyValue = Convert.ChangeType(key, keyType);
                    object valueValue = Convert.ChangeType(value, valueType);

                    if (listTypeInstance.Contains(keyValue))
                    {
                        throw new SuperConfigException("Dictionary key 重复！");
                    }
                    listTypeInstance.Add(keyValue, valueValue);
                }
            }

            return listTypeInstance;

        }

        public bool IsCanMapping(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Dictionary<,>));
        }


        /// <summary>
        /// 获取key value值
        /// </summary>
        /// <param name="element"></param>
        /// <param name="mappinger"></param>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private object GetValue(XElement element, IMappinger mappinger, Type type, string name)
        {
            var attribute = element.Attributes().Where(i => i.Name == name).FirstOrDefault();
            if (attribute != null)
            {
                return attribute.Value;
            }

            var ele = element.Elements().Where(i => i.Name == name).FirstOrDefault();
            if (ele != null)
            {
                return mappinger.Mapping(ele, type);
            }

            return null;
        }
    }



}
