using System.ComponentModel.DataAnnotations;

namespace StudentTaskManagementSystem.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public ICollection<StudentTaskModel> Tasks { get; set; } = new List<StudentTaskModel>();
    }
}
