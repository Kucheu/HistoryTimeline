using Application;
using Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Endpoints
{
    public static class LevelOfDetailEndpoints
    {
        extension(WebApplication app)
        {
            public WebApplication MapHistoryEventsLevelOfDetail()
            {
                var group = app.MapGroup("/api/levelofdetails");

                group.MapGet("/", GetAsync);

                return app;
            }
        }

        public static async Task<int> GetAsync(
            IHistoryEventService historyEventService,
            CancellationToken cancellationToken)
        {
            int levelOfDetail = await historyEventService.GetMaxLevelOfDetail(cancellationToken);

            return levelOfDetail;
        }
    }
}
