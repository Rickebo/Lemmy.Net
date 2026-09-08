namespace Lemmy.Net.Types;

public interface IPaginatedResult
{
    long? Limit { get; set; }
    long? Page { get; set; }
}
