using Application;
using Application.Data.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class HistoryEventRepository : IHistoryEventRepository
    {
        private readonly HistoryTimelineDbContext _context;

        public HistoryEventRepository(HistoryTimelineDbContext context) { _context = context; }

        public async Task<int> CreateAsync(
            UpsertHistoryEventDto upsertHistoryEvent,
            CancellationToken cancellationToken)
        {
            var historyEvent = new HistoryEvent
            {
                Name = upsertHistoryEvent.Name,
                ShortDescription = upsertHistoryEvent.ShortDescription,
                LongDescription = upsertHistoryEvent.LongDescription,
                EventTimeStart = upsertHistoryEvent.EventTimeStart,
                EventTimeEnd = upsertHistoryEvent.EventTimeEnd,
                IsBeforeCommonEra = upsertHistoryEvent.IsBeforeCommonEra,
                LevelOfDetail = upsertHistoryEvent.LevelOfDetail,
                DateType = upsertHistoryEvent.DateType,
                Created = DateTime.UtcNow
            };

            await _context.AddAsync(historyEvent, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return historyEvent.ID;
        }

        public async Task<GetHistoryEventDto?> GetFromIdAsync(int id, CancellationToken cancellationToken)
        {
            var historyEvent = await _context.HistoryEvents
                .Where(x => x.ID == id)
                .Select(x => new GetHistoryEventDto(
                x.ID,
                x.Name,
                x.ShortDescription,
                x.LongDescription,
                x.EventTimeStart,
                x.EventTimeEnd,
                x.IsBeforeCommonEra,
                x.DateType,
                x.LevelOfDetail))
                .FirstOrDefaultAsync(cancellationToken);

            if (historyEvent == null)
                return null;

            return historyEvent;
        }

        public async Task<GetShortHistoryEventDto[]?> GetFromLevelOfDetailAsync(int levelOfDetail, CancellationToken cancellationToken)
        {
            var historyEvent = await _context.HistoryEvents
                .Where(x => x.LevelOfDetail == levelOfDetail)
                .Select(x => new GetShortHistoryEventDto(
                x.ID,
                x.Name,
                x.ShortDescription,
                x.EventTimeStart,
                x.EventTimeEnd,
                x.IsBeforeCommonEra,
                x.DateType))
                .ToArrayAsync(cancellationToken);


            if (historyEvent == null)
                return null;

            return historyEvent;
        }

        public async Task<bool> UpdateAsync(int id, UpsertHistoryEventDto upsertHistoryEventDto, CancellationToken cancellationToken)
        {
            var historyEvent = await _context.HistoryEvents.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

            if (historyEvent == null)
                return false;

            historyEvent.Name = upsertHistoryEventDto.Name;
            historyEvent.ShortDescription = upsertHistoryEventDto.ShortDescription;
            historyEvent.LongDescription = upsertHistoryEventDto.LongDescription;
            historyEvent.EventTimeStart = upsertHistoryEventDto.EventTimeStart;
            historyEvent.EventTimeEnd = upsertHistoryEventDto.EventTimeEnd;
            historyEvent.IsBeforeCommonEra = upsertHistoryEventDto.IsBeforeCommonEra;
            historyEvent.DateType = upsertHistoryEventDto.DateType;
            historyEvent.LevelOfDetail = upsertHistoryEventDto.LevelOfDetail;
            historyEvent.LastUpdate = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken)
        {
            var historyEvent = await _context.HistoryEvents.SingleOrDefaultAsync(x => x.ID == id, cancellationToken);

            if (historyEvent == null)
                return false;

            _context.Remove(historyEvent);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
            
        }

        public async Task<int> GetMaxLevelOfDetail(CancellationToken cancellationToken)
        {
            var historyEvent = await _context.HistoryEvents.OrderByDescending(x => x.LevelOfDetail).FirstOrDefaultAsync(cancellationToken);

            if (historyEvent == null)
                return 0;

            return historyEvent.LevelOfDetail;
        }
    }
}
