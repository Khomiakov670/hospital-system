namespace Services.Models;

public record PageModel<TModel>(List<TModel> Items, int TotalCount);