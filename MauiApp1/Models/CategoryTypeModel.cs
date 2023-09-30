using SQLite;

namespace Sleepwise.Models
{
    [Table("category_types")]
    public class CategoryTypeModel: ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Description { get; set; }
        public int SummaryTypeID { get; set; }
    }
}
