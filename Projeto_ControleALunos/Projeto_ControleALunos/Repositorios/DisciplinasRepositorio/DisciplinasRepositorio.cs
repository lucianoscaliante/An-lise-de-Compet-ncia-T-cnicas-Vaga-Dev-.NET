using Projeto_ControleALunos.Data;
using Projeto_ControleALunos.Models;
using System.Collections.Generic;
using System.Linq;

namespace Projeto_ControleALunos.Repositorios.DisciplinasRepositorio
{
    public class DisciplinasRepositorio : IDisciplinasRepositorios
    {
        private readonly BancoContext _bancoContext;
        public DisciplinasRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public DisciplinasModel AdicionarDisciplina(DisciplinasModel disciplina)
        {
            _bancoContext.Disciplinas.Add(disciplina);
            _bancoContext.SaveChanges();
            return disciplina;
        }

        public DisciplinasModel AtualizarDisciplina(DisciplinasModel disciplinas)
        {
            DisciplinasModel disciplinasDb = ListarDisciplinaPorId(disciplinas.Id);

            if(disciplinasDb == null) throw new System.Exception("Erro ao atualizar a Disciplina");

            disciplinasDb.Nome = disciplinas.Nome;
            disciplinasDb.Discricao = disciplinas.Discricao;
            _bancoContext.Disciplinas.Update(disciplinasDb);
            _bancoContext.SaveChanges();
            return disciplinasDb;
        }

        public bool Excluir(int id)
        {
            DisciplinasModel disciplinaDb = ListarDisciplinaPorId(id);

            if (disciplinaDb == null) throw new System.Exception("Erro ao excluir a discipla!!!");

            _bancoContext.Disciplinas.Remove(disciplinaDb);
            _bancoContext.SaveChanges();

            return true;
        }

        public DisciplinasModel ExcluirDisciplinaPorId(int id)
        {
            var disciplina = _bancoContext.Disciplinas.FirstOrDefault(d => d.Id == id);

            if (disciplina == null) throw new System.Exception("Disciplina não encontrada");

            _bancoContext.Disciplinas.Remove(disciplina);
            _bancoContext.SaveChanges();
            return disciplina;
        }

        public DisciplinasModel ListarDisciplinaPorId(int id)
        {
            return _bancoContext.Disciplinas.FirstOrDefault(b => b.Id == id);
        }

        public List<DisciplinasModel> ListarTodasDisciplinas()
        {
            return _bancoContext.Disciplinas.ToList();
        }
    }
}
