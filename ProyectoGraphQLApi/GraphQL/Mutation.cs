using ProyectoGraphQLApi.Models;
using ProyectoGraphQLApi.Services;

namespace ProyectoGraphQLApi.GraphQL
{
    public class Mutation
    {
        public async Task<string> CrearTarea(
            int id,
            string titulo,
            bool completada,
            [Service] MongoDbService mongoDbService)
        {
            var tarea = new Tarea
            {
                Id = id,
                Titulo = titulo,
                Completada = completada
            };

            await mongoDbService.CrearTareaAsync(tarea);

            return "Tarea creada correctamente";
        }
    }
}