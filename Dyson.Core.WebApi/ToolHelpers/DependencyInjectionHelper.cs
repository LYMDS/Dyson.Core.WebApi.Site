using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Autofac;
using System.Collections.Generic;

namespace Dyson.Core.WebApi.ToolHelpers
{
    /// <summary>
    /// 依赖注入帮助类
    /// </summary>
    public class DependencyInjectionHelper
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public DependencyInjectionHelper(ContainerBuilder _builder) 
        {
            builder = _builder;
        }

        public ContainerBuilder builder;

        public void AddAssemblyFromDllToMvcBuilder(IMvcBuilder mvcBuilder, string dllName)
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
        public void AddAssemblyFromDll(string dllName) 
        {
            var assemblies = AssemblyLoadContext.Default.Assemblies;
            if (!assemblies.Any(o => o.FullName.Contains(Path.GetFileNameWithoutExtension(dllName))))
            {
                var dllFile = AppContext.BaseDirectory + dllName;
                Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile);
            }
        }

        /// <summary>
        /// 废弃方法
        /// </summary>
        /// <param name="dllName">程序集名称</param>
        public void discard(string dllName) 
        {
            var assemblies = AssemblyLoadContext.Default.Assemblies;
            
            if (!assemblies.Any(o => o.FullName.Contains(Path.GetFileNameWithoutExtension(dllName))))
            {
                var dllFile = AppContext.BaseDirectory + dllName;
                Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile);
                var res = builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().AsSelf();
            }
        }


        /// <summary>
        /// 自动注入程序集IOC容器
        /// </summary>
        /// <param name="dllName">程序集名称</param>
        public void AddAssemblyFromDllToAutoFac(string dllName)
        {
            var dllFile = AppContext.BaseDirectory + dllName;
            Assembly assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllFile);
            // 将程序集注入AutoFac容器,以接口暴露或者本体类
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().AsSelf();
        }

        /// <summary>
        /// 通过配置文件加载IOC容器
        /// </summary>
        /// <param name="AssemblyList">程序集名称列表</param>
        public void AddAssemblysFromConfig(List<string> AssemblyList) 
        {
            if (AssemblyList != null && AssemblyList.Count > 0) 
            {
                foreach (string i in AssemblyList) 
                {
                    AddAssemblyFromDllToAutoFac(i);
                }
            }
        }
    }
}
