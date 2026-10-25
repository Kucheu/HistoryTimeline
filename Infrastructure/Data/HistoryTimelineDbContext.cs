using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Infrastructure.Data
{
    public  class HistoryTimelineDbContext : DbContext
    {
        public required DbSet<HistoryEvent> HistoryEvents { get; init; }

        public HistoryTimelineDbContext()
        {

        }

        public HistoryTimelineDbContext(DbContextOptions<HistoryTimelineDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HistoryTimelineDbContext).Assembly);
        }
    }
}
