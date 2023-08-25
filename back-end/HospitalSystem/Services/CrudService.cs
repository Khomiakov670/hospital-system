using System.Linq.Expressions;
using DataAccess;
using DataAccess.Entity;
using FluentResults;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services.Constants;
using Services.Interfaces;
using Services.Models;

namespace Services;

public class CrudService<TModel, TEntity> : ICrudService<TModel>
    where TModel : class
    where TEntity : class

{
    protected readonly ApplicationContext _context;
    protected readonly UserManager<User> _userManager;

    public CrudService(ApplicationContext context, UserManager<User> userManager)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<Result<TModel>> AddAsync(TModel model)
    {
        var entity = model.Adapt<TEntity>();
        await _context.AddAsync(entity);

        await _context.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> DeleteAsync(int id)
    {
        var entity = await _context.FindAsync<TEntity>(id);
        if (entity is null)
            return Result.Fail(Errors.NotFound);
        _context.Remove(entity);

        await _context.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<Result> EditAsync(TModel model)
    {
        var entity = model.Adapt<TEntity>();
        _context.Update(entity);

        await _context.SaveChangesAsync();
        return Result.Ok();
    }

    public async Task<TModel?> GetByIdAsync(int id)
    {
        var entity = await _context.FindAsync<TEntity>(id);
        return entity?.Adapt<TModel>();
    }

    protected async Task<PageModel<TModel>> GetAsync(int page,
        Expression<Func<TEntity, bool>> predicate,
        bool isDesc = false,
        params Expression<Func<TEntity, object>>[] keySelectors)
    {
        var query = _context.Set<TEntity>().Where(predicate);
        if (keySelectors.Length > 0)
        {
            var queryOrdered = isDesc ? query.OrderByDescending(keySelectors[0]) : query.OrderBy(keySelectors[0]);
            switch (keySelectors.Length)
            {
                case 0:
                    throw new ArgumentException(string.Empty, nameof(keySelectors));
                case > 1:
                {
                    queryOrdered = keySelectors.Aggregate(queryOrdered, (current, selector) => isDesc ? current.ThenByDescending(selector) : current.ThenBy(selector));
                    break;
                }
            }

            query = queryOrdered;
        }

        var entities = await query.Skip((page - 1) * 10)
            .Take(10)
            .ToListAsync();
        var models = entities.Adapt<List<TModel>>();
        return new PageModel<TModel>(models, query.Count());
    }
}