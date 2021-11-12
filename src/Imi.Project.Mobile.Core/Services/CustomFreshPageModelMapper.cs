using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Imi.Project.Mobile.Core.Services
{
    public class CustomFreshPageModelMapper : IFreshPageModelMapper
    {
        readonly string pageNamespace;
        readonly string pageAssemblyName;

        public CustomFreshPageModelMapper(string pageNamespace = null, string pageAssemblyName = null)
        {
            this.pageNamespace = pageNamespace;
            this.pageAssemblyName = pageAssemblyName;
        }

        public string GetPageTypeName(Type pageModelType)
        {
            var assemblyQualifiedName = pageModelType.AssemblyQualifiedName;
            if (pageNamespace != null)
                assemblyQualifiedName = assemblyQualifiedName.Replace(pageModelType.Namespace, pageNamespace);
            if (pageAssemblyName != null)
                assemblyQualifiedName = assemblyQualifiedName.Replace(pageModelType.Assembly.ToString(), pageAssemblyName);
            assemblyQualifiedName = assemblyQualifiedName
                .Replace("PageModel", "Page")
                .Replace("ViewModel", "Page");
            return assemblyQualifiedName;
        }
    }
}
