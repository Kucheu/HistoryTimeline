using Application.Data.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.Implementation
{
    public class HistoryEventService : IHistoryEventService
    {
        private readonly IValidator<UpsertHistoryEventDto> _upsertHistoryDtoValidator;
        private readonly IHistoryEventRepository _historyEventRepository;

        public HistoryEventService(
            IValidator<UpsertHistoryEventDto> upsertHistoryDtoValidator, 
            IHistoryEventRepository historyEventRepository)
        {
            _upsertHistoryDtoValidator = upsertHistoryDtoValidator;
            _historyEventRepository = historyEventRepository;
        }

        public async Task<int> CreateAsync(UpsertHistoryEventDto upsertHistoryEventDto)
        {
            await _upsertHistoryDtoValidator.ValidateAndThrowAsync(upsertHistoryEventDto);
            return await _historyEventRepository.CreateAsync(upsertHistoryEventDto, CancellationToken.None);
        }

        public async Task<GetHistoryEventDto?> GetFromIDAsync(int id, CancellationToken cancellationToken)
        {
            return await _historyEventRepository.GetFromIdAsync(id, cancellationToken);
        }

        public async Task<GetShortHistoryEventDto[]?> GetFromLevelOfDetailAsync(int levelOfDetail, CancellationToken cancellationToken)
        {
            return await _historyEventRepository.GetFromLevelOfDetailAsync(levelOfDetail, cancellationToken);
        }

        public async Task<bool> UpdateAsync(int id, UpsertHistoryEventDto upsertHistoryEventDto, CancellationToken cancellationToken)
        {
            return await _historyEventRepository.UpdateAsync(id, upsertHistoryEventDto, cancellationToken);
        }

        public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken)
        {
            return await _historyEventRepository.RemoveAsync(id, cancellationToken);
        }

        public async Task<int> GetMaxLevelOfDetail(CancellationToken cancellationToken)
        {
            return await _historyEventRepository.GetMaxLevelOfDetail(cancellationToken);
        }
    }
}
