using DataAccess.Entity;
using DataAccess;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Services
{
    public class RecordService
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        public RecordService(ApplicationContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.configuration = configuration;
        }

       
    }
}
