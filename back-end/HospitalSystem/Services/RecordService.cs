using DataAccess.Entity;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using BusinessLogicLayer.Services;
using Services.Models;

namespace Services
{
    public class RecordService : CrudService<RecordModel, Record>
    {
        public RecordService(ApplicationContext context, UserManager<User> userManager) : base(context, userManager)
        {
        }
         
    }
}
