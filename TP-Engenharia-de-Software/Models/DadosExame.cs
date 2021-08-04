using System;

namespace TP_Engenharia_de_Software.Models
{
    public class DadosExame
    {
        public DadosExame()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public bool DisponivelPaciente { get; set; }
        public string NomeExame { get; set; }
        public string NomePaciente { get; set; }
        public string Resultado { get; set; }
    }
}