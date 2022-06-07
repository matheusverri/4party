using ForParty.Repository;
using ForParty.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//Repositories
builder.Services.AddSingleton<IEntradaRepository, EntradaRepository>();
builder.Services.AddSingleton<IEstoqueRepository, EstoqueRepository>();

//Services
builder.Services.AddSingleton<IEntradaService, EntradaService>();
builder.Services.AddSingleton<IEstoqueService, EstoqueService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
