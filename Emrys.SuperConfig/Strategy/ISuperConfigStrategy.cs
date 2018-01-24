using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Strategy
{
    public interface ISuperConfigStrategy : IConvertCaseStrategy
    {
        Section GetSection(string sectionName, string filePath = null);
         
    }
}
