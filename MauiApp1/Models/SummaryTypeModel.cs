using SQLite;
namespace Sleepwise.Models
{
    [Table("summary_types")]
    public class SummaryTypeModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
