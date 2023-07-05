using Application.interfaces;
using Application.services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Persistence.Repository;

namespace WebAPI.Infrastructure;

public static class IocRegistrations {
    public static void AddIocRegistrations(this WebApplicationBuilder builder) {
        builder.Services.AddScoped<ICategoryService, CategoryService>();
    }
}
