using Jubo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jubo.Infrastructure.EfMaps
{
    public class PatientEfMap : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.ToTable("patient");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("name")
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("timestamptz")
                .IsRequired();
        }
    }
}