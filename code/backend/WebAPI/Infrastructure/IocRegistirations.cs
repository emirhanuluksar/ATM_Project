using Application.interfaces;
using Application.services;
using Persistence;

namespace WebAPI.Infrastructure;

public static class IocRegistrations {
    public static void AddIocRegistrations(this WebApplicationBuilder builder) {
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<ICategoryDal, CategoryDal>();
    }
}
