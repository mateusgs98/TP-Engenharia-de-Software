using System;
using TP_Engenharia_de_Software.Helpers;

namespace consultas.tests
{
    public class ObterDadosMock : IObterDados
    {
        public string ObterNome() => "João da Silva";
        public string ObterCpf() => "89832273706";
        public string ObterLocal() => "UFMG";
        public string ObterDataHora() => "18/08/2021 17:00";
        public string ObterExame() => "PCR";
        public string ObterResultado() => "Negativo";
        public string ObterDisponibilidade() => "s";
        public string ObterChave() => Guid.NewGuid().ToString();
    }
}