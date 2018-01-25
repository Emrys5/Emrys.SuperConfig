# Emrys.SuperConfig

It is easier to use configuration in Web.config/App.config.

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











