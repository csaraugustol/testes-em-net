using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;
using System;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes: IDisposable
    {
        private Veiculo veiculo;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
        }

        [Fact]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Acelerar(10);

            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Frear(10);

            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();

            //Act
            veiculo.Tipo = 0;

            //Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName ="Nomea o método", Skip = "Com Skip o teste será ignorado .")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "José";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Bege";
            veiculo.Modelo = "Hilux";
            veiculo.Placa = "HTE-6512";

            //Act
            string dados = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }
}
