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
    public class PatioTestes : IDisposable
    {
        private Veiculo veiculo;
        private Patio estacionamento;
        Operador operador;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
            veiculo = new Veiculo();
            estacionamento = new Patio();
            operador = new Operador();
            operador.Nome = "José";
        }

        [Fact]
        public void ValidaFaturamento()
        {
            //Arrange
            //var estacionamento = new Patio();
            estacionamento.OperadorPatio = operador;
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

            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Carlos André", "Azul", "Compass", "ABC-1234")]
        public void LocalizaVeiculoPatioPeloIdTicket(string proprietario,
            string cor, string modelo, string placa)
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;
            estacionamento.OperadorPatio = operador;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act
            var consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            //Assert
            Assert.Contains("###Ticket Estacionamento Alura###", consultado.Ticket);
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Construtor invocado.");
        }
    }
}
