import { useEffect, useState } from "react";
import axios from "axios";

function App() {
  const [tareas, setTareas] = useState([]);

  useEffect(() => {
    // Consumo del backend .NET usando Axios
    axios
      .get("http://localhost:5201/api/Tareas")
      .then((response) => {
        setTareas(response.data);
      })
      .catch((error) => {
        console.error("Error al cargar tareas:", error);
      });
  }, []);

  return (
    <div style={{ padding: "20px", textAlign: "center" }}>
      <h1>Lista de Tareas</h1>

      {tareas.map((tarea) => (
        <div key={tarea.id}>
          <h3>{tarea.titulo}</h3>
          <p>
            Estado: {tarea.completada ? "✅ Completada" : "❌ Pendiente"}
          </p>
          <hr />
        </div>
      ))}
    </div>
  );
}

export default App;