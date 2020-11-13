# Simplerjiang.PluginSystem
A dotnet standard plugin library 一个.Net Standard 插件操作类库

---

[中文README]()

## How to start?


This is a very easy plugin system, only has one class.

You just need to include it, and instance the class "PluginsLoader"

```C#
            var loader = new PluginsLoader();
            
            //load your plugin files
            //default plugin folder right at the main program running directory with "Plugins" 
            var types = loader.LoadPlugin();
            
            //Also you can specify the Plugins folder path.
            var types = loader.LoadPlugin("../put/your/path/here")
            
            //Get Instance by class name
            var obj = (YourType)loader.InstanceByName("classname");
            
            //Get Instance by Interface name, it will return the first it found.
            //so you don't need to know the actually class name.
            var obj2 = (YourInterface)loader.InstanceByInterfaceName("InterfaceName");
```

If you want to only load one dll, you can do this

```C#
            var loader = new PluginsLoader();
            
            //set path without load
            var path = loader.SpecifyPath("../put/your/path/here");
            
            //load by file name
            var types = loader.LoadPluginByName("filename");
```
