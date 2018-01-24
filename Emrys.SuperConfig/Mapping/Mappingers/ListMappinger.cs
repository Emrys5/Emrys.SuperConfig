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
    public class ListMappinger : BaseMappinger, IMappinger
    {
        public object Mapping(XElement element, Type type)
        {
            //  创建List的实例
            var listTypeInstance = (IList)Activator.CreateInstance(type);

            var genericArg = type.GetGenericArguments().Single();
            var mappinger = MappingerSelector.Get(genericArg, ConvertCaseStrategy);

            // 获取所有的element子项
            foreach (var item in element.Elements())
            {
                var itemMappinger = mappinger.Mapping(item, genericArg);
                listTypeInstance.Add(itemMappinger);
            }

            return listTypeInstance;

        }

        public bool IsCanMapping(Type type)
        {
            return type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(List<>));
        }
    }



}
