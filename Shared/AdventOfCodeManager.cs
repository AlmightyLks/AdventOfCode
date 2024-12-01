using System.Reflection;

namespace Shared;

public static class AdventOfCodeManager
{
    private static readonly Dictionary<Assembly, Dictionary<int, IDay>> _dayCache = new();

    public static Dictionary<int, IDay> FindAllAdventOfCodeDays(Assembly? assembly = null)
    {
        assembly ??= Assembly.GetCallingAssembly();

        if (_dayCache.TryGetValue(assembly, out var days))
            return days;

        days = assembly
            .GetTypes()
            .Where(x => x.GetInterface(nameof(IDay)) != null)
            .Select(x => (IDay)Activator.CreateInstance(x)!)
            .ToDictionary(x => x.Day, x => x);

        _dayCache.Add(assembly, days);

        return days;
    }
}