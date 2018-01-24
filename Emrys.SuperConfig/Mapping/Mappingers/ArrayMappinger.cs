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
    public class ArrayMappinger : BaseMappinger, IMappinger
    {
        public object Mapping(XElement element, Type type)
        {

            var listType = typeof(List<>);
            var arrayType = type.GetElementType();
            listType = listType.MakeGenericType(arrayType);

            IMappinger mappinger = MappingerSelector.Get(listType, ConvertCaseStrategy);

            var list = mappinger.Mapping(element, listType);


            return (Array)listType.GetMethod("ToArray").Invoke(list, null);

        }

        public bool IsCanMapping(Type type)
        {
            // 是数组而且是一维数组
            return type.IsArray && type.GetArrayRank() == 1;
        }
    }



}
