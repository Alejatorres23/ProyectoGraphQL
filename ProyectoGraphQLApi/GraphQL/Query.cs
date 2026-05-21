using ProyectoGraphQLApi.Models;
using ProyectoGraphQLApi.Services;

namespace ProyectoGraphQLApi.GraphQL
{
    public class Query
    {
        public async Task<List<Tarea>> GetTareas(
            [Service] MongoDbService mongoDbService)
        {
            return await mongoDbService.GetTareasAsync();
        }
    }
}