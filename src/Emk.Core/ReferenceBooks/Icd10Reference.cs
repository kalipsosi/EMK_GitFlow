namespace Emk.Core.ReferenceBooks;

/// <summary>Справочник диагнозов МКБ-10, обновляемый из внешнего источника.</summary>
public class Icd10Reference
{
    private readonly Dictionary<string, string> _codes = new(StringComparer.OrdinalIgnoreCase);

    public int Count => _codes.Count;

    /// <summary>Загружает новую версию справочника вместо текущей.</summary>
    public void Load(IEnumerable<(string Code, string Name)> entries)
    {
        _codes.Clear();
        foreach (var (code, name) in entries)
            _codes[code.Trim()] = name.Trim();
    }

    public bool Contains(string code) => _codes.ContainsKey(code.Trim());

    public string? GetName(string code) => _codes.TryGetValue(code.Trim(), out string? name) ? name : null;
}
