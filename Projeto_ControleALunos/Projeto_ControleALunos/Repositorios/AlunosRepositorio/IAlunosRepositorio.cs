using Projeto_ControleALunos.Models;

namespace Projeto_ControleALunos.Repositorios.AlunosRepositorio
{
    public interface IAlunosRepositorio
    {
        AlunosModel AdicionarAluno(AlunosModel Alunos);
        AlunosModel ListarAlunoPorId(int id);
    }
}
