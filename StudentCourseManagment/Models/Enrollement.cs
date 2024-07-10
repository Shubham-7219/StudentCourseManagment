using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagment.Models
{
    public class Enrollement
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        
        public int CourseId {  get; set; }
        public Course? Course { get; set; }
        [Display(Name ="Date Of Enrollement")]
        public DateTime? DateOfEnroll {  get; set; }
    }
}
