using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Server.Models
{
    public class UserRegistrationModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<TaskModel> Tasks {get; set;}
    }
}
