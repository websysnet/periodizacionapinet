using System.Security.Cryptography.X509Certificates;

using periodizacionapinet.Domain;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Bienvenidos a API periodizacion !");


app.MapGet("/deportes", () =>
{
    List<Deporte> deportes = new List<Deporte>
    {
        new Deporte { Id = 1, Nombre = "Futbol", Descripcion = "Deporte de equipo jugado entre dos conjuntos de once jugadores cada uno.", Categoria = "Deporte de equipo", imagenUrl="https://example.com/futbol.jpg" },
        new Deporte { Id = 2, Nombre = "Baloncesto", Descripcion = "Deporte de equipo en el que dos conjuntos de cinco jugadores intentan anotar puntos lanzando una pelota a través de un aro.", Categoria = "Deporte de equipo", imagenUrl="https://example.com/baloncesto.jpg" },
        new Deporte { Id = 3, Nombre = "Natación", Descripcion = "Deporte acuático que consiste en desplazarse en el agua utilizando los brazos y las piernas.", Categoria = "Deporte individual", imagenUrl="https://example.com/natacion.jpg" },
        new Deporte { Id = 4, Nombre = "Atletismo", Descripcion = "Conjunto de disciplinas deportivas que incluyen carreras, saltos y lanzamientos.", Categoria = "Deporte individual", imagenUrl="https://example.com/atletismo.jpg" },
        new Deporte { Id = 5, Nombre = "Ciclismo", Descripcion = "Deporte que consiste en montar en bicicleta para competir en diferentes modalidades.", Categoria = "Deporte individual", imagenUrl="https://example.com/ciclismo.jpg" }
    };

    if(deportes.Count == 0)
    {
        return Results.NotFound("No se encontraron deportes.");
    }

    return deportes;    
    
}).WithName("GetDeportes");

//get deportes by id
app.MapGet("/deportes/{id}", (int id) =>
{
    List<Deporte> deportes = new List<Deporte>
    {
        new Deporte { Id = 1, Nombre = "Futbol", Descripcion = "Deporte de equipo jugado entre dos conjuntos de once jugadores cada uno.", Categoria = "Deporte de equipo", imagenUrl="https://example.com/futbol.jpg" },
        new Deporte { Id = 2, Nombre = "Baloncesto", Descripcion = "Deporte de equipo en el que dos conjuntos de cinco jugadores intentan anotar puntos lanzando una pelota a través de un aro.", Categoria = "Deporte de equipo", imagenUrl="https://example.com/baloncesto.jpg" },
        new Deporte { Id = 3, Nombre = "Natación", Descripcion = "Deporte acuático que consiste en desplazarse en el agua utilizando los brazos y las piernas.", Categoria = "Deporte individual", imagenUrl="https://example.com/natacion.jpg" },
        new Deporte { Id = 4, Nombre = "Atletismo", Descripcion = "Conjunto de disciplinas deportivas que incluyen carreras, saltos y lanzamientos.", Categoria = "Deporte individual", imagenUrl="https://example.com/atletismo.jpg" },
        new Deporte { Id = 5, Nombre = "Ciclismo", Descripcion = "Deporte que consiste en montar en bicicleta para competir en diferentes modalidades.", Categoria = "Deporte individual", imagenUrl="https://example.com/ciclismo.jpg" }
    };

    var deporte = deportes.FirstOrDefault(d => d.Id == id);

    if(deporte == null)
    {
        return Results.NotFound($"No se encontró el deporte con ID {id}.");
    }

    return Results.Ok(deporte); 
    
}).WithName("GetDeporteById");


//get entrenadores
app.MapGet("/entrenadores", () =>
{
    List<Entrenador> entrenadores = new List<Entrenador>
    {
        new Entrenador { Id = 1, Nombre = "Carlos Lopez", Deporte = new Deporte { Id = 1, Nombre = "Futbol" }, AñosExperiencia = 10 },
        new Entrenador { Id = 2, Nombre = "Ana Martinez", Deporte = new Deporte { Id = 3, Nombre = "Natación" }, AñosExperiencia = 8 },
        new Entrenador { Id = 3, Nombre = "Pedro Sanchez", Deporte = new Deporte { Id = 4, Nombre = "Atletismo" }, AñosExperiencia = 12 },
        new Entrenador { Id = 4, Nombre = "Miguel Fernandez", Deporte = new Deporte { Id = 2, Nombre = "Baloncesto" }, AñosExperiencia = 7 },
        new Entrenador { Id = 5, Nombre = "Laura Gutierrez", Deporte = new Deporte { Id = 5, Nombre = "Ciclismo" }, AñosExperiencia = 9 }
    };
    if(entrenadores.Count == 0)
    {
        return Results.NotFound("No se encontraron entrenadores.");
    }   
    return entrenadores;


}).WithName("GetEntrenadores");

//get atletas
app.MapGet("/atletas", () =>
{
    List<Atleta> atletas = new List<Atleta>
    {
        new Atleta { Id = 1, Nombre = "Juan Perez", FechaNacimiento = new DateTime(1990, 5, 20), Edad = 33,
            Deporte = new Deporte { Id = 1, Nombre = "Futbol", Descripcion = "Deporte de equipo jugado entre dos conjuntos de once jugadores cada uno.", Categoria = "Deporte de equipo", imagenUrl="https://example.com/futbol.jpg" },
            Entrenador = new Entrenador { Id = 1, Nombre = "Carlos Lopez", Deporte = new Deporte { Id = 1, Nombre = "Futbol" }, AñosExperiencia = 10 }
        },
        new Atleta { Id = 2, Nombre = "Maria Gomez", FechaNacimiento = new DateTime(1995, 8, 15), Edad = 28,
            Deporte = new Deporte { Id = 3, Nombre = "Natación", Descripcion = "Deporte acuático que consiste en desplazarse en el agua utilizando los brazos y las piernas.", Categoria = "Deporte individual", imagenUrl="https://example.com/natacion.jpg" },
            Entrenador = new Entrenador { Id = 2, Nombre = "Ana Martinez", Deporte = new Deporte { Id = 3, Nombre = "Natación" }, AñosExperiencia = 8 }
        },
        new Atleta { Id = 3, Nombre = "Luis Rodriguez", FechaNacimiento = new DateTime(1988, 12, 10), Edad = 35,
            Deporte = new Deporte { Id = 4, Nombre = "Atletismo", Descripcion = "Conjunto de disciplinas deportivas que incluyen carreras, saltos y lanzamientos.", Categoria = "Deporte individual", imagenUrl="https://example.com/atletismo.jpg" },
            Entrenador = new Entrenador { Id = 3, Nombre = "Pedro Sanchez", Deporte = new Deporte { Id = 4, Nombre = "Atletismo" }, AñosExperiencia = 12 }
        },

        new Atleta { Id = 4, Nombre = "Sofia Torres", FechaNacimiento = new DateTime(2000, 3, 5), Edad = 23,
            Deporte = new Deporte { Id = 2, Nombre = "Baloncesto", Descripcion = "Deporte de equipo en el que dos conjuntos de cinco jugadores intentan anotar puntos lanzando una pelota a través de un aro.", Categoria = "Deporte de equipo", imagenUrl="https://example.com/baloncesto.jpg" },
            Entrenador = new Entrenador { Id = 4, Nombre = "Miguel Fernandez", Deporte = new Deporte { Id = 2, Nombre = "Baloncesto" }, AñosExperiencia = 7 }
        },
        new Atleta { Id = 5, Nombre = "Carlos Ramirez", FechaNacimiento = new DateTime(1992, 11, 25), Edad = 31,
            Deporte = new Deporte { Id = 5, Nombre = "Ciclismo", Descripcion = "Deporte que consiste en montar en bicicleta para competir en diferentes modalidades.", Categoria = "De  porte individual", imagenUrl="https://example.com/ciclismo.jpg" },
            Entrenador = new Entrenador { Id = 5, Nombre = "Laura Gutierrez", Deporte = new Deporte { Id = 5, Nombre = "Ciclismo" }, AñosExperiencia = 9 }
        }
    };

    if(atletas.Count == 0)
    {
        return Results.NotFound("No se encontraron atletas.");
    }

    return atletas;
    
}).WithName("GetAtletas");

//get planes entrenamiento
app.MapGet("/planesentrenamiento", () =>
{
    List<PlanEntrenamiento> planes = new List<PlanEntrenamiento>
    {
        new PlanEntrenamiento
        {
            Id = 1,
            Nombre = "Plan de Resistencia para Corredores",
            Deporte = new Deporte { Id = 4, Nombre = "Atletismo" },
            FechaInicio = DateTime.Now,
            FechaFin = DateTime.Now.AddMonths(3),
            Descripcion = "Mejora tu resistencia con este plan de entrenamiento de 12 semanas.",
            Semanas = 12,
            TipoPlan = TipoPlan.Resistencia,
            Atleta = new Atleta { Id = 3, Nombre = "Luis Rodriguez" }
        }
    };

    if(planes.Count == 0)
    {
        return Results.NotFound("No se encontraron planes de entrenamiento.");
    }

    return planes;
    
}).WithName("GetPlanesEntrenamiento");  


//get sesiones entrenamiento
app.MapGet("/sesionesentrenamiento", () =>
{
    List<SesionEntrenamiento> sesiones = new List<SesionEntrenamiento>
    {
        new SesionEntrenamiento
        {
            Id = 1,
            Fecha = DateTime.Now,
            Duracion = TimeSpan.FromHours(1.5),
            TipoEntrenamiento = "Cardio",
            Intensidad = 7,
            Objetivos = "Mejorar la capacidad cardiovascular",
            Descripcion = "Sesión de entrenamiento enfocada en ejercicios cardiovasculares.",
            PlanEntrenamiento = new PlanEntrenamiento { Id = 1, Nombre = "Plan de Resistencia para Corredores" }
        }
    };

    if(sesiones.Count == 0)
    {
        return Results.NotFound("No se encontraron sesiones de entrenamiento.");
    }

    return sesiones;


    
}).WithName("GetSesionesEntrenamiento"); 


//get tipoPlan enum values
app.MapGet("/tipoPlan", () =>
{
    var tipos = Enum.GetNames(typeof(TipoPlan));
    return tipos;
}).WithName("GetTipoPlan");

app.UseHttpsRedirection();

app.Run();






