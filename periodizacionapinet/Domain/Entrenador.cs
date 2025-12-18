namespace periodizacionapinet.Domain
{
   
public class Entrenador
{
    public int Id { get; set; }
    public string Nombre { get; set; }  

    public Deporte Deporte { get; set; }

    public int AñosExperiencia { get; set; }
}

}