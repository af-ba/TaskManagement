using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Server.Models
{
    public class TaskModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual UserRegistrationModel? UserRegistration { get; set; }
    }
}
