using Services.Interfaces;
using Services.Models;

namespace Services;

public interface IWardService : ICrudService<WardModel>
{
    Task<PageModel<WardModel>> GetAsync(int page, string type , int? floor,int? capacity, int? number);
}