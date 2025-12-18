namespace periodizacionapinet.Domain
{
    public class PlanEntrenamiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Deporte Deporte { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public string Descripcion { get; set; }

        public int Semanas { get; set; }

        public TipoPlan TipoPlan { get; set; }

        public Atleta Atleta { get; set; }
    }
}