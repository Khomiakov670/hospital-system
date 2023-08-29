using System.Linq.Expressions;
using DataAccess;
using DataAccess.Entity;
using Services.Models;

namespace Services;

public class SnapshotsService : CrudService<SnapshotsModel, Snapshots>, ISnapshotsService
{
    public SnapshotsService(ApplicationContext context) : base(context)
    {
    }

    public async Task<PageModel<SnapshotsModel>> GetAsync(int page)
    {
        return await GetAsync(page,
            x => x.Apparatus.Id, false);
    }

    /*public async Task<PageModel<Snapshots>> GetAsync(int page, int? pulse, int? systolicPressure,
        int? diastolicPressure)
    {
        var expressions = new List<Expression<Func<Snapshots, bool>>>();


        if (pulse is not null)
        {
            expressions.Add(x => pulse == x.Pulse);
        }

        if (systolicPressure is not null)
        {
            expressions.Add(x => systolicPressure == x.SystolicPressure);
        }

        if (diastolicPressure is not null)
        {
            expressions.Add(x => diastolicPressure == x.DiastolicPressure);
        }

        return await base.GetAsync(page: page,
            keySelector: x => x.Id,
            isDesc: false,
            predicates: expressions.ToArray()
        );
    }*/
}