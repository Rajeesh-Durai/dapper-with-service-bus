using MediatR;
using student.Infrastructure.Context;
using Student.Application.Features.Student.Command;
using Student.Application.Features.Student.Query;
using Student.Application.Mapper;
using Student.Domain.Interface;
using Student.Domain.Service;
using Student.Infrastructure.Message;
using Student.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<StudentContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IMessageQueueService, MessageQueueService>();
builder.Services.AddScoped<IAzureServiceBusClient, AzureServiceBusClient>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetStudentsQuery).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStudentCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateStudentCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteStudentCommand).Assembly));

builder.Services.AddAutoMapper(typeof(StudentMappingProfile));

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
