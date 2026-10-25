using Application;
using Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints
{
    public static class HistoryEventsEndpoints
    {
        extension(WebApplication app)
        {
            public WebApplication MapHistoryEventsEndpoints()
            {
                var group = app.MapGroup("/api/historyevent");

                group.MapPost("/", CreateAsync);
                group.MapGet("{id:int}", GetFromIDAsync);
                group.MapPut("{id:int}", UpdateAsync);
                group.MapDelete("{id:int}", RemoveAsync);

                var multiGroup = app.MapGroup("/api/historyevents");
                multiGroup.MapGet("{levelOfDetail:int}", GetFromLevelOfDetailAsync);

                return app;
            }
        }

        public static async Task<Created<int>> CreateAsync(
            UpsertHistoryEventDto upsertHistoryEventDto,
            IHistoryEventService historyEventService)
        {
            return TypedResults.Created(
                String.Empty,
                await historyEventService.CreateAsync(upsertHistoryEventDto));
        }

        public static async Task<Results<Ok<GetHistoryEventDto>, NotFound>> GetFromIDAsync(
            int id,
            IHistoryEventService historyEventService,
            CancellationToken cancellationToken)
        {
            var historyEvent = await historyEventService.GetFromIDAsync(id, cancellationToken);

            if (historyEvent == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(historyEvent);
        }

        public static async Task<Results<Ok<GetShortHistoryEventDto[]>, NotFound>> GetFromLevelOfDetailAsync(
            int levelOfDetail,
            IHistoryEventService historyEventService,
            CancellationToken cancellationToken)
        {
            var historyEvent = await historyEventService.GetFromLevelOfDetailAsync(levelOfDetail, cancellationToken);

            if (historyEvent == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(historyEvent);
        }

        public static async Task<bool> UpdateAsync(
            int id,
            UpsertHistoryEventDto upsertHistoryEventDto,
            IHistoryEventService historyEventService,
            CancellationToken cancellationToken)
        {
            return await historyEventService.UpdateAsync(id, upsertHistoryEventDto, cancellationToken);
        }

        public static async Task<bool> RemoveAsync(
            int id,
            IHistoryEventService historyEventService,
            CancellationToken cancellationToken)
        {
            return await historyEventService.RemoveAsync(id, cancellationToken);
        }
    }
}
