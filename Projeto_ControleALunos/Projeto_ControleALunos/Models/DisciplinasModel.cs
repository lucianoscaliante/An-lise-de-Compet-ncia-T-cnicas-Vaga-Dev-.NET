using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projeto_ControleALunos.Models
{
    public class DisciplinasModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "*Digite o nome da Disciplina")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "*Digite a descrição da Disciplina")]
        public string Discricao { get; set; }

        public int matriculaId { get; set; }


        public MatriculasModel Matriculas { get; set; } 

    }
}

