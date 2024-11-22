namespace Taligado.Models
{
    public class RegulacaoEnergia
    {
        public int IdRegulacao { get; set; }
        public double TarifaKwh { get; set; }
        public string NomeBandeira { get; set; }
        public double TarifaAdicionalBandeira { get; set; }
        public DateTime DataAtualizacao { get; set; }

        // Propriedade de navegação para os históricos
        public ICollection<Historico> Historicos { get; set; }
    }


}
