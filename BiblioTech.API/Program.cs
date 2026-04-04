using BiblioTech.API.Services;
using BiblioTech.Infra.Data.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<LivroService>();

builder.Services.AddCors(options => {
    options.AddPolicy("AngularApp", policy => {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.DeepSpace));

app.UseCors("AngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();