namespace Taligado.Models
{
    public class Dispositivo
    {
        public int IdDispositivo { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public String Status { get; set; } 
        public DateTime DataInstalacao { get; set; }

        public double PotenciaNominal { get; set; }

        // Chave estrangeira para Filial
        public int Filial_IdFilial { get; set; }

        // Propriedade de navegação para Filial
        public Filial Filial { get; set; }

        // Propriedade de navegação para a relação muitos-para-muitos com Sensor
        public ICollection<DispositivoSensor> DispositivoSensores { get; set; }

    }


}
