public class HistoryEvent
{
    public int ID { get; set; }
    public string Name { get; set; } = String.Empty;
    public string LongDescription { get; set; } = String.Empty;
    public string ShortDescription { get; set; } = String.Empty;
    public bool IsBeforeCommonEra { get; set; }
    public DateTime EventTimeStart { get; set; }
    public DateTime? EventTimeEnd { get; set; }
    public DateType DateType { get; set; }
    public int LevelOfDetail { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastUpdate { get; set; }
    
}
