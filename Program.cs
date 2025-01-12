using backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Data_DbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
      builder =>
      {
          builder.WithOrigins("https://localhost:44351", "http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
