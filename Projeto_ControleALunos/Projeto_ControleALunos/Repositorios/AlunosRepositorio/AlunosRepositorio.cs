using Projeto_ControleALunos.Data;
using Projeto_ControleALunos.Models;
using System;
using System.Linq;

namespace Projeto_ControleALunos.Repositorios.AlunosRepositorio
{
    public class AlunosRepositorio : IAlunosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AlunosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public AlunosModel AdicionarAluno(AlunosModel alunos)
        {
            _bancoContext.Alunos.Add(alunos);
            _bancoContext.SaveChanges();
            return alunos;
        }
        public AlunosModel ListarAlunoPorId(int id)
        {
            return _bancoContext.Alunos.FirstOrDefault(x => x.Id == id);
        }
    }
}
