using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Edgias.Humano.ApplicationCore.Entities;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class LeaveDayConfig : BaseEntityConfig<LeaveDay>
    {
        public override void Configure(EntityTypeBuilder<LeaveDay> builder)
        {
            base.Configure(builder);

        }
    }
}
