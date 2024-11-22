namespace Taligado.Models
{
    public class Sensor
    {
        public int IdSensor { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Unidade { get; set; }
        public double ValorAtual { get; set; }
        public double TempoOperacao { get; set; }

        // Propriedade de navegação para alertas
        public ICollection<Alerta> Alertas { get; set; }

        // Propriedade de navegação para o relacionamento muitos-para-muitos com Dispositivo
        public ICollection<DispositivoSensor> DispositivoSensores { get; set; }

        // Propriedade de navegação para o relacionamento muitos-para-muitos com Historico
        public ICollection<HistoricoSensor> HistoricoSensores { get; set; }
    }


}
