using System;

namespace TP_Engenharia_de_Software.Models
{
    public class DadosConsulta
    {
        public DadosConsulta()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public DateTime DataHora { get; set; }
        public string Local { get; set; }
        public string NomePaciente { get; set; }
        public string DocumentoPaciente { get; set; }
    }
}