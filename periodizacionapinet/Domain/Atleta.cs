namespace periodizacionapinet.Domain
{

    public class Atleta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Edad { get; set; }

        public Deporte Deporte { get; set; }

        public Entrenador Entrenador { get; set; }
    }
}