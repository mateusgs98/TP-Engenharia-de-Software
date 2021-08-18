namespace TP_Engenharia_de_Software.Helpers
{
    public interface IObterDados
    {
        string ObterNome();
        string ObterCpf();
        string ObterLocal();
        string ObterDataHora();
        string ObterExame();
        string ObterResultado();
        string ObterDisponibilidade();
        string ObterChave();
    }
}