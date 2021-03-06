using Newtonsoft.Json;
using System;
using System.IO;

namespace TP_Engenharia_de_Software.Helpers
{
    public static class JsonFileHelper
    {
        public static T DesserializarArquivoJson<T>(string nomeArquivo)
        {
            string json = File.ReadAllText(ObterCaminhoArquivo(nomeArquivo));
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void SalvarConteudoArquivoJson(object conteudo, string nomeArquivo)
        {
            string json = JsonConvert.SerializeObject(conteudo);
            File.WriteAllText(ObterCaminhoArquivo(nomeArquivo), json);
        }

        private static string ObterCaminhoArquivo(string nomeArquivo)
        {
#if DEBUG
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory
                .Replace("consultas.tests", "TP-Engenharia-de-Software")
                .Replace("exames.tests", "TP-Engenharia-de-Software"),
                "..", "..", "..", "JsonFiles", nomeArquivo);
#else
            return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "JsonFiles", nomeArquivo);
#endif
        }
    }
}