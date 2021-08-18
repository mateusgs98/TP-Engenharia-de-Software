using System;
using TP_Engenharia_de_Software;
using Xunit;

namespace exames.tests
{
    public class ExameTests
    {
        [Fact]
        public void CadastrarResultadoExame_Test()
        {
            bool result = Exame.CadastrarResultadoExame();
            Assert.True(result);
        }

        [Fact]
        public void ConsultarResultadoExame_Test()
        {
            bool result = Exame.CadastrarResultadoExame();
            Assert.True(result);
        }
    }
}
