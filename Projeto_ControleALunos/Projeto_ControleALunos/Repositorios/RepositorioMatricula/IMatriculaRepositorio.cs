using Projeto_ControleALunos.Models;
using System.Collections.Generic;

namespace Projeto_ControleALunos.Repositorios.RepositorioMatricula
{
    public interface IMatriculaRepositorio
    {
        MatriculasModel AdicionarMatricula(MatriculasModel matriculas);
    }
}
