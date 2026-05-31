using Microsoft.AspNetCore.Mvc;
using ProyectoGraphQLApi.Models;

namespace ProyectoGraphQLApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TareasController : ControllerBase
    {
        private static List<Tarea> tareas = new()
        {
            new Tarea
            {
                Id = 1,
                Titulo = "Tarea desde Swagger",
                Completada = false
            },
            new Tarea
            {
                Id = 2,
                Titulo = "Proyecto con Docker",
                Completada = true
            }
        };

        // GET: api/Tareas
        [HttpGet]
        public ActionResult<IEnumerable<Tarea>> Get()
        {
            return Ok(tareas);
        }

        // GET: api/Tareas/1
        [HttpGet("{id}")]
        public ActionResult<Tarea> GetById(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
                return NotFound();

            return Ok(tarea);
        }

        // POST: api/Tareas
        [HttpPost]
        public ActionResult Post([FromBody] Tarea nuevaTarea)
        {
            tareas.Add(nuevaTarea);
            return Ok(nuevaTarea);
        }

        // PUT: api/Tareas/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Tarea tareaActualizada)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
                return NotFound();

            tarea.Titulo = tareaActualizada.Titulo;
            tarea.Completada = tareaActualizada.Completada;

            return Ok(tarea);
        }

        // DELETE: api/Tareas/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var tarea = tareas.FirstOrDefault(t => t.Id == id);

            if (tarea == null)
                return NotFound();

            tareas.Remove(tarea);

            return Ok();
        }
    }
}