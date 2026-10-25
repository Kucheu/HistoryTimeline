namespace Application
{
    public record GetShortHistoryEventDto(
        int ID,
        string Name, 
        string ShortDescription,
        DateTime EventTimeStart, 
        DateTime? EventTimeEnd,
        bool IsBeforeCommonEra,
        DateType DateType);
}