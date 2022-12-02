using BrianMcKenna_SD4B_SOA_CA2.Models;
using BrianMcKenna_SD4B_SOA_CA2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("https://www.boxingclubweighttrackerapi.azurewebsites.net").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
        });
});


builder.Services.AddControllers();
builder.Services.AddDbContext<BoxingClubContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("BoxingClubDatabase")));
builder.Services.AddScoped<IBoxerRepository, BoxerRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<IWeightLogRepository, WeightLogRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
