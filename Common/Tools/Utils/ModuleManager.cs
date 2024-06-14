namespace Tools.Utils;

public static class ModuleManager
{
    private static Dictionary<string, string>? _modules = new();

    public static Dictionary<string, string>? GetModules()
    {
        return _modules;
    }

    public static void AddModule(string title, string pageName)
    {
        if (_modules == null)
        {
            throw new NullReferenceException("The module should not be empty or null.");
        }

        if (!_modules.Any(x => x.Key == title))
        {
            _modules.TryAdd(title, pageName);
        }
    }
}
