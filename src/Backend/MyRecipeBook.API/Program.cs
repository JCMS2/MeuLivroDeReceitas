using MyRecipeBook.API.Filters;
using MyRecipeBook.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*
 * O QUE FAZ: Registra o 'ExceptionFilter' como um serviço global.
 * COMO FAZ: Ao adicionar 'AddMvc', ele acessa as 'options' (opções) e adiciona
 * o 'ExceptionFilter' à coleção global de filtros. Isso garante que
 * CADA controller da aplicação utilize este filtro automaticamente.
 */
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/*
 * O QUE FAZ: Adiciona o 'CultureMiddware' ao pipeline de requisições.
 * COMO FAZ: 'UseMiddleware' insere o middleware na ordem definida.
 * Este middleware provavelmente será executado em CADA requisição
 * para definir a cultura (idioma, formato de data/moeda) da thread atual.
 */
app.UseMiddleware<CultureMiddware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();