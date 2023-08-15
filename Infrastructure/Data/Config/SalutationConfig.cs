using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class SalutationConfig : BaseEntityConfig<Salutation>
    {
        public override void Configure(EntityTypeBuilder<Salutation> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.Name)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
