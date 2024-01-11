using System.ComponentModel.DataAnnotations;

namespace VerhovskiyIvanKT_41_20.Models
{
    public class Group
    {
        [Key]
        public int? GroupId { get; set; }

        public string? GroupName { get; set; }

       // public int?  StudentId { get; set; }
       // public ICollection<Student>? Students { get; set; }
    }
}
