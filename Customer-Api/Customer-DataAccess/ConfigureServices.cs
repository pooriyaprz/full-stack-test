using Customer_DataAccess.DataBase;
using Customer_DataAccess.Repositories;
using Customer_DataAccess.UnitOfWorks;
using Customer_Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_DataAccess
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>
                (options =>
                {
                    var builder = new NpgsqlDbContextOptionsBuilder(options);
                    builder.SetPostgresVersion(new System.Version(13, 13));
                    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery));
                });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}
