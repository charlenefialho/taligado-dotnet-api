namespace Taligado.Models
{
    public class Empresa
    {
        public int IdEmpresa { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CNPJ { get; set; }
        public string Segmento { get; set; }
        public DateTime DataFundacao { get; set; }

        // Propriedade de navegação para Filiais
        public ICollection<Filial> Filiais { get; set; }
    }


}
