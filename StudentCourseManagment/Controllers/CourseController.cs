using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using StudentCourseManagment.Models;
using StudentCourseManagment.Repository.CourseRepository;
using StudentCourseManagment.Repository.StudentRepository;

namespace StudentCourseManagment.Controllers
{
    public class CourseController :Controller
    {
        private readonly ICourseRepository _courseRepository;
        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            List<Course> Courses = _courseRepository.GetAll().ToList();
            return View(Courses);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Add(course);
                _courseRepository.Save();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Course CourseFromDb = _courseRepository.Get(u => u.Id == id);
            if (CourseFromDb == null)
            {
                return NotFound();
            }
            return View(CourseFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepository.Update(course);
                _courseRepository.Save();
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
            Course CourseFromDb = _courseRepository.Get(u => u.Id == id);
            if (CourseFromDb == null)
            {
                return NotFound();
            }
            return View(CourseFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Course? CourseFromDb = _courseRepository.Get(u => u.Id == id);
            if (CourseFromDb == null)
            {
                return NotFound();
            }
            _courseRepository.Remove(CourseFromDb);
            _courseRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
