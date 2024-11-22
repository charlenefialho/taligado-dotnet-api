using Taligado.Data;
using Taligado.Models;

namespace Taligado.Seed
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;

        public DataSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Empresas
            if (_context.Empresas.Count() == 0)
            {
                _context.Empresas.AddRange(new List<Empresa>
                {
                    new Empresa { Nome = "Empresa A", Email = "contato@empresaa.com", CNPJ = "11111111111111", Segmento = "Tecnologia", DataFundacao = new DateTime(2000, 1, 1) },
                    new Empresa { Nome = "Empresa B", Email = "contato@empresab.com", CNPJ = "22222222222222", Segmento = "Saúde", DataFundacao = new DateTime(2010, 5, 15) }
                });
                _context.SaveChanges();
            }

            // Recuperar IDs das Empresas
            var empresaA = _context.Empresas.First(e => e.CNPJ == "11111111111111");
            var empresaB = _context.Empresas.First(e => e.CNPJ == "22222222222222");

            // Endereços
            if (_context.Enderecos.Count() == 0)
            {
                _context.Enderecos.AddRange(new List<Endereco>
                {
                    new Endereco { Logradouro = "Rua A", Cidade = "São Paulo", Estado = "SP", CEP = "01001000", Pais = "Brasil" },
                    new Endereco { Logradouro = "Rua B", Cidade = "Rio de Janeiro", Estado = "RJ", CEP = "20020000", Pais = "Brasil" }
                });
                _context.SaveChanges();
            }

            // Recuperar IDs dos Endereços
            var endereco1 = _context.Enderecos.First(e => e.Logradouro == "Rua A");
            var endereco2 = _context.Enderecos.First(e => e.Logradouro == "Rua B");

            // Filiais
            if (_context.Filiais.Count() == 0)
            {
                _context.Filiais.AddRange(new List<Filial>
                {
                    new Filial { Nome = "Filial 1", Tipo = "Loja", CNPJ_Filial = "33333333333333", Area_Operacional = "Vendas", Empresa_IdEmpresa = empresaA.IdEmpresa, Endereco_IdEndereco = endereco1.IdEndereco },
                    new Filial { Nome = "Filial 2", Tipo = "Escritório", CNPJ_Filial = "44444444444444", Area_Operacional = "Administração", Empresa_IdEmpresa = empresaB.IdEmpresa, Endereco_IdEndereco = endereco2.IdEndereco }
                });
                _context.SaveChanges();
            }

            // Recuperar IDs das Filiais
            var filial1 = _context.Filiais.First(f => f.CNPJ_Filial == "33333333333333");
            var filial2 = _context.Filiais.First(f => f.CNPJ_Filial == "44444444444444");

            // Dispositivos
            if (_context.Dispositivos.Count() == 0)
            {
                _context.Dispositivos.AddRange(new List<Dispositivo>
                {
                    new Dispositivo { Nome = "Dispositivo 1", Tipo = "Sensor de Temperatura", Status = "Ativo", DataInstalacao = DateTime.Now, Filial_IdFilial = filial1.IdFilial, PotenciaNominal = 50.0 },
                    new Dispositivo { Nome = "Dispositivo 2", Tipo = "Sensor de Umidade", Status = "Inativo", DataInstalacao = DateTime.Now, Filial_IdFilial = filial2.IdFilial, PotenciaNominal = 30.0 }
                });
                _context.SaveChanges();
            }

            // Sensores
            if (_context.Sensores.Count() == 0)
            {
                _context.Sensores.AddRange(new List<Sensor>
                {
                    new Sensor { Tipo = "Temperatura", Descricao = "Sensor de Temperatura Interna", Unidade = "C", ValorAtual = 25.5, TempoOperacao = 120.0 },
                    new Sensor { Tipo = "Umidade", Descricao = "Sensor de Umidade do Ambiente", Unidade = "%", ValorAtual = 65.0, TempoOperacao = 100.0 }
                });
                _context.SaveChanges();
            }

            // Recuperar IDs dos Sensores
            var sensor1 = _context.Sensores.First(s => s.Tipo == "Temperatura");
            var sensor2 = _context.Sensores.First(s => s.Tipo == "Umidade");

            // Alertas
            if (_context.Alertas.Count() == 0)
            {
                _context.Alertas.AddRange(new List<Alerta>
                {
                    new Alerta { Descricao = "Temperatura acima do normal", Severidade = "Alta", DataAlerta = DateTime.Now, Sensor_IdSensor = sensor1.IdSensor },
                    new Alerta { Descricao = "Umidade abaixo do esperado", Severidade = "Média", DataAlerta = DateTime.Now, Sensor_IdSensor = sensor2.IdSensor }
                });
                _context.SaveChanges();
            }

            // Regulações de Energia
            if (_context.RegulacoesEnergia.Count() == 0)
            {
                _context.RegulacoesEnergia.AddRange(new List<RegulacaoEnergia>
                {
                    new RegulacaoEnergia { TarifaKwh = 0.5, NomeBandeira = "Verde", TarifaAdicionalBandeira = 0.0, DataAtualizacao = DateTime.Now },
                    new RegulacaoEnergia { TarifaKwh = 0.7, NomeBandeira = "Amarela", TarifaAdicionalBandeira = 0.2, DataAtualizacao = DateTime.Now }
                });
                _context.SaveChanges();
            }

            // Recuperar IDs das Regulações de Energia
            var regulacao1 = _context.RegulacoesEnergia.First(r => r.NomeBandeira == "Verde");
            var regulacao2 = _context.RegulacoesEnergia.First(r => r.NomeBandeira == "Amarela");

            // Históricos
            if (_context.Historicos.Count() == 0)
            {
                _context.Historicos.AddRange(new List<Historico>
                {
                    new Historico { DataCriacao = DateTime.Now, ValorConsumoKwh = 100.0, IntensidadeCarbono = 0.8, CustoEnergiaEstimado = 50.0, RegulacaoEnergia_IdRegulacao = regulacao1.IdRegulacao },
                    new Historico { DataCriacao = DateTime.Now, ValorConsumoKwh = 150.0, IntensidadeCarbono = 1.2, CustoEnergiaEstimado = 105.0, RegulacaoEnergia_IdRegulacao = regulacao2.IdRegulacao }
                });
                _context.SaveChanges();
            }
        }
    }
}
