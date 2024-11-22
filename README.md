# 🔋TáLigado - Monitoramento de Consumo Energético e Sustentabilidade

Descrição do Projeto
O TáLigado é um sistema inovador que integra tecnologias de IoT, aprendizado de máquina e visualização de dados para monitorar o consumo energético e as emissões de CO₂ em tempo real. O objetivo principal é fornecer às empresas ferramentas para reduzir custos, melhorar a eficiência energética e cumprir metas de sustentabilidade, promovendo a redução da pegada de carbono.

O sistema captura dados através de dispositivos IoT, analisa padrões de consumo utilizando algoritmos de machine learning e emite alertas e recomendações baseadas em insights acionáveis.

## Estrutura do banco de dados

O banco de dados foi modelado seguindo as normas de normalização até a 3ª Forma Normal, garantindo integridade, consistência e minimização de redundâncias.

### Principais Tabelas
- **Empresa:** Dados cadastrais das empresas monitoradas.
- **Filial:** Relaciona-se com a tabela Empresa, representando suas unidades.
- **Endereço:** Detalhes geográficos associados às filiais.
- **Dispositivo:** Representa os dispositivos IoT instalados.
- **Sensor:** Sensores associados aos dispositivos, registrando dados de consumo.
- **Histórico:** Registros de consumo energético e emissões de carbono.
- **Regulação de Energia:** Dados sobre tarifas e bandeiras tarifárias vigentes.

### Tecnologias Utilizadas:

- **Banco de Dados:** Oracle
- **Framework ORM:** Entity Framework Core
- **Ferramentas de Migração:** CLI do .NET para criar e aplicar migrações.
- **Ferramentas de Seed:** DataSeeder para popular tabelas com dados iniciais.
  
### Entidades e Relacionamentos:
- **Empresa:** Relação 1:N com Filial.
- **Filial:** Relação 1:N com Dispositivo.
- **Dispositivo:** Relação N:N com Sensor (via tabela associativa).
- **Sensor:** Relação 1:N com Alerta e N:N com Historico (via tabela associativa).
- **Alerta:** Relacionado a Sensor.
- **Historico:** Relacionado a RegulacaoEnergia e a Sensor (via tabela associativa).

### Diagrama Relacional
![image](https://github.com/user-attachments/assets/9f60aa4f-5298-4427-8af2-fc7a54a62e7a)

### Diagrama lógico
![image](https://github.com/user-attachments/assets/abd358ba-dbe7-4e56-a2c3-11233dc429f5)

### Integrantes do grupo
<table>
  <tr>
        <td align="center">
      <a href="https://github.com/biancaroman">
        <img src="https://avatars.githubusercontent.com/u/128830935?v=4" width="100px;" border-radius='50%' alt="Bianca Román's photo on GitHub"/><br>
        <sub>
          <b>Bianca Román</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/charlenefialho">
        <img src="https://avatars.githubusercontent.com/u/94643076?v=4" width="100px;" border-radius='50%' alt="Charlene Aparecida's photo on GitHub"/><br>
        <sub>
          <b>Charlene Aparecida</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/laiscrz">
        <img src="https://avatars.githubusercontent.com/u/133046134?v=4" width="100px;" alt="Lais Alves's photo on GitHub"/><br>
        <sub>
          <b>Lais Alves</b>
        </sub>
      </a>
    </td>
    <td align="center">
      <a href="https://github.com/LuccaRaphael">
        <img src="https://avatars.githubusercontent.com/u/127765063?v=4" width="100px;" border-radius='50%' alt="Lucca Raphael's photo on GitHub"/><br>
        <sub>
          <b>Lucca Raphael</b>
        </sub>
      </a>
    </td>
     <td align="center">
      <a href="https://github.com/Fabs0602">
        <img src="https://avatars.githubusercontent.com/u/111320639?v=4" width="100px;" border-radius='50%' alt="Fabricio Torres's photo on GitHub"/><br>
        <sub>
          <b>Fabricio Torres</b>
        </sub>
      </a>
    </td>
  </tr>
</table>
