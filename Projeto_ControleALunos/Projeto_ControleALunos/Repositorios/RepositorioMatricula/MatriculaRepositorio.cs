using Projeto_ControleALunos.Data;
using Projeto_ControleALunos.Models;

namespace Projeto_ControleALunos.Repositorios.RepositorioMatricula
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly BancoContext _bancoContext;
        public MatriculaRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public MatriculasModel AdicionarMatricula(MatriculasModel matriculas)
        {
            _bancoContext.Matriculas.Add(matriculas);
            _bancoContext.SaveChanges();
            return matriculas;
        }
    }
}
