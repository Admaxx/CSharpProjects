using DBConnection.Models;
using ResumeAnswerer.Services.Commands;
using ResumeAnswerer.Services.Queries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region registrationScoped

builder.Services.AddScoped<CompanyDBContext>();

builder.Services.AddScoped<IGetAllResumes, GetAllResumes>();
builder.Services.AddScoped<IGetOneResume, GetOneResume>();

builder.Services.AddScoped<IChooseOneWorker, ChooseOneWorker>();

builder.Services.AddScoped<IsendMail, sendMail>();
builder.Services.AddScoped<IDeleteAllArchive, DeleteAllArchive>();


#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
