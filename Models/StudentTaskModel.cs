using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTaskManagementSystem.Models
{
    public class StudentTaskModel
    {
        [Key]
        public int TaskId { get; set; }
        public string SubjectName { get; set; } = "";
        public string TaskName { get; set; } = "";
        public string TaskPriority { get; set; } = "";
        public string TaskDescription { get; set; } = "";
        public DateTime DueDate { get; set; } 
        public string TaskStatus { get; set; } = "";
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public UserModel User { get; set; }
    }
}
