using System.ComponentModel.DataAnnotations;

namespace MVC_Final_Project.Models
{
    public class List
    {
        internal object Task;

        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(250)]
        public string Name { get; set; }
        public HashSet<Task> Tasks { get; set; }
        public List() 
        { 
            Tasks = new HashSet<Task>();
        }
    }
}