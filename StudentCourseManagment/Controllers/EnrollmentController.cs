using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagment.DataContext;
using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.CourseRepository;
using StudentCourseManagment.Repository.EnrollRepository;
using StudentCourseManagment.Repository.StudentRepository;

namespace StudentCourseManagment.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollRepository _enrollRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
     
        public EnrollmentController(IEnrollRepository enrollRepository,IStudentRepository studentRepository, ICourseRepository courseRepository,ApplicationDbContext context)
        {
            _enrollRepository = enrollRepository;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
           
        }
        public IActionResult Index()
        {
           
            var enrollments = _enrollRepository.GetAll().ToList();
            return View(enrollments);
        }
        public IActionResult Create()
        {
            var student = _studentRepository.GetAll().ToList();
            ViewBag.StudentList = new SelectList(student, "Id", "Name");

            var course = _courseRepository.GetAll().ToList();
            ViewBag.CourseList = new SelectList(course, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult Create(Enrollement enrollement)
        {
            if (ModelState.IsValid)
            {
                _enrollRepository.Add(enrollement);
                _enrollRepository.Save();
                return RedirectToAction("Index");
            }

            var student = _studentRepository.GetAll().ToList();
            ViewBag.StudentList = new SelectList(student, "Id", "Name");

            var course = _courseRepository.GetAll().ToList();
            ViewBag.CourseList = new SelectList(course, "Id", "Name");
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var student = _studentRepository.GetAll().ToList();
            ViewBag.StudentList = new SelectList(student, "Id", "Name");

            var course = _courseRepository.GetAll().ToList();
            ViewBag.CourseList = new SelectList(course, "Id", "Name");

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Enrollement EnrollFromDb = _enrollRepository.Get(u => u.Id == id);
            if (EnrollFromDb == null)
            {
                return NotFound();
            }
            return View(EnrollFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Enrollement enrollement)
        {
            if (ModelState.IsValid)
            {
                _enrollRepository.Update(enrollement);
                _enrollRepository.Save();
                return RedirectToAction("Index");
            }
            var student = _studentRepository.GetAll().ToList();
            ViewBag.StudentList = new SelectList(student, "Id", "Name");

            var course = _courseRepository.GetAll().ToList();
            ViewBag.CourseList = new SelectList(course, "Id", "Name");

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Enrollement EnrollFromDb = _enrollRepository.Get(u => u.Id == id);
            if (EnrollFromDb == null)
            {
                return NotFound();
            }
            return View(EnrollFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Enrollement? EnrollFromDb = _enrollRepository.Get(u => u.Id == id);
            if (EnrollFromDb == null)
            {
                return NotFound();
            }
            _enrollRepository.Remove(EnrollFromDb);
            _enrollRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
