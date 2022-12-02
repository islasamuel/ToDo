using Microsoft.EntityFrameworkCore;
using SIslas.ToDo.App.Domain.Domains;
using SIslas.ToDo.App.Domain.IDomains;
using SIslas.ToDo.App.Repository;
using SIslas.ToDo.App.Repository.IRepositories;
using SIslas.ToDo.App.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//Database
var connectionString = builder.Configuration.GetConnectionString("AppDB"); 
builder.Services.AddDbContext<AppDBContext>(options => options
                                                          .UseSqlServer(connectionString)
                                                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTrackingWithIdentityResolution));

#region DEPENDENCY INJECTIONS
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IMetaRepository, MetaRepository>();
builder.Services.AddScoped<IMetaDomain, MetaDomain>();

builder.Services.AddScoped<ITareaRepository, TareaRepository>();
builder.Services.AddScoped<ITareaDomain, TareaDomain>();

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
