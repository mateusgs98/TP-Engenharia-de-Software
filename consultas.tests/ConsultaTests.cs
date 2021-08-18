using TP_Engenharia_de_Software;
using TP_Engenharia_de_Software.Helpers;
using Xunit;

namespace consultas.tests
{
    public class ConsultaTests
    {
        [Fact]
        public void MarcarConsulta_Test()
        {
            IObterDados obterDados = new ObterDadosMock();
            bool result = Consulta.MarcarConsulta(obterDados);
            Assert.True(result);
        }

        [Fact]
        public void ConsultarHistoricoPaciente_Test()
        {
            IObterDados obterDados = new ObterDadosMock();
            bool result = Consulta.ConsultarHistoricoPaciente(obterDados);
            Assert.True(result);
        }
    }
}