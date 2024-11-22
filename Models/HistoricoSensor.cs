namespace Taligado.Models
{
    public class HistoricoSensor
    {
        public int HistoricoId { get; set; }
        public Historico Historico { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}
