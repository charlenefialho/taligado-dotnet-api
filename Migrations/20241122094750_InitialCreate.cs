using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Taligado.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Segmento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataFundacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CEP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Pais = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.IdEndereco);
                });

            migrationBuilder.CreateTable(
                name: "regulacao_energia",
                columns: table => new
                {
                    IdRegulacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TarifaKwh = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    NomeBandeira = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TarifaAdicionalBandeira = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_regulacao_energia", x => x.IdRegulacao);
                });

            migrationBuilder.CreateTable(
                name: "sensor",
                columns: table => new
                {
                    IdSensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Unidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorAtual = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    TempoOperacao = table.Column<double>(type: "BINARY_DOUBLE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sensor", x => x.IdSensor);
                });

            migrationBuilder.CreateTable(
                name: "filial",
                columns: table => new
                {
                    IdFilial = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CNPJ_Filial = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Area_Operacional = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Empresa_IdEmpresa = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Endereco_IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_filial", x => x.IdFilial);
                    table.ForeignKey(
                        name: "FK_filial_empresa_Empresa_IdEmpresa",
                        column: x => x.Empresa_IdEmpresa,
                        principalTable: "empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_filial_endereco_Endereco_IdEndereco",
                        column: x => x.Endereco_IdEndereco,
                        principalTable: "endereco",
                        principalColumn: "IdEndereco",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "historico",
                columns: table => new
                {
                    IdHistorico = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataCriacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ValorConsumoKwh = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    IntensidadeCarbono = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    CustoEnergiaEstimado = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    RegulacaoEnergia_IdRegulacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    RegulacaoEnergiaIdRegulacao = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historico", x => x.IdHistorico);
                    table.ForeignKey(
                        name: "FK_historico_regulacao_energia_RegulacaoEnergiaIdRegulacao",
                        column: x => x.RegulacaoEnergiaIdRegulacao,
                        principalTable: "regulacao_energia",
                        principalColumn: "IdRegulacao");
                    table.ForeignKey(
                        name: "FK_historico_regulacao_energia_RegulacaoEnergia_IdRegulacao",
                        column: x => x.RegulacaoEnergia_IdRegulacao,
                        principalTable: "regulacao_energia",
                        principalColumn: "IdRegulacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "alerta",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Severidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataAlerta = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Sensor_IdSensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alerta", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_alerta_sensor_Sensor_IdSensor",
                        column: x => x.Sensor_IdSensor,
                        principalTable: "sensor",
                        principalColumn: "IdSensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dispositivo",
                columns: table => new
                {
                    IdDispositivo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataInstalacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    PotenciaNominal = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    Filial_IdFilial = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dispositivo", x => x.IdDispositivo);
                    table.ForeignKey(
                        name: "FK_dispositivo_filial_Filial_IdFilial",
                        column: x => x.Filial_IdFilial,
                        principalTable: "filial",
                        principalColumn: "IdFilial",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoSensor",
                columns: table => new
                {
                    HistoricoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoSensor", x => new { x.HistoricoId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_HistoricoSensor_historico_HistoricoId",
                        column: x => x.HistoricoId,
                        principalTable: "historico",
                        principalColumn: "IdHistorico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistoricoSensor_sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "sensor",
                        principalColumn: "IdSensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DispositivoSensor",
                columns: table => new
                {
                    DispositivoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispositivoSensor", x => new { x.DispositivoId, x.SensorId });
                    table.ForeignKey(
                        name: "FK_DispositivoSensor_dispositivo_DispositivoId",
                        column: x => x.DispositivoId,
                        principalTable: "dispositivo",
                        principalColumn: "IdDispositivo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DispositivoSensor_sensor_SensorId",
                        column: x => x.SensorId,
                        principalTable: "sensor",
                        principalColumn: "IdSensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alerta_Sensor_IdSensor",
                table: "alerta",
                column: "Sensor_IdSensor");

            migrationBuilder.CreateIndex(
                name: "IX_dispositivo_Filial_IdFilial",
                table: "dispositivo",
                column: "Filial_IdFilial");

            migrationBuilder.CreateIndex(
                name: "IX_DispositivoSensor_SensorId",
                table: "DispositivoSensor",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_filial_Empresa_IdEmpresa",
                table: "filial",
                column: "Empresa_IdEmpresa");

            migrationBuilder.CreateIndex(
                name: "IX_filial_Endereco_IdEndereco",
                table: "filial",
                column: "Endereco_IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_historico_RegulacaoEnergia_IdRegulacao",
                table: "historico",
                column: "RegulacaoEnergia_IdRegulacao");

            migrationBuilder.CreateIndex(
                name: "IX_historico_RegulacaoEnergiaIdRegulacao",
                table: "historico",
                column: "RegulacaoEnergiaIdRegulacao");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricoSensor_SensorId",
                table: "HistoricoSensor",
                column: "SensorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "alerta");

            migrationBuilder.DropTable(
                name: "DispositivoSensor");

            migrationBuilder.DropTable(
                name: "HistoricoSensor");

            migrationBuilder.DropTable(
                name: "dispositivo");

            migrationBuilder.DropTable(
                name: "historico");

            migrationBuilder.DropTable(
                name: "sensor");

            migrationBuilder.DropTable(
                name: "filial");

            migrationBuilder.DropTable(
                name: "regulacao_energia");

            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "endereco");
        }
    }
}
