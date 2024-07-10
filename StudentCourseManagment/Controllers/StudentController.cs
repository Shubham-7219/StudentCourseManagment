using Microsoft.AspNetCore.Mvc;
using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.StudentRepository;

namespace StudentCourseManagment.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            List<Student> Students = _studentRepository.GetAll().ToList();
            return View(Students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student) 
        {
        if(ModelState.IsValid)
            {
                _studentRepository.Add(student);
                _studentRepository.Save();
                return RedirectToAction("Index");
            }
        return View();
        }

        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();
            }
            Student StudentFromDb = _studentRepository.Get(u=>u.Id==id);
            if(StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if(ModelState.IsValid)
            {
                _studentRepository.Update(student);
                _studentRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Student StudentFromDb = _studentRepository.Get(u => u.Id == id);
            if (StudentFromDb == null)
            {
                return NotFound();
            }
            return View(StudentFromDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Student? StudentFromDb = _studentRepository.Get(u => u.Id == id);
            if(StudentFromDb == null)
            {
                return NotFound();
            }
            _studentRepository.Remove(StudentFromDb);
            _studentRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
