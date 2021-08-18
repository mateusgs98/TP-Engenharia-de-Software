using System;
using TP_Engenharia_de_Software.Helpers;

namespace TP_Engenharia_de_Software
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@$"Bem-vindo à Gestão de sua Clínica!{Environment.NewLine}
Para marcar uma consulta, pressione ""c"".{Environment.NewLine}
Para consultar o histórico de um paciente, pressione ""h"".{Environment.NewLine}
Para cadastrar o resultado de um exame, pressione ""e"".{Environment.NewLine}
Para consultar o resultado de um exame, pressione ""r"".{Environment.NewLine}
Para sair, pressione qualquer outra tecla.");

            bool finalizarExecucao = false;
            while (!finalizarExecucao)
            {
                string comando = Console.ReadLine().ToLower();
                finalizarExecucao = DirecionarOperacao(comando);
            }
        }

        private static bool DirecionarOperacao(string comando)
        {
            bool finalizarExecucao = false;
            IObterDados obterDados = new ObterDados();
            switch (comando)
            {
                case "c":
                    Consulta.MarcarConsulta(obterDados);
                    break;

                case "h":
                    Consulta.ConsultarHistoricoPaciente(obterDados);
                    break;

                case "e":
                    Exame.CadastrarResultadoExame(obterDados);
                    break;

                case "r":
                    Exame.ConsultarResultadoExame(obterDados);
                    break;

                default:
                    finalizarExecucao = true;
                    break;
            }

            if (finalizarExecucao)
                Console.WriteLine("Finalizando a execução do sistema...");
            else
                Console.WriteLine("Aguardando o próximo comando...");

            return finalizarExecucao;
        }
    }
}