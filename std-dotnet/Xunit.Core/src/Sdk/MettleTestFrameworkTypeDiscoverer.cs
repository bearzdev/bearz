using System;

using Xunit.Abstractions;

namespace Xunit.Sdk
{
    public class MettleTestFrameworkTypeDiscoverer : ITestFrameworkTypeDiscoverer
    {
        public Type GetTestFrameworkType(IAttributeInfo attribute)
        {
            var frameworkType = attribute.GetNamedArgument<Type?>("CustomFrameworkType");
            return frameworkType ?? typeof(MettleTestFramework);
        }
    }
}