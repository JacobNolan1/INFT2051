//using System.ComponentModel;
//using System.Runtime.CompilerServices;
using SQLite;

namespace Sleepwise.Models
{
    [Table("users")]
    public class UserModel: ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(320)]
        public string Email { get; set; }
        [MaxLength(60)]
        public string Password { get; set; }
    }
}
