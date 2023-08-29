using System.Linq.Expressions;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Services.Models;

namespace Services;

public class WardService: CrudService<WardModel, Ward>, IWardService
{
    public WardService(ApplicationContext context) : base(context)
    {
    }

    public async Task<PageModel<WardModel>> GetAsync(int page, string type , int? floor,int? capacity, int? number)
    {
        var expressions = new List<Expression<Func<Ward, bool>>>()
        {
            x =>
                x.Type.Contains(type)
        };
        
        if (floor is not null)
        {
            expressions.Add(x => floor == x.Floor);
        }
        
        if (capacity is not null)
        {
            expressions.Add(x => capacity == x.Capacity);
        }
        if (number is not null)
        {
            expressions.Add(x => number == x.Number);
        }
        
        return await base.GetAsync(page: page,
            keySelector: x => x.Id,
            isDesc: false,
            predicates: expressions.ToArray()
        );
    }
    
}