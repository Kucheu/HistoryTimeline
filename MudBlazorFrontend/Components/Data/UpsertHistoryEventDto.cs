namespace MudBlazorFrontend.Components.Data
{
    public record UpsertHistoryEventDto(
         string Name, 
        string ShortDescription, 
        string LongDescription, 
        DateTime EventTimeStart, 
        DateTime? EventTimeEnd,
        bool IsBeforeCommonEra,
        DateType DateType,
        int LevelOfDetail);
}