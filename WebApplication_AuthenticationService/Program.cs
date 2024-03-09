using AutoMapper;
using WebApplication_AuthenticationService.DAL.Repositories;
using WebApplication_AuthenticationService.PLL;
using WebApplication_AuthenticationService.PLL.Middlewares;
using WebApplication_AuthenticationService.PLL.Logging;

var builder = WebApplication.CreateBuilder(args);

var mapperConfig = new MapperConfiguration((v) =>
{
    v.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(mapper);
//mapperConfig.AssertConfigurationIsValid();

builder.Services.AddAuthentication(options => options.DefaultScheme = "Cookies")
    .AddCookie("Cookies", options =>
    {
        options.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents
        {
            OnRedirectToLogin = redirectContex =>
            {
                redirectContex.HttpContext.Response.StatusCode = 401;
                return Task.CompletedTask;
            }
        };
    });

// Add services to the container.
builder.Services.AddSingleton<WebApplication_AuthenticationService.PLL.Logging.ILogger, Logger>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseLogMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
