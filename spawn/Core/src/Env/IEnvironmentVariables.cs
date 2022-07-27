namespace Spawn.Env;

public interface IEnvironmentVariables
{
    IEnumerable<string> Keys { get; }

    void Delete(string name);

    string? Get(string name);

    bool Has(string name);

    void Set(string name, string value, bool isSecret = false);
}