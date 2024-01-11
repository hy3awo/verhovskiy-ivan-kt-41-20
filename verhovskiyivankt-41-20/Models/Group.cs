using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VerhovskiyIvanKT_41_20.Models
{
    public class Group
    {
        [Key]
        public int? GroupId { get; set; }

        public string? GroupName { get; set; }

        public bool IsValidGroupName() // Проверка формата ввода названия группы
        {
            return Regex.Match(GroupName, @"^[А-Я]-[0-9]{2}-[0-9]{2}$").Success;
        }

        // public int?  StudentId { get; set; }
        // public ICollection<Student>? Students { get; set; }
    }
}
