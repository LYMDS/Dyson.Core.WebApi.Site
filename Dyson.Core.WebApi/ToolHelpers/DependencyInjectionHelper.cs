using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;
using System.IO;


namespace Dyson.Core.WebApi.ToolHelpers
{
    /// <summary>
    /// 依赖注入帮助类
    /// </summary>
    public class DependencyInjectionHelper
    {
        /// <summary>
        /// 空构造器
        /// </summary>
        public DependencyInjectionHelper() 
        {
        
        }

        /// <summary>
        /// 注入程序集到Mvc控制器
        /// </summary>
        /// <param name="mvcBuilder">Mvc构建者</param>
        /// <param name="dllName">dll名称</param>
        public static void AddAssemblyFromDllToMvcBuilder(IMvcBuilder mvcBuilder, string dllName)
        {
            Assembly otherWebAPIAssembly = null;
            var assemblies = AssemblyLoadContext.Default.Assemblies;
            if (!assemblies.Any(o => o.FullName.Contains(Path.GetFileNameWithoutExtension(dllName))))
            {
                string dllFile = AppContext.BaseDirectory + dllName;

                otherWebAPIAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile);
            }
            if (otherWebAPIAssembly != null)
            {
                var applicationParts = mvcBuilder.PartManager.ApplicationParts;
                mvcBuilder.AddApplicationPart(otherWebAPIAssembly);
            }
        }

        /// <summary>
        /// 注入逻辑程序
        /// </summary>
        /// <param name="dllName">dll名称</param>
        public static void AddAssemblyFromDll(string dllName) 
        {
            var assemblies = AssemblyLoadContext.Default.Assemblies;
            if (!assemblies.Any(o => o.FullName.Contains(Path.GetFileNameWithoutExtension(dllName))))
            {
                var dllFile = AppContext.BaseDirectory + dllName;
                Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile);
            }
        }
    }
}
