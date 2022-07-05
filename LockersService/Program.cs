using LockersService.Domain;
using LockersService.Interfaces;
using LockersService.Models;
using LockersService.Repository;
using LockersService.Services;
using Microsoft.EntityFrameworkCore;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//IConfiguration configuration = new ConfigurationBuilder()
//                            .AddJsonFile("appsettings.json")
//                            .Build();
//builder.Services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));



builder.Services.AddSingleton<IEmailSender, EmailSenderService>();
builder.Services.AddSingleton<IMailRepository, MailRepository>();


builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<>();

builder.Services.AddDbContext<MobileTechnologyContext>(options =>
{
    string defaultConnection = "Data Source=MBT01-ERP-01;User ID=MBT_Lock;Password=MTL0cK2022!@#x;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;MultiSubnetFailover=False";
    options.UseSqlServer(builder.Configuration.GetConnectionString(defaultConnection));
});


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000");
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

app.UseAuthorization();

//app.UseCors(MyAllowSpecificOrigins);

app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));



app.MapControllers();

app.Run();
