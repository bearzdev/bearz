using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Xunit.Abstractions;

namespace Xunit.Sdk
{
    public sealed class MettleTestFramework : XunitTestFramework
    {
        public MettleTestFramework(IMessageSink messageSink)
            : base(messageSink)
        {
        }

        protected override ITestFrameworkExecutor CreateExecutor(AssemblyName assemblyName) =>
            new MettleTestFrameworkExecutor(assemblyName, this.SourceInformationProvider, this.DiagnosticMessageSink);
    }
}