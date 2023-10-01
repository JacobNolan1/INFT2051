using SQLite;


namespace Sleepwise.Models
{
    [Table("day_insights")]
    public class DayInsightModel : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string ExerciseLevel { get; set; }
        [MaxLength(20)]
        public string Food { get; set; }
        [MaxLength(20)]
        public string FoodQuality { get; set; }
        [MaxLength(20)]
        public string Work { get; set; }
        [MaxLength(20)]
        public string WorkExperience { get; set; }
    }
}