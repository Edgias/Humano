using Edgias.Humano.ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Edgias.Humano.Infrastructure.Data.Config
{
    internal class CalendarSettingConfig : BaseEntityConfig<CalendarSetting>
    {
        public override void Configure(EntityTypeBuilder<CalendarSetting> builder)
        {
            base.Configure(builder);
        }
    }
}
