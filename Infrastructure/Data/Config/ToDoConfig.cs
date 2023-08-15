using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class ToDoConfig : BaseEntityConfig<ToDo>
    {
        public override void Configure(EntityTypeBuilder<ToDo> builder)
        {
            base.Configure(builder);

            builder.Property(td => td.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(td => td.RelatedEntity)
                .HasMaxLength(50);
        }
    }
}
