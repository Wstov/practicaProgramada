using PracticaProgramada.BLL.Servicios;
using PracticaProgramada.DAL.Repositorios;
using PracticaProgramada.BLL.Mapeos;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// AutoMapper
builder.Services.AddAutoMapper(cfg => { }, typeof(MapeoClases));

// Inyección de dependencias DAL
builder.Services.AddScoped<IEstudiantesRepositorio, EstudiantesRepositorio>();

// Inyección de dependencias BLL
builder.Services.AddScoped<IEstudiantesServicio, EstudiantesServicio>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Estudiantes}/{action=Index}/{id?}");

app.Run();
