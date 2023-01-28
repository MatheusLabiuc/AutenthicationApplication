using AspNetCoreAuth.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//definindo a conexão com o banco de dados
var connectionString = builder.Configuration.GetConnectionString("AuthConnectionString");
builder.Services.AddDbContext<AutenticacaoDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AutenticacaoDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login";
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
