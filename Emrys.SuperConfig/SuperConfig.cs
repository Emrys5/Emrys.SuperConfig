using Emrys.SuperConfig.Mapping;
using Emrys.SuperConfig.Strategy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Emrys.SuperConfig
{
    /// <summary>
    /// SuperClass class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class SuperConfig<T>
    {
        private static readonly SuperConfigEngine _superConfigEngine = new SuperConfigEngine();

        private static object _lock = new object();
        private static T _T;
        public static T Value
        {
            get
            {
                if (_T == null)
                {
                    lock (_lock)
                    {
                        if (_T == null)
                        {
                            _T = _superConfigEngine.Mapping<T>();
                        }

                    }
                }
                return _T;
            }
        }

        public static void Setting(string sectionName = null, string filePath = null, Func<string, string> funcConvertCase = null, Func<string, string, IConvertCaseStrategy, Section> funcSection = null)
        {

            IConvertCaseStrategy convertCaseStrategy =
                funcConvertCase == null
                ? (IConvertCaseStrategy)new DefaultConvertCaseStrategy()
                : new SettingConvertCaseStrategy(funcConvertCase);

            ISuperConfigStrategy superConfigStrategy =
                funcSection == null
                ? (ISuperConfigStrategy)new DefaultSuperConfigStrategy(convertCaseStrategy)
                : new SettingSuperConfigStrategy(convertCaseStrategy, funcSection);

            _T = _superConfigEngine.Mapping<T>(sectionName, filePath, superConfigStrategy);
        }

        public static void Setting(string sectionName)
        {
            Setting(sectionName, null, null, null);
        }

        public static void SettingFilePath(string filePath)
        {
            Setting(null, filePath, null, null);
        }

        public static void Setting(string filePath, Func<string, string, IConvertCaseStrategy, Section> funcSection)
        {
            Setting(null, filePath, null, funcSection);
        }

        public static void Setting(Func<string, string> funcConvertCase)
        {
            Setting(null, null, funcConvertCase, null);
        }

        public static void Setting(string sectionName = null, Func<string, string> funcConvertCase = null)
        {
            Setting(sectionName, null, funcConvertCase, null);
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="element">XElement对象。</param>
        /// <returns></returns>
        public static T Mapping(XElement element, IConvertCaseStrategy convertCaseStrategy = null)
        {
            return (T)_superConfigEngine.Mapping(typeof(T), element, convertCaseStrategy);
        }
    }


    class SettingConvertCaseStrategy : IConvertCaseStrategy
    {
        private Func<string, string> _func = null;
        public SettingConvertCaseStrategy(Func<string, string> func)
        {
            _func = func;
        }
        public string ConvertCase(string name)
        {
            return _func(name);
        }
    }

    class SettingSuperConfigStrategy : ISuperConfigStrategy
    {

        private IConvertCaseStrategy _convertCaseStrategy;
        private Func<string, string, IConvertCaseStrategy, Section> _funcSection;

        public SettingSuperConfigStrategy(IConvertCaseStrategy convertCaseStrategy, Func<string, string, IConvertCaseStrategy, Section> funcSection)
        {
            _convertCaseStrategy = convertCaseStrategy;
            _funcSection = funcSection;
        }

        public string ConvertCase(string name)
        {
            return _convertCaseStrategy.ConvertCase(name);
        }

        public Section GetSection(string sectionName, string filePath = null)
        {
            return _funcSection(sectionName, filePath, _convertCaseStrategy);
        }
    }



    /// <summary>
    /// SuperClass class
    /// </summary>
    public static class SuperConfig
    {
        private static readonly SuperConfigEngine _superConfigEngine = new SuperConfigEngine();
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="element">XElement对象。</param>
        /// <returns></returns>
        public static object Mapping(Type type, XElement element, IConvertCaseStrategy convertCaseStrategy = null)
        {
            return _superConfigEngine.Mapping(type, element, convertCaseStrategy);
        }


        public static T Mapping<T>(XElement element, IConvertCaseStrategy convertCaseStrategy = null)
        {
            return (T)Mapping(typeof(T), element, convertCaseStrategy);
        }

    }
}
