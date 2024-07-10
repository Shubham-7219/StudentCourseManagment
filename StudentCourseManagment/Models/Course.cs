using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagment.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name="Course Name")]
        public string? Name { get; set; }
        [Range(0, 5)]
        public int Credits {  get; set; }
        public ICollection<Student>? Student { get; set; }
    }
}
