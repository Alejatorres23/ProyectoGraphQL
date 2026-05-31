using MongoDB.Driver;
using ProyectoGraphQLApi.Models;

namespace ProyectoGraphQLApi.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Tarea> _tareas;

        public MongoDbService()
        {
            var client = new MongoClient("mongodb://localhost:27017");

            var database = client.GetDatabase("ProyectoGraphQLDB");

            _tareas = database.GetCollection<Tarea>("Tareas");
        }

        public async Task<List<Tarea>> GetTareasAsync()
        {
            return await _tareas.Find(_ => true).ToListAsync();
        }

        public async Task CrearTareaAsync(Tarea tarea)
        {
            await _tareas.InsertOneAsync(tarea);
        }
    }
}