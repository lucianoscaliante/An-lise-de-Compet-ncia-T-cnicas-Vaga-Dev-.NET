using System.Collections.Generic;

namespace Projeto_ControleALunos.Models
{
    public class MateriasModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public List<MatriculasModel> Matriculas { get; set; }
        public List<NotasModel> Notas { get; set; }
    }
}
