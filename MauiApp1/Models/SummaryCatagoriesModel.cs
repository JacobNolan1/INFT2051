using SQLite;

namespace Sleepwise.Models
{
    [Table("summary_catagories")]
    public class SummaryCatagoriesModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int SummaryId { get; set; }
        public int CategoryId { get; set; }
    }
}
