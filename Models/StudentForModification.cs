using SchoolManagementD.Data;

namespace SchoolManagementD.Models
{
    public class StudentForModification
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int GroupId { get; set; }
        public int? SelectedGroupId { get; set; }

        public List<Group> Groups { get; set; }
    }
}
