using SchoolManagementD.Data;

namespace SchoolManagementD.Models
{
    public class StudentForCreation
    {
        public string Name { get; set; }
        public int GroupId { get; set; }

        public List<Group> Groups { get; set; }
    }
}
