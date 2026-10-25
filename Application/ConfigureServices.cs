using Application.Data.Repositories;
using Application.Handlers;
using Application.Services;
using Application.Services.Implementation;
using Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class ConfigureServices
    {
        extension(IServiceCollection services)
        {
            public IServiceCollection AddServices()
            {
                services.AddScoped<IHistoryEventService, HistoryEventService>();

                return services;
            }

            public IServiceCollection AddValidators()
            {
                services.AddScoped<IValidator<UpsertHistoryEventDto>, UpsertHistoryEventDtoValidator>();

                return services;
            }

            public IServiceCollection AddExceptionHandler()
            {
                services.AddExceptionHandler<ValidationHandler>();
                services.AddProblemDetails();

                return services;
            }
        }
    }
}
