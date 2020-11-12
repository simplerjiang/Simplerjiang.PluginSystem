using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Simplerjiang.PluginSystem
{
     public class PluginsLoader
    {
        public PluginsLoader()
        {
            pluginsPath = GetPluginsPath();
        }

        public PluginsLoader(string specialPath)
        {
            pluginsPath = specialPath;
        }

        private string pluginsPath;

        private string GetPluginsPath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "Plugins");
        }

        private FileInfo[] GetAllPluginsPath()
        {
            var files = new DirectoryInfo(pluginsPath).GetFiles();
            return files;
        }

        public List<Type> LoadPlugin()
        {
            var types = new List<Type>();
            foreach (var file in GetAllPluginsPath())
            {
                var assembly = Assembly.LoadFile(file.FullName);
                types.AddRange(assembly.GetTypes());
            }
            return types;
        }
    }
}
