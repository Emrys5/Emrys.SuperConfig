using Emrys.SuperConfig.Mapping;
using Emrys.SuperConfig.Mapping.Mappingers;
using Emrys.SuperConfig.Strategy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Emrys.SuperConfig
{

    /// <summary>
    /// 配置文件主类
    /// </summary>
    class SuperConfigEngine
    {

        /// <summary>
        /// Mapping配置实体类型。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sectionName"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public T Mapping<T>(string sectionName = null, string filePath = null, ISuperConfigStrategy superConfigStrategy = null)
        {
            superConfigStrategy = superConfigStrategy ?? new DefaultSuperConfigStrategy(new DefaultConvertCaseStrategy());

            if (string.IsNullOrWhiteSpace(sectionName))
            {
                // 如果传入的sectionName为空，则以类名第一个字母小写查找。
                sectionName = superConfigStrategy.ConvertCase(typeof(T).Name);
            }

            var xElement = (XElement)superConfigStrategy.GetSection(sectionName, filePath);

            // 执行mapping
            return (T)Mapping(typeof(T), xElement, superConfigStrategy);

        }

        /// <summary>
        /// Mapping配置实体类型。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public object Mapping(Type type, XElement element, IConvertCaseStrategy convertCaseStrategy)
        {

            // 获取mappinger选择器
            IMappinger mappinger = MappingerSelector.Get(type, convertCaseStrategy);

            convertCaseStrategy = convertCaseStrategy ?? new DefaultConvertCaseStrategy();

            // 如果不是entity，直接执行返回值
            if (!(mappinger is EntityMappinger))
            {
                mappinger.ConvertCaseStrategy = convertCaseStrategy;
                return mappinger.Mapping(element, type);
            }


            // 创建实例
            var instance = Activator.CreateInstance(type);

            // 创建 mapping
            ITypeMapping typeMapping = MappingFactory.CreateMapping(type, element, convertCaseStrategy);

            // 执行
            typeMapping.Apply(instance);
            return instance;

        }
    }
}
