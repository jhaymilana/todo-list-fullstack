using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Final_Project.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Name { get; set; }
        [MinLength(3)]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Display(Name="Date of Creation")]
        public DateTime DateOfCreation { get; set; }
        public Priority Priority { get; set; }
        public Completion Completion { get; set; }
        public int ListId { get; set; }
        public List List { get; set; }
    }
    
    public enum Priority
    {
        Low,
        Medium,
        High
    }
    public enum Completion
    {
        ToDo,
        Completed
    }
}