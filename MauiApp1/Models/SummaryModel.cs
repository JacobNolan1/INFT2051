//using System.ComponentModel;
//using System.Runtime.CompilerServices;
using SQLite;

namespace Sleepwise.Models
{
    [Table("summaries")]
    public class SummaryModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int Rating { get; set; }

    }
}
