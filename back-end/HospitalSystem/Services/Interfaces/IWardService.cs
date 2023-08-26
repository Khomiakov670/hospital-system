using Services.Models;

namespace Services;

public interface IWardService
{
    Task<PageModel<WardModel>> GetAsync(int page, string query);
}