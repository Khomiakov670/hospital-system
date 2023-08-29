using Services.Interfaces;
using Services.Models;

namespace Services;

public interface ISnapshotsService: ICrudService<SnapshotsModel>
{
    Task<PageModel<SnapshotsModel>> GetAsync(int page);
}