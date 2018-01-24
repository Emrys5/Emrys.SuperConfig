using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Strategy
{
    public interface IConvertCaseStrategy
    {
        string ConvertCase(string name);
    }
}
