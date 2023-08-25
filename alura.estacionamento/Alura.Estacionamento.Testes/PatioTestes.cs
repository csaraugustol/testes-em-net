using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes: IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            //var estacionamento = new Patio();

            var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos André";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Compass";
            veiculo.Placa = "ABC-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Carlos André", "Azul", "Compass", "ABC-1234")]
        [InlineData("Carlos André", "Preto", "HRV", "FGH-1254")]
        [InlineData("Carlos André", "Cinza", "Virtus", "HFH-1453")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario,
            string cor, string modelo, string placa)
        {
            //Arrange
            //var estacionamento = new Patio();

            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Carlos André", "Azul", "Compass", "ABC-1234")]
        public void LocalizaVeiculoPatio(string proprietario,
            string cor, string modelo, string placa)
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }

        [Fact]
        public void AlteraDadosVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();

            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Carlos André";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Compass";
            veiculo.Placa = "ABC-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Carlos André";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Azul";
            veiculoAlterado.Modelo = "Compass";
            veiculoAlterado.Placa = "ABC-1234";

            //Act
            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }
}
