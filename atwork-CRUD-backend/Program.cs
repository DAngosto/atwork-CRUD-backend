using atwork_CRUD_backend.Middlewares;
using atwork_CRUD_backend.ServiceCollectionExtensions;
using atwork_CRUD_backend_Infraestructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Load custom services configuration
builder.Services.AddFrontendCORSPolicy();
builder.Services.AddMediatRAndFluentValidatorServices();
builder.Services.RegisterMapsterConfiguration();
builder.Services.AddServicesConfiguration();
builder.Services.AddInMemoryDatabase();
builder.Services.AddSettingsConfiguration(builder.Configuration);
builder.Services.AddSerilogConfiguration(builder.Configuration);
builder.Services.AddAuthConfiguration(builder.Configuration);
builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseCors("AllowFrontEndOrigins");

// Database seed
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Middlewares
app.UseMiddleware<ExceptionHandlerMiddleware>();

// Auth
app.UseAuthorization();

app.Run();
