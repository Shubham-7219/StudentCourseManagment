using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagment.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int StudentId {  get; set; }
        [Display(Name ="Student Name")]
        public string? Name { get; set; }
        [Display(Name="Student Address")]
        public string? Address { get; set; }

        public ICollection<Course>? Course { get; set; }
        
    }
}
