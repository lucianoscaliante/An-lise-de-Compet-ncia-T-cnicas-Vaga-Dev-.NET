using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto_ControleALunos.Models;

namespace Projeto_ControleALunos.Data.Map
{
    public class MatriculaMap : IEntityTypeConfiguration<MatriculasModel>
    {
        public void Configure(EntityTypeBuilder<MatriculasModel> builder)
        {
            builder.ToTable("Matriculas");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            builder.Property(m => m.AlunosId).HasColumnName("AlunosId").IsRequired();
            builder.Property(m => m.MateriasId).HasColumnName("MateriasId").IsRequired();
            builder.HasOne(m => m.Alunos).WithMany(a => a.Matriculas).HasForeignKey(m => m.AlunosId);
            builder.HasOne(m => m.Materias).WithMany(d => d.Matriculas).HasForeignKey(m => m.MateriasId);
        }
    }
}
