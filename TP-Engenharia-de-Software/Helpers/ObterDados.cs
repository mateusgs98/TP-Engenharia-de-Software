using System;

namespace TP_Engenharia_de_Software.Helpers
{
    public class ObterDados : IObterDados
    {
        public string ObterNome() => Console.ReadLine();
        public string ObterCpf() => Console.ReadLine();
        public string ObterLocal() => Console.ReadLine();
        public string ObterDataHora() => Console.ReadLine();
        public string ObterExame() => Console.ReadLine();
        public string ObterResultado() => Console.ReadLine();
        public string ObterDisponibilidade() => Console.ReadLine();
        public string ObterChave() => Console.ReadLine();
    }
}