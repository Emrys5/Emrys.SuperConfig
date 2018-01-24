using Emrys.SuperConfig.Exceptions;
using Emrys.SuperConfig.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emrys.SuperConfig.Mapping.Mappingers
{

    /// <summary>
    /// Mapping选择器
    /// </summary>
    public class MappingerSelector
    {

        private static List<IMappinger> _mappingers;


        /// <summary>
        /// 设置所有的Mappinger
        /// </summary>
        static MappingerSelector()
        {
            _mappingers = new List<IMappinger> {
                new ValueMappinger(),
                new KeyValueMappinger(),
                new ListMappinger(),
                new ArrayMappinger(),
                new DictionaryMappinger()
            };
        }


        /// <summary>
        /// 根据类型选择不同的Mappinger
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IMappinger Get(Type type, IConvertCaseStrategy convertCaseStrategy)
        {
            var canMappingers = _mappingers.Where(i => i.IsCanMapping(type)).ToList();

            if (canMappingers.Count > 1)
            {
                throw new SuperConfigException($"出现多个Mapping选择器！");
            }

            IMappinger mappinger = canMappingers.Count == 0 ? new EntityMappinger() : canMappingers.First();
            mappinger.ConvertCaseStrategy = convertCaseStrategy; 

            return mappinger;
        }
    }
}
