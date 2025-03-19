namespace Steve.Core;

public sealed class CallerInfo
{
    public string? Origin { get; set; }
    public string? FilePath { get; set; }
    public int? LineNumber { get; set; }
}
