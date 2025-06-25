using Microsoft.EntityFrameworkCore;
using NutriFlowAPI.Data;
using NutriFlowAPI.Services.Categoria;
using NutriFlowAPI.Services.Estabelecimento;
using NutriFlowAPI.Services.EstoqueProduto;
using NutriFlowAPI.Services.Marca;
using NutriFlowAPI.Services.Produto;
using NutriFlowAPI.Services.UnidadeMedida;
using NutriFlowAPI.Services.Usuario;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<ICategoriaInterface, CategoriaService>();
builder.Services.AddScoped<IMarcaInterface, MarcaService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IEstabelecimentoInterface, EstabelecimentoService>();
builder.Services.AddScoped<IUnidadeMedidaInterface, UnidadeMedidaService>();
builder.Services.AddScoped<IEstoqueProdutoInterface, EstoqueProdutoService>();

<<<<<<< Updated upstream
builder.Services.AddControllers()
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);
// Conexão com o banco
=======
// Conexão com SQL Server
>>>>>>> Stashed changes
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTudo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Cria o app
var app = builder.Build();

// Configure o pipeline após o app ser criado
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("PermitirTudo");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
