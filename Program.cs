using ContosoUniversity;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;



var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContext<UniversityContext>(options => options
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

IServiceScope scope = app.Services.CreateScope();

IServiceProvider services = scope.ServiceProvider;

try
{
    UniversityContext context = services.GetRequiredService<UniversityContext>();
    DbInitializer.Initialize(context);
}
catch (Exception ex)
{
    System.Console.WriteLine(ex.Message);
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
// "DefaultConnection": "Server=mssql.local,1433;Database=ContosoUniversity;Trusted_Connection=true;TrustServerCertificate=true;"
// "DefaultConnection": "host=172.17.208.1;port=5432;database=ContosoUniversity;username=postgres;password=291305"