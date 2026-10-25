namespace Application
{
    public record GetHistoryEventDto(
        int ID,
        string Name, 
        string ShortDescription, 
        string LongDescription, 
        DateTime EventTimeStart, 
        DateTime? EventTimeEnd,
        bool IsBeforeCommonEra,
        DateType DateType,
        int LevelOfDetail);
}