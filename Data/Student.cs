using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementD.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("GroupId")]
        public int? GroupId { get; set; }
        public virtual Group Group { get; set; }
    }
}
