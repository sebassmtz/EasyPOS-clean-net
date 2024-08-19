

using System.Reflection;

namespace EasyPOS.Application.DependencyInjection
{
    public class ApplicationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
