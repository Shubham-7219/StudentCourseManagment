using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.GeneralRepository;

namespace StudentCourseManagment.Repository.EnrollRepository
{
    public interface IEnrollRepository : IRepository<Enrollement>
    {
        void Update(Enrollement enrollement);
        void Save();
       
    }
}
