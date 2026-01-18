using Jubo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jubo.Infrastructure.EfMaps
{
    public class PatientOrderEfMap : IEntityTypeConfiguration<PatientOrder>
    {
        public void Configure(EntityTypeBuilder<PatientOrder> builder)
        {
            builder.ToTable("patient_order");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("patient_order_id")
                .IsRequired();

            builder.Property(x => x.PatientId)
                .HasColumnName("patient_id")
                .IsRequired();

            builder.Property(x => x.Message)
                .HasColumnName("message")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(x => x.CreatedTime)
                .HasColumnName("created_time")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.Property(x => x.UpdatedTime)
                .HasColumnName("updated_time")
                .HasColumnType("timestamptz")
                .IsRequired();

            builder.HasOne(po => po.Patient)
                .WithMany(p => p.Orders)
                .HasForeignKey(po => po.PatientId);
        }
    }
}