using TP_Engenharia_de_Software;
using TP_Engenharia_de_Software.Helpers;
using Xunit;

namespace exames.tests
{
    public class ExameTests
    {
        [Fact]
        public void CadastrarResultadoExame_Test()
        {
            IObterDados obterDados = new ObterDadosMock();
            bool result = Exame.CadastrarResultadoExame(obterDados);
            Assert.True(result);
        }

        [Fact]
        public void ConsultarResultadoExame_Test()
        {
            IObterDados obterDados = new ObterDadosMock();
            bool result = Exame.CadastrarResultadoExame(obterDados);
            Assert.True(result);
        }
    }
}