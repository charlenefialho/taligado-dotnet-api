namespace Taligado.Models
{
    public class Filial
    {
        public int IdFilial { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string CNPJ_Filial { get; set; }
        public string Area_Operacional { get; set; }

        // Chave estrangeira para Empresa
        public int Empresa_IdEmpresa { get; set; }
        public Empresa Empresa { get; set; }

        // Chave estrangeira para Endereço
        public int Endereco_IdEndereco { get; set; }
        public Endereco Endereco { get; set; }

        // Coleção de dispositivos relacionados
        public ICollection<Dispositivo> Dispositivos { get; set; }
    }



}
