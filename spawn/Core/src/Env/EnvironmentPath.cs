using System.Collections;
using System.Text;

using Spawn.Runtime;

namespace Spawn.Env;

public class EnvironmentPath : IEnvironmentPath
{
    private static readonly string PathKey = RuntimeInfo.IsWindows ? "Path" : "PATH";

    public EnvironmentPath(IEnvironmentVariables vars)
    {
        this.Vars = vars;
    }

    public string Home
    {
        get
        {
            var home = this.Vars.Get("HOME") ?? this.Vars.Get("UserProfile");
            if (home is not null)
                return home;

            var user = this.Vars.Get("USER") ?? this.Vars.Get("USERNAME");
            if (user is not null)
            {
                if (OperatingSystem.IsWindows())
                {
                    var systemDrive = this.Vars.Get("SystemDrive") ?? "C:";
                    return $"${systemDrive}\\Users\\{user}";
                }
                else
                {
                    return $"/home/{user}";
                }
            }

            throw new InvalidOperationException("Could not determine home directory");
        }
    }

    public string HomeConfigDir
    {
        get
        {
            var specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (string.IsNullOrEmpty(specialFolder))
                return Path.Join(this.Home, ".config");

            return specialFolder;
        }
    }

    public string HomeDataDir
    {
        get
        {
            var specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            if (string.IsNullOrEmpty(specialFolder))
                return Path.Join(this.Home, ".local", "share");

            return specialFolder;
        }
    }

    public string DesktopDir
    {
        get
        {
            var specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (string.IsNullOrEmpty(specialFolder))
                return Path.Join(this.Home, "Desktop");

            return specialFolder;
        }
    }

    public string DownloadsDir => Path.Join(this.Home, "Downloads");

    public string DocumentsDir
    {
        get
        {
            var specialFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (string.IsNullOrEmpty(specialFolder))
                return Path.Join(this.Home, "Documents");

            return specialFolder;
        }
    }

    public string TmpDir => Path.GetTempPath();

    protected IEnvironmentVariables Vars { get; }

    public bool Has(string path)
    {
        var paths = this.Vars.Get(PathKey) ?? string.Empty;
        var comparison = OperatingSystem.IsWindows() ?
            StringComparison.OrdinalIgnoreCase :
            StringComparison.Ordinal;

        return path.Split(Path.PathSeparator).Any(p => paths.Contains(p, comparison));
    }

    public void Delete(string path)
    {
        var paths = this.Vars.Get(PathKey) ?? string.Empty;
        var comparison = OperatingSystem.IsWindows() ?
            StringComparison.OrdinalIgnoreCase :
            StringComparison.Ordinal;

        var sb = new StringBuilder();

        foreach (var p in paths.Split(Path.PathSeparator))
        {
            if (!p.Equals(path, comparison))
            {
                if (sb.Length > 0)
                    sb.Append(Path.PathSeparator);
                sb.Append(p);
            }
        }

        this.Vars.Set(PathKey, sb.ToString());
    }

    public void Append(string path)
    {
        if (this.Has(path))
            return;

        var paths = this.Vars.Get(PathKey) ?? string.Empty;
        var newPath = $"{paths}{Path.PathSeparator}{path}";
        this.Vars.Set(PathKey, newPath);
    }

    public void Prepend(string path)
    {
        if (this.Has(path))
            return;

        var paths = this.Vars.Get(PathKey) ?? string.Empty;
        var newPath = $"{path}{Path.PathSeparator}{paths}";
        this.Vars.Set(PathKey, newPath);
    }

    public IEnumerator<string> GetEnumerator()
    {
        var paths = this.Vars.Get(PathKey) ?? string.Empty;
        foreach (var next in paths.Split(Path.PathSeparator))
            yield return next;
    }

    IEnumerator IEnumerable.GetEnumerator()
        => this.GetEnumerator();

    public override string ToString()
    {
        return this.Vars.Get(PathKey) ?? string.Empty;
    }
}