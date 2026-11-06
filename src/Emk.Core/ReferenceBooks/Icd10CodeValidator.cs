using System.Text.RegularExpressions;

namespace Emk.Core.ReferenceBooks;

/// <summary>Проверка кода диагноза перед записью в медицинскую карту.</summary>
public static class Icd10CodeValidator
{
    // Буква, две цифры и необязательная часть после точки: J45, J45.0, S72.01
    private static readonly Regex Format = new(@"^[A-Z]\d{2}(\.\d{1,2})?$", RegexOptions.Compiled);

    public static bool IsValid(string code, Icd10Reference reference) =>
        !string.IsNullOrWhiteSpace(code)
        && Format.IsMatch(code.Trim().ToUpperInvariant())
        && reference.Contains(code);
}
