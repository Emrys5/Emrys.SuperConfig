using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Mapping.Mappingers
{
    /// <summary>
    /// KeyValuePair Mappinger
    /// </summary>
    public class KeyValueMappinger : BaseMappinger, IMappinger
    {
        public object Mapping(XElement element, Type type)
        { 
            var typeArgs = type.GetGenericArguments(); 
            var keyValueType = typeof(KeyValueBuild<,>).MakeGenericType(typeArgs); 
            var keyValueInstance = MappingerSelector.Get(keyValueType, ConvertCaseStrategy).Mapping(element, keyValueType);  
            var property = keyValueType.GetProperty("KeyValue"); 
            return property.GetValue(keyValueInstance);
        }

        public bool IsCanMapping(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(KeyValuePair<,>);
        }
    }


    /// <summary>
    /// 创建一个具体的keyvalue类型，用于发射获取值
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class KeyValueBuild<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public KeyValuePair<TKey, TValue> KeyValue
        {
            get
            {
                return new KeyValuePair<TKey, TValue>(Key, Value);
            }
        }
    }
}
