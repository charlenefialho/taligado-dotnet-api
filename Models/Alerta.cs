namespace Taligado.Models
{
    public class Alerta
    {
        public int IdAlerta { get; set; }
        public string Descricao { get; set; }
        public string Severidade { get; set; }
        public DateTime DataAlerta { get; set; }

        // Chave estrangeira para Sensor
        public int Sensor_IdSensor { get; set; }

        // Propriedade de navegação para Sensor
        public Sensor Sensor { get; set; }
    }


}
