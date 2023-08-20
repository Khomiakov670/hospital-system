using BusinessLogicLayer.Services;
using DataAccess;
using DataAccess.Entity;
using Microsoft.AspNetCore.Identity;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TenantService : CrudService<TenantModel, Tenant>
    {
        private readonly UserManager<User> userManager;
        public TenantService(ApplicationContext context, UserManager<User> userManager) : base(context, userManager)
        {
            this.userManager = userManager;
        }
    }
}
