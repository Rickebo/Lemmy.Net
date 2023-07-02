namespace Lemmy.Net.Types;

public interface IPaginatedResult
{
    public long? Limit { get; set; }
    public long? Page { get; set; }
}