namespace MudBlazorFrontend.Components.Data
{
    public class HistoryEvent
    {
        public int ID { get; set; }
        public string Name { get; set; } = String.Empty;
        public string ShortDescription { get; set; } = String.Empty;
        public string LongDescription { get; set; } = String.Empty;
        public DateTime EventTimeStart { get; set; }
        public DateTime? EventTimeEnd { get; set; }
        public bool IsBeforeCommonEra { get; set; }
        public DateType DateType { get; set; }
        public int LevelOfDetail { get; set; }
    }
}
