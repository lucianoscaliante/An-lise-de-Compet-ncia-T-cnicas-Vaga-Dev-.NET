using Projeto_ControleALunos.Models;
using System.Collections.Generic;

namespace Projeto_ControleALunos.Repositorios.DisciplinasRepositorio
{
    public interface IDisciplinasRepositorios
    {
        DisciplinasModel AdicionarDisciplina(DisciplinasModel Disciplinas);
        List<DisciplinasModel> ListarTodasDisciplinas();
        DisciplinasModel ListarDisciplinaPorId(int id);
        DisciplinasModel ExcluirDisciplinaPorId(int id);
        DisciplinasModel AtualizarDisciplina(DisciplinasModel Disciplinas);
        bool Excluir(int id);
    }
}
