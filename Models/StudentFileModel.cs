using System.ComponentModel.DataAnnotations;

namespace StudentTaskManagementSystem.Models
{
    public class StudentFileModel
    {
        [Key]
        public int FeildId { get; set; }
        [Required]
        public string FileName { get; set; } = string.Empty;
        [Required]
        public string BlobName { get; set; } = string.Empty;
        public string ContentType {  get; set; } = string.Empty;
        public long FileSize { get; set; }
        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
    }
}
