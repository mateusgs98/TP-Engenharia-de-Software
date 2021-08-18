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

        public static bool CadastrarResultadoExame(IObterDados obterDados)
        {
            try
            {
                var dadosExame = new DadosExame();

                Console.WriteLine("Insira o nome do paciente:");
                dadosExame.NomePaciente = obterDados.ObterNome();

                Console.WriteLine("Insira o nome do exame:");
                dadosExame.NomeExame = obterDados.ObterExame();

                Console.WriteLine("Insira o resultado do exame:");
                dadosExame.Resultado = obterDados.ObterResultado();

                Console.WriteLine(@"O exame estará disponível para consulta? Pressione ""s"" para SIM, qualquer outra tecla para NÃO:");
                dadosExame.DisponivelPaciente = obterDados.ObterDisponibilidade().ToLower() == "s";

                var exames = JsonFileHelper.DesserializarArquivoJson<List<DadosExame>>(_nomeArquivoJson);
                exames.Add(dadosExame);
                JsonFileHelper.SalvarConteudoArquivoJson(exames, _nomeArquivoJson);

                Console.WriteLine("Resultado de exame lançado com sucesso!");

                if (dadosExame.DisponivelPaciente)
                    Console.WriteLine($"Chave para consulta do exame: {dadosExame.Id}.");

                return true;
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao lançar o exame. Por favor tente novamente.");

                return false;
            }
        }

        public static bool ConsultarResultadoExame(IObterDados obterDados)
        {
            try
            {
                Console.WriteLine("Insira a chave para consulta do exame:");
                string chaveConsulta = obterDados.ObterChave();

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

                return true;
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao consultar o resultado do exame. Por favor tente novamente.");

                return false;
            }
        }
    }
}