using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar la cadena de conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Registrar el contexto de la base de datos
builder.Services.AddDbContext<Logs.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// Agregar servicios de controladores y Razor Pages
builder.Services.AddControllers();
builder.Services.AddRazorPages();


// Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear controladores y Razor Pages
app.MapControllers();
app.MapRazorPages();

app.Run();
