using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Data.Repositories
{
    public interface IHistoryEventRepository
    {
        Task<int> CreateAsync(
            UpsertHistoryEventDto upsertHistoryEventDto,
            CancellationToken cancellationToken);

        Task<GetHistoryEventDto?> GetFromIdAsync(
            int id,
            CancellationToken cancellationToken);

        Task<GetShortHistoryEventDto[]?> GetFromLevelOfDetailAsync(
            int levelOfDetail,
            CancellationToken cancellationToken);

        Task<bool> UpdateAsync(
            int id,
            UpsertHistoryEventDto upsertHistoryEventDto,
            CancellationToken cancellationToken);

        Task<bool> RemoveAsync(
            int id,
            CancellationToken cancellationToken);

        Task<int> GetMaxLevelOfDetail(
            CancellationToken cancellationToken);
    }
}
