using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public interface IHistoryEventService
    {
        public Task<int> CreateAsync(UpsertHistoryEventDto upsertHistoryEventDto);
        public Task<GetHistoryEventDto?> GetFromIDAsync(int id, CancellationToken cancellationToken);
        public Task<GetShortHistoryEventDto[]?> GetFromLevelOfDetailAsync(int levelOfDetail, CancellationToken cancellationToken);
        public Task<bool> UpdateAsync(int id, UpsertHistoryEventDto upsertHistoryEventDto, CancellationToken cancellationToken);
        public Task<bool> RemoveAsync(int id, CancellationToken cancellationToken);
        public Task<int> GetMaxLevelOfDetail(CancellationToken cancellationToken);
    }
}
