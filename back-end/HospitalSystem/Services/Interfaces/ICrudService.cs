using System.Security.Claims;
using FluentResults;

namespace Services.Interfaces;

public interface ICrudService<TModel> where TModel : class
{
    Task<Result<TModel>> AddAsync(TModel model, ClaimsPrincipal? principal = null);
    Task<Result> DeleteAsync(int id, ClaimsPrincipal? principal = null);
    Task<Result> EditAsync(TModel model, ClaimsPrincipal? principal = null);
    Task<TModel?> GetByIdAsync(int id);
}