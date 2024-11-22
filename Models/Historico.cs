namespace Taligado.Models
{
    public class Historico
    {
        public int IdHistorico { get; set; }
        public DateTime DataCriacao { get; set; }
        public double ValorConsumoKwh { get; set; }
        public double IntensidadeCarbono { get; set; }
        public double CustoEnergiaEstimado { get; set; }

        // Chave estrangeira para RegulacaoEnergia
        public int RegulacaoEnergia_IdRegulacao { get; set; }

        // Propriedade de navegação para RegulacaoEnergia
        public RegulacaoEnergia RegulacaoEnergia { get; set; }

        // Propriedade de navegação para o relacionamento muitos-para-muitos com Sensor
        public ICollection<HistoricoSensor> HistoricoSensores { get; set; }
    }


}
