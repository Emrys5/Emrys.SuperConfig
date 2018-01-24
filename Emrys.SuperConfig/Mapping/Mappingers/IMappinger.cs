using Emrys.SuperConfig.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig.Mapping.Mappingers
{
    /// <summary>
    /// xml element所对应的mapping
    /// </summary>
    public interface IMappinger
    {
        IConvertCaseStrategy ConvertCaseStrategy { get; set; }

        // 执行mapping
        object Mapping(XElement element, Type type);

        // 判断类型是否可以装成目标类型
        bool IsCanMapping(Type type);
    }
}
