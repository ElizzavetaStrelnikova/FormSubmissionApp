using FormSubmissionApp.Interfaces;
using FormSubmissionApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IFormSubmissionService, FormSubmissionService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("VueFrontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("VueFrontend");

app.MapControllers();

app.UseStaticFiles(); // For wwwroot files

// Handle client-side routes
app.MapWhen(ctx => !ctx.Request.Path.StartsWithSegments("/api"), appBuilder =>
{
    appBuilder.UseSpa(spa =>
    {
        if (app.Environment.IsDevelopment())
        {
            // During development, proxy to the Vue dev server
            spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
        }
        else
        {
            // In production, serve files from wwwroot
            spa.Options.SourcePath = "wwwroot";
            spa.Options.DefaultPage = "/index.html";
        }
    });
});

app.Run();
