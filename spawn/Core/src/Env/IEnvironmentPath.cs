namespace Spawn.Env;

public interface IEnvironmentPath : IEnumerable<string>
{
    void Append(string path);

    void Delete(string path);

    bool Has(string path);

    void Prepend(string path);
}