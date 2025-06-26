using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using NutriFlowAPI.Data;
using NutriFlowAPI.Services.Categoria;
using NutriFlowAPI.Services.Estabelecimento;
using NutriFlowAPI.Services.EstoqueProduto;
using NutriFlowAPI.Services.Marca;
using NutriFlowAPI.Services.Produto;
using NutriFlowAPI.Services.UnidadeMedida;
using NutriFlowAPI.Services.Usuario;

var builder = WebApplication.CreateBuilder(args);

// ===== Serviços =====
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = 
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI dos seus services
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<ICategoriaInterface, CategoriaService>();
builder.Services.AddScoped<IMarcaInterface, MarcaService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IEstabelecimentoInterface, EstabelecimentoService>();
builder.Services.AddScoped<IUnidadeMedidaInterface, UnidadeMedidaService>();
builder.Services.AddScoped<IEstoqueProdutoInterface, EstoqueProdutoService>();

// EF Core / SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// ===== Pipeline =====
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTudo");
app.UseHttpsRedirection();
app.UseAuthorization();

// 1) Serve o index.html que está em wwwroot/html como raiz (“/”)
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    RequestPath = "",
    EnableDefaultFiles = true,            // Habilita busca por index.html
    StaticFileOptions = { ServeUnknownFileTypes = false },
    DefaultFilesOptions = 
    {
        DefaultFileNames = { "index.html" }
    }
});

// 2) Serve CSS, JS e IMGs que estão em wwwroot/css, wwwroot/js e wwwroot/img
app.UseStaticFiles();

// Map Controllers (sua API)
app.MapControllers();

app.Run();
