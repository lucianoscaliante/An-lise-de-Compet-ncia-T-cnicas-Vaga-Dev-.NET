using System;

namespace Projeto_ControleALunos.Models
{
    public class NotasModel
    {
        public int Id { get; set; }
        public int AlunosId { get; set; }
        public AlunosModel Alunos { get; set; }
        public int MateriasId { get; set; }
        public MateriasModel Materias { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataNota { get; set; }
    }
}
