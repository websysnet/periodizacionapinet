namespace periodizacionapinet.Domain
{
  
public class SesionEntrenamiento
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }  

    public TimeSpan Duracion { get; set; }

    public string TipoEntrenamiento { get; set; }

    public int Intensidad { get; set; }

    public string Objetivos { get; set; }   

    public string Descripcion { get; set; }

    public PlanEntrenamiento PlanEntrenamiento { get; set; }
}
}