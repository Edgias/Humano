using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal abstract class BaseEntityConfig<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(be => be.Id);

            builder.Property(be => be.Id)
                .ValueGeneratedOnAdd();

            builder.Property(be => be.CreatedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(be => be.LastModifiedBy)
                .HasMaxLength(50)
                .IsRequired(false);

            builder.Ignore(be => be.Events);
        }
    }
}
