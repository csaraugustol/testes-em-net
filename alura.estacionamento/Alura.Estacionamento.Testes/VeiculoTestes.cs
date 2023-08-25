using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Xunit.Abstractions;
using System;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        Operador operador;
        public ITestOutputHelper SaidaConsoleTeste;

        public VeiculoTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
            operador.Nome = "José";
            veiculo.Tipo = TipoVeiculo.Automovel;
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

        [Fact(DisplayName = "Nomea o método", Skip = "Com Skip o teste será ignorado .")]
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

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            string nomePropietario = "CA";

            Assert.Throws<System.FormatException>(
                () => new Veiculo(nomePropietario)
            );
        }

        [Fact]
        public void TestaMesangemDeExcecaoDoQuartoCaractereDaPlaca()
        {
            string placa = "ASDF1234";

            var mensagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            Assert.Equal("O 4° caractere deve ser um hífen", mensagem.Message);
        }

        [Fact]
        public void AlteraDadosVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();

            //var veiculo = new Veiculo();
            estacionamento.OperadorPatio = operador;

            veiculo.Proprietario = "Carlos André";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Compass";
            veiculo.Placa = "ABC-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = veiculo.Proprietario;
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Azul";
            veiculoAlterado.Modelo = veiculo.Modelo;
            veiculoAlterado.Placa = veiculo.Placa;

            //Act
            var alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}
