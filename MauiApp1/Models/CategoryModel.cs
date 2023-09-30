using SQLite;

namespace Sleepwise.Models
{
    [Table("categories")]
    public class CategoryModel: ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(20)]
        public string Description { get; set; }
        public int CategoryTypeId { get; set; }
    }
}
