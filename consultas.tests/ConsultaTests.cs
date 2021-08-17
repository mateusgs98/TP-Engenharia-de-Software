using System;
using TP_Engenharia_de_Software;
using Xunit;

namespace consultas.tests
{
    public class ConsultaTests
    {
        [Fact]
        public void MarcarConsulta_Test()
        {
            bool result = Consulta.MarcarConsulta();
            Assert.True(result);
        }

        [Fact]
        public void ConsultarHistoricoPaciente_Test()
        {
            bool result = Consulta.ConsultarHistoricoPaciente();
            Assert.True(result);
        }
    }
}
