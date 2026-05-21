using ProyectoGraphQLApi.GraphQL;
using ProyectoGraphQLApi.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDB
builder.Services.AddSingleton<MongoDbService>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirReact", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>();

var app = builder.Build();

// Swagger
app.UseSwagger();
app.UseSwaggerUI();

// CORS
app.UseCors("PermitirReact");

// Controllers
app.MapControllers();

// GraphQL
app.MapGraphQL();

app.Run();