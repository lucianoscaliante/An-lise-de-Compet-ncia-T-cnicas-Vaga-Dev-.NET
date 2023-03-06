using Microsoft.EntityFrameworkCore;
using Projeto_ControleALunos.Data.Map;
using Projeto_ControleALunos.Models;

namespace Projeto_ControleALunos.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<DisciplinasModel> Disciplinas { get; set; }
        public DbSet<MatriculasModel> Matriculas { get; set;}
        public DbSet<AlunosModel> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MatriculaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
