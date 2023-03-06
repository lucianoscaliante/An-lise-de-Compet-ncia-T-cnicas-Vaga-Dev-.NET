using System.Collections.Generic;

namespace Projeto_ControleALunos.Models
{
    public class AlunosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<MatriculasModel> Matriculas { get; set; }
        public List<NotasModel> Notas { get; set; }
    }
}

