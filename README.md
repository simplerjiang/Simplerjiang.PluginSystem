# Simplerjiang.PluginSystem

一个基于 **.NET Standard 2.0** 的轻量插件加载类库，用于从指定目录扫描程序集并加载其中的类型。

English summary: a minimal plugin loader for .NET that scans a directory, loads assemblies, and returns discovered types.

## 项目定位

这个项目不是一个“重量级插件框架”，而是一个足够直接的小型基础库，适合：

- 桌面工具的扩展机制
- 可插拔模块实验
- 动态发现程序集中的类型
- 想做模块化但不想先引入大型框架的项目

## 当前实现

根据当前源码，核心类只有一个：`PluginsLoader`。

它提供两种初始化方式：

- `new PluginsLoader()`：默认从当前运行目录下的 `Plugins` 文件夹加载
- `new PluginsLoader(string specialPath)`：从自定义目录加载

当前公开能力的核心方法是：

- `LoadPlugin()`：扫描插件目录下的程序集文件，加载后返回其中的 `List<Type>`

## 目标框架

- `netstandard2.0`

## Quick Start

### 默认从 `./Plugins` 目录加载

```csharp
using Simplerjiang.PluginSystem;

var loader = new PluginsLoader();
List<Type> pluginTypes = loader.LoadPlugin();

foreach (var type in pluginTypes)
{
    Console.WriteLine(type.FullName);
}
```

### 指定自定义插件目录

```csharp
using Simplerjiang.PluginSystem;

var loader = new PluginsLoader(@"D:\MyPlugins");
List<Type> pluginTypes = loader.LoadPlugin();
```

## 工作方式

当前实现逻辑非常直接：

1. 确定插件目录路径
2. 枚举目录中的文件
3. 使用 `Assembly.LoadFile(...)` 加载程序集
4. 使用 `assembly.GetTypes()` 收集类型并返回

这种方式的优点是：

- API 少，容易理解
- 没有额外约束，适合快速集成
- 对原型项目和内部工具比较友好

## 适用提醒

由于这是一个极简实现，实际业务项目中如果你需要更强的能力，可能还会继续扩展：

- 插件接口约束
- 元数据声明
- 隔离加载上下文
- 异常与版本冲突处理
- 插件热更新

但如果你的目标只是先把“插件目录扫描 + 类型发现”跑通，这个仓库就是一个干净的起点。

## Source

核心实现文件：`Simplerjiang.PluginSystem/PluginLoader.cs`