using APIFinalLibrary.Extensions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NLog;
using Repositories.EFCore;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = false;
    config.ReturnHttpNotAcceptable = false;
})
    //.AddCustomCsvFormatter()
    //.AddXmlDataContractSerializerFormatters()
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly)
    .AddNewtonsoftJson();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<RepositoryContext>()
.AddDefaultTokenProviders();

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureLogEntryService();
builder.Services.ConfigureTokenService(builder.Configuration);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               );
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roles = { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    var admin = await userManager.FindByNameAsync("admin");
    if (admin == null)
    {
        admin = new User
        {
            Id = "admin1",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@library.com",
            NormalizedEmail = "ADMIN@LIBRARY.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEJMlc8wHZN3H5bLnmeOHQL5DjYrGk6jmuk/5tXsJ0iK0tqkTHg+nUqdRcmwTOSdwfA==",
            Initials = "ADM",
            SecurityStamp = "b968e763-e9c1-4ee6-a0a3-2f093a31f0f6",
            ConcurrencyStamp = "cc0a7df8-eb51-40ee-9c8f-d57a2a222b8c",
            LockoutEnabled = false,
            AccessFailedCount = 0,
            TwoFactorEnabled = false,
            PhoneNumberConfirmed = false
        };
        await userManager.CreateAsync(admin);
        await userManager.AddToRoleAsync(admin, "Admin");
    }

    var user = await userManager.FindByNameAsync("qwe");
    if (user == null)
    {
        user = new User
        {
            Id = "user1",
            UserName = "qwe",
            NormalizedUserName = "JOHN_DOE",
            Email = "john@example.com",
            NormalizedEmail = "JOHN@EXAMPLE.COM",
            EmailConfirmed = true,
            PasswordHash = "AQAAAAIAAYagAAAAEJMlc8wHZN3H5bLnmeOHQL5DjYrGk6jmuk/5tXsJ0iK0tqkTHg+nUqdRcmwTOSdwfA==",
            Initials = "JD",
            SecurityStamp = "5d8f5a3d-0c4e-47b6-a8d4-2c0b5d96f334",
            ConcurrencyStamp = "cf855417-501c-45a8-a45c-8e1d394be5e5",
            LockoutEnabled = false,
            AccessFailedCount = 0,
            TwoFactorEnabled = false,
            PhoneNumberConfirmed = false
        };
        await userManager.CreateAsync(user);
        await userManager.AddToRoleAsync(user, "User");
    }
}

app.MapControllers();

app.Run();
