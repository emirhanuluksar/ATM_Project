namespace WebAPI.Infrastructure;

public static class StartupAddServices {
    public static void AddStartupServices(this WebApplicationBuilder builder) {
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.AddIocRegistrations();
        builder.AddStartupCors();
        builder.AddStartupAuthorization();
    }
}
 