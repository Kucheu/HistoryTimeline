using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class HistoryEventConfiguration : IEntityTypeConfiguration<HistoryEvent>
    {
        public void Configure(EntityTypeBuilder<HistoryEvent> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.ShortDescription).HasMaxLength(100);
            builder.Property(x => x.LongDescription).HasMaxLength(1000);

            builder.ToTable("HistoryEvents");
        }
    }
}
