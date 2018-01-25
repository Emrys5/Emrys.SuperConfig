# Emrys.SuperConfig

It is easier to use configuration in .Net.
  
在.Net更加容易的使用配置文件。

## Get Started


### 1.A new class name is UserInfo
```
class UserInfo
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string BlogUrl { get; set; }
    public Color FavoriteColor { get; set; }
    public Color DislikeColor { get; set; } 
    public List<string> Language { get; set; }
   
}
enum Color{Red,Blue,Black} 
```


### 2.Configuration in Web.config/App.config
```
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <configSections>
    <section name="userInfo" type="Emrys.SuperConfig.Section,Emrys.SuperConfig"></section>
  </configSections>
  <userInfo userName="Emrys" email="i@emrys.me" age="27">
    <blogUrl>http://www.cnblogs.com/emrys5/</blogUrl>
    <favoriteColor>Blue</favoriteColor>
    <dislikeColor>2</dislikeColor> 
    <language>
      <value>Putonghua</value>
      <value>Huaipu</value>
      <value>English</value>
    </language> 
  </userInfo> 
</configuration>
```

### 3.Get config
```
 var user = SuperConfig<UserInfo>.Value;
```

Done!!!!!
 

## English wiki
1. [Get Started](https://github.com/Emrys5/Emrys.SuperConfig/wiki/1.-Get-Started)
2. [Support for data types](https://github.com/Emrys5/Emrys.SuperConfig/wiki/2.-Support-for-data-types)
3. [Custom config file location](https://github.com/Emrys5/Emrys.SuperConfig/wiki/3.-Custom-config-file-location)
4. [Custom config file naming rules](https://github.com/Emrys5/Emrys.SuperConfig/wiki/4.-Custom-config-file-naming-rules)
5. [Custom Section format](https://github.com/Emrys5/Emrys.SuperConfig/wiki/5.-Custom-Section-format)
6. [Custom location, naming rules, and Section format](https://github.com/Emrys5/Emrys.SuperConfig/wiki/6.-Custom-location,-naming-rules,-and-Section-format)
## Chinese wiki
1. [开始使用 入门](https://github.com/Emrys5/Emrys.SuperConfig/wiki/1.-%E5%BC%80%E5%A7%8B%E4%BD%BF%E7%94%A8-%E5%85%A5%E9%97%A8)
2. [支持数据类型](https://github.com/Emrys5/Emrys.SuperConfig/wiki/2.-%E6%94%AF%E6%8C%81%E6%95%B0%E6%8D%AE%E7%B1%BB%E5%9E%8B)
3. [自定义配置文件位置](https://github.com/Emrys5/Emrys.SuperConfig/wiki/3.-%E8%87%AA%E5%AE%9A%E4%B9%89%E9%85%8D%E7%BD%AE%E6%96%87%E4%BB%B6%E4%BD%8D%E7%BD%AE)
4. [自定义配置文件命名规则](https://github.com/Emrys5/Emrys.SuperConfig/wiki/4.-%E8%87%AA%E5%AE%9A%E4%B9%89%E9%85%8D%E7%BD%AE%E6%96%87%E4%BB%B6%E5%91%BD%E5%90%8D%E8%A7%84%E5%88%99)
5. [自定义Section格式](https://github.com/Emrys5/Emrys.SuperConfig/wiki/5.-%E8%87%AA%E5%AE%9A%E4%B9%89Section%E6%A0%BC%E5%BC%8F)
6. [ 同时自定义位置、命名规则和Section格式](https://github.com/Emrys5/Emrys.SuperConfig/wiki/6.-%E5%90%8C%E6%97%B6%E8%87%AA%E5%AE%9A%E4%B9%89%E4%BD%8D%E7%BD%AE%E3%80%81%E5%91%BD%E5%90%8D%E8%A7%84%E5%88%99%E5%92%8CSection%E6%A0%BC%E5%BC%8F)








