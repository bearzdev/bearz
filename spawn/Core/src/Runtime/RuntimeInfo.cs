namespace Spawn.Runtime;

public static class RuntimeInfo
{
    public static bool IsWindows => OperatingSystem.IsWindows();

    public static bool IsLinux => OperatingSystem.IsLinux();

    public static bool IsMacOS => OperatingSystem.IsMacOS();

    public static bool IsAndroid => OperatingSystem.IsAndroid();

    public static bool IsIOS => OperatingSystem.IsIOS();

    public static bool IsBrowser => OperatingSystem.IsBrowser();

    public static bool IsMobile => IsAndroid || IsIOS;
}