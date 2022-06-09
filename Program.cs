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
builder.Services.AddSingleton<IAdministracaoRepository, AdministracaoRepository>();
builder.Services.AddSingleton<IPedidoRepository, PedidoRepository>();
builder.Services.AddSingleton<ILoginRepository, LoginRepository>();

//Services
builder.Services.AddSingleton<IEntradaService, EntradaService>();
builder.Services.AddSingleton<IEstoqueService, EstoqueService>();
builder.Services.AddSingleton<IAdministracaoService, AdministracaoService>();
builder.Services.AddSingleton<IPedidoService, PedidoService>();
builder.Services.AddSingleton<ILoginService, LoginService>();

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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
