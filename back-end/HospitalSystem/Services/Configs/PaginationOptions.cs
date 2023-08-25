namespace API.Options;

public class PaginationOptions
{
    public int ItemsPerPage { get; set; } = 10;

    public const string Section = "Pagination";
}