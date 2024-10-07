using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Validacion_WEB.Datos;

var builder = WebApplication.CreateBuilder(args);

var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder()
 .RequireAuthenticatedUser()
 .Build();

builder.Services.AddControllersWithViews(opciones =>
{
    opciones.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
});


// Add services to the container.
builder.Services.AddControllersWithViews();

//Configura la cadena de conexion
builder.Services.AddDbContext<AplicationDBContext>(optiones =>
optiones.UseSqlServer(builder.Configuration.GetConnectionString("Cnn"))
);

builder.Services.AddScoped<IRepositorioMatricula, RepositorioMatricula>();



//Activa los servicios para que el usuario se pueda logear
builder.Services.AddAuthentication();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opciones =>
{

    opciones.SignIn.RequireConfirmedAccount = false;

}).AddEntityFrameworkStores<AplicationDBContext>()
.AddDefaultTokenProviders();

//Para unar mis porpias vistas
builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ExternalScheme,
    opciones =>
    {
        opciones.LoginPath = "/Account/Login";

        opciones.AccessDeniedPath = "/Account/Login";

    });


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

//Midleware
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Indel}/{action=Principal}/{id?}");

app.Run();
