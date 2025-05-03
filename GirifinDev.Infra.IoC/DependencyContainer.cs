using GirifinDev.Application.Interface;
using GirifinDev.Application.Services;
using GirifinDev.Domain.Interface;
using GirifinDev.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GirifinDev.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProjectServices, ProjectServices>();
            services.AddScoped<ICategoryServices, CategoryServices>();
            services.AddScoped<IPageCommentServices,PageCommentServices>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }
    }
}
