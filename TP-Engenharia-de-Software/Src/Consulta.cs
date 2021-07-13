using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TP_Engenharia_de_Software.Helpers;
using TP_Engenharia_de_Software.Models;

namespace TP_Engenharia_de_Software
{
    public static class Consulta
    {
        private static readonly string _nomeArquivoJson = "consultas.json";

        public static void MarcarConsulta()
        {
            try
            {
                var dadosConsulta = new DadosConsulta();

                Console.WriteLine("Insira o nome do paciente:");
                dadosConsulta.NomePaciente = Console.ReadLine();

                Console.WriteLine("Insira o CPF do paciente:");
                dadosConsulta.DocumentoPaciente = Console.ReadLine();

                Console.WriteLine("Insira o local da consulta:");
                dadosConsulta.Local = Console.ReadLine();

                Console.WriteLine(@"Insira a data e hora da consulta no formato ""dd/MM/aaaa hh:mm"":");
                dadosConsulta.DataHora = DateTime.ParseExact(Console.ReadLine(), "g", new CultureInfo("pt-BR"));

                var consultas = JsonFileHelper.DesserializarArquivoJson<List<DadosConsulta>>(_nomeArquivoJson);
                consultas.Add(dadosConsulta);
                JsonFileHelper.SalvarConteudoArquivoJson(consultas, _nomeArquivoJson);

                Console.WriteLine("Consulta marcada com sucesso!");
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao marcar a consulta. Por favor tente novamente.");
            }
        }

        public static void ConsultarHistoricoPaciente()
        {
            try
            {
                Console.WriteLine("Insira o documento do paciente:");
                string documentoPaciente = Console.ReadLine();

                var consultas = JsonFileHelper.DesserializarArquivoJson<List<DadosConsulta>>(_nomeArquivoJson);
                var consultasPaciente = consultas.Where(c => c.DocumentoPaciente == documentoPaciente).OrderByDescending(c => c.DataHora).ToList();

                if (consultasPaciente.Any())
                {
                    Console.WriteLine("Consultas:");
                    for (int i = 0; i < consultasPaciente.Count; i++)
                    {
                        Console.WriteLine($@"{i + 1} - Data e Hora: {consultasPaciente[i].DataHora:g}. Local: {consultasPaciente[i].Local}");
                    }
                }
                else
                {
                    Console.WriteLine($"Não foram encontradas consultas para o paciente com o documento: {documentoPaciente}");
                }
            }
            catch
            {
                Console.WriteLine("Ocorreu um erro ao consultar o histórico do paciente. Por favor tente novamente.");
            }
        }
    }
}