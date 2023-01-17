
// 1 Ussings para trabajar ocn EntityFramework
using Microsoft.EntityFrameworkCore;
using UniversityApiBackend.DataAcces; // este using nos da acceso a la carpeta para hacer uso de nuestro contexto
using UniversityApiBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// 2 Coneccion con la base de datos
const string ConectionName = "UniversityDB";
var connectionString = builder.Configuration.GetConnectionString(ConectionName);

// 3 add Context
builder.Services.AddDbContext<UniversityContext>(options => options.UseSqlServer(connectionString));

// 7 Add services of JWT Autorization
//builder.Services.AddJwtTokenServices(builder.Configuration);

// Add services to the container.
// el Builder nos sirve para construir las configuraciones de nuestra aplicacion
builder.Services.AddControllers();

// 4 añadir servicios customisados
builder.Services.AddScoped<IStudentServices, StudentService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8 configurar swagger para que tenga en cuenta la Autorizacion
builder.Services.AddSwaggerGen();


// 5 habilitar CORS configurations
builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "CorsPolicy", builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//redirecciones HTTP
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 6 indicar a la APP que use los CORS
app.UseCors("CorsPolicy");

app.Run();
