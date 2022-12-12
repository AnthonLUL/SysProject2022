using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbsenseApi.Models
{
    public class AbsenseTime
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime TimeStamp { get; set; }
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public bool CheckedIn { get; set; }

        public AbsenseTime(DateTime timeStamp, int studentId, bool checkedIn)
        {
            TimeStamp = timeStamp;
            StudentId = studentId;
            CheckedIn = checkedIn;
        }

        public AbsenseTime()
        {

        }
    }
}
