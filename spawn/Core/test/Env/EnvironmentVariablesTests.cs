using Spawn.Env;

namespace Tests;

public static class EnvironmentVariablesTests
{
    [Fact]
    public static void Verify_Get_Path()
    {
        var envVars = new EnvironmentVariables();
        if (OperatingSystem.IsWindows())
        {
            Assert.NotNull(envVars.Get("Path"));
        }
        else
        {
            Assert.Null(envVars.Get("PATH"));
        }
    }
}