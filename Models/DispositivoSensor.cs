namespace Taligado.Models
{
    public class DispositivoSensor
    {
        public int DispositivoId { get; set; }
        public Dispositivo Dispositivo { get; set; }

        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }

}
