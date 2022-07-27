namespace Spawn.Env;

public class EnvironmentVariables : IEnvironmentVariables
{
    private readonly HashSet<string> secrets = new();

    public virtual IEnumerable<string> Keys
    {
        get
        {
            foreach (var key in Environment.GetEnvironmentVariables())
            {
                if (key is string k)
                {
                    yield return k;
                }
            }
        }
    }

    public virtual string? Get(string name)
    {
        return Environment.GetEnvironmentVariable(name);
    }

    public virtual bool Has(string name)
    {
        return Environment.GetEnvironmentVariable(name) != null;
    }

    public virtual void Delete(string name)
    {
        Environment.SetEnvironmentVariable(name, null);
    }

    public virtual void Set(string name, string value, bool isSecret = false)
    {
        if (isSecret && !this.secrets.Contains(name))
        {
            this.secrets.Add(name);
        }

        Environment.SetEnvironmentVariable(name, value);
    }
}