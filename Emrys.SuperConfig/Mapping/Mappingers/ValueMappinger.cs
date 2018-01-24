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
    /// 直接取值（string，int，bool，int，enum等）
    /// </summary>
    public class ValueMappinger : BaseMappinger, IMappinger
    {
        public object Mapping(XElement element, Type type)
        {
            var converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFromInvariantString(element.Value);
        }

        public bool IsCanMapping(Type type)
        {
            var converter = TypeDescriptor.GetConverter(type);
            return converter.CanConvertFrom(typeof(string));
        }
    }
}
