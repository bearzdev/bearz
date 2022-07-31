using System;

using Xunit.Sdk;

namespace Xunit
{
    [TestFrameworkDiscoverer(
        "Xunit.Sdk.MettleTestFrameworkTypeDiscoverer",
        "Mettle.Xunit.Core")]
    [AttributeUsage(
        System.AttributeTargets.Assembly,
        Inherited = false,
        AllowMultiple = false)]
    public sealed class MettleTestFrameworkAttribute : System.Attribute,
        ITestFrameworkAttribute
    {
        public MettleTestFrameworkAttribute()
        {
        }

        public Type? CustomFrameworkType { get; set; }
    }
}