using Application.Data.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class ConfigurateServices
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddHistoryTimelineDbContext(
                IConfiguration configuration)
            {
                services.AddDbContext<HistoryTimelineDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("HistoryTimelineDbContext")));

                return services;
            }

            public IServiceCollection AddRepositories()
            {
                services.AddScoped<IHistoryEventRepository, HistoryEventRepository>();
                return services;
            }
        }
    }
}
