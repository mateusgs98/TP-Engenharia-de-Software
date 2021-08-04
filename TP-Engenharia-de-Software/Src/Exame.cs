using System;
using System.Collections.Generic;
using System.Linq;
using TP_Engenharia_de_Software.Helpers;
using TP_Engenharia_de_Software.Models;

namespace TP_Engenharia_de_Software
{
    public static class Exame
    {
        private static readonly string _nomeArquivoJson = "exames.json";

        public static void CadastrarResultadoExame()
        {
            try
            {
                var dadosExame = new DadosExame();

                Console.WriteLine("Insira o nome do paciente:");
                dadosExame.NomePaciente = Console.ReadLine();

                Console.WriteLine("Insira o nome do exame:");
                dadosExame.NomeExame = Console.ReadLine();

                Console.WriteLine("Insira o resultado do exame:");
                dadosExame.Resultado = Console.ReadLine();

                Console.WriteLine(@"O exame estará disponível para consulta? Pressione ""s"" para SIM, qualquer outra tecla para NÃO:");
                dadosExame.DisponivelPaciente = Console.ReadLine().ToLower() == "s";

                var exames = JsonFileHelper.DesserializarArquivoJson<List<DadosExame>>(_nomeArquivoJson);
                exames.Add(dadosExame);
                JsonFileHelper.SalvarConteudoArquivoJson(exames, _nomeArquivoJson);

                Console.WriteLine("Resultado de exame lançado com sucesso!");

                if (dadosExame.DisponivelPaciente)
                    Console.WriteLine($"Chave para consulta do exame: {dadosExame.Id}.");
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao lançar o exame. Por favor tente novamente.");
            }
        }

        public static void ConsultarResultadoExame()
        {
            try
            {
                Console.WriteLine("Insira a chave para consulta do exame:");
                string chaveConsulta = Console.ReadLine();

                var exames = JsonFileHelper.DesserializarArquivoJson<List<DadosExame>>(_nomeArquivoJson);
                var exame = exames.FirstOrDefault(e => e.Id == chaveConsulta && e.DisponivelPaciente);
                if (exame != null)
                {
                    Console.WriteLine($@"Nome do paciente: {exame.NomePaciente}. Nome do exame: {exame.NomeExame}. Resultado do exame: {exame.Resultado}.");
                }
                else
                {
                    Console.WriteLine($"Não foi encontrado nenhum exame disponível para consulta com a chave: {chaveConsulta}.");
                }
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao consultar o resultado do exame. Por favor tente novamente.");
            }
        }
    }
}