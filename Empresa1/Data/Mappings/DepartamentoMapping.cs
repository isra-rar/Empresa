using Empresa1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empresa1.Data.Mappings
{
    public class DepartamentoMapping : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.NomeDepartamento)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasMany(d => d.Funcionarios)
                .WithOne(f => f.Departamento)
                .HasForeignKey(f => f.DepartamentoId);

            builder.ToTable("Departamentos");
        }
    }
}
