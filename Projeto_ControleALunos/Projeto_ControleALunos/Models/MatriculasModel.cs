using System.Collections.Generic;

namespace Projeto_ControleALunos.Models
{
    public class MatriculasModel
    {
        public int Id { get; set; }
        public int AlunosId { get; set; }
        public AlunosModel Alunos { get; set; }
        public int MateriasId { get; set; }
        public MateriasModel Materias { get; set; }

        public List<DisciplinasModel> Disciplinas { get; set; }
        public int DisciplinaId { get; internal set; }
    }
}
