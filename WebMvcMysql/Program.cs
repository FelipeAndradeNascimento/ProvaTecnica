using Microsoft.EntityFrameworkCore;
using WebMvcMysql.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<Contexto>
    (options => options.UseMySql(
        "server=localhost;initial catalog=DbCaminhoes;uid=root;pwd=ClosurE1_42#",
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.28-mysql")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Caminhao}/{action=Index}/{id?}");

app.Run();
