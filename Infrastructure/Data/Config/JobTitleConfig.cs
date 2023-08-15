using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class JobTitleConfig : BaseEntityConfig<JobTitle>
    {
        public override void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            base.Configure(builder);

            builder.Property(jt => jt.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
