using Xunit;

namespace Mettle.Xunit.Asserts.Tests;

public class UnitTest1
{
    private static readonly IAssert Assert = FlexAssert.Default;

    [Fact]
    public void Test1()
    {
        const int i = 5, j = 6;
        Assert.NotEqual(i, j);
    }
}