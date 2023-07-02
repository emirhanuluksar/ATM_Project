using Microsoft.IdentityModel.Logging;
namespace WebAPI.Infrastructure;

public static class StartupBuildAndRun {
    public static void BuildAndRun(this WebApplication app) {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
            IdentityModelEventSource.ShowPII = true;
            app.UseDeveloperExceptionPage();
        }
        app.UseHttpsRedirection();
        app.UseStartupCors();
        // app.UseMiddleware<DebugMiddleware>();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // LanguageUtils.IgnoreErrors(() => app.Services.GetService<ICommonService>()?
        //     .AddSystemEventLogEntry("Bko Wep App Has Started", Constants.BkoWebApp));

        app.Run();
    }
}
