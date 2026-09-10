using Course_Enrollment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Course_Enrollment_System.Controllers
{
    public class CourseController : Controller
    {
        static List<Course> courses = new List<Course>
        {
            new Course { ID = 1, CourseName = "Web Development", Instructor = "Sir Zain", Duration = 12, Credits = 3, Fee = 5000 },
            new Course { ID = 2, CourseName = "Data Science", Instructor = "Ma'am Sarah", Duration = 16, Credits = 4, Fee = 8000 },
            new Course { ID = 3, CourseName = "Mobile App Development", Instructor = "Sir Ahmed", Duration = 10, Credits = 2, Fee = 4000 },
            new Course { ID = 4, CourseName = "Machine Learning", Instructor = "Sir Zubair", Duration = 14, Credits = 3, Fee = 6000 },
            new Course { ID = 5, CourseName = "Cloud Computing", Instructor = "Sir Ali", Duration = 8, Credits = 2, Fee = 3000 }
        };
        public IActionResult Index(string SortbyFee, int page = 1)
        {
            int pageSize = 2;
            List<Course> sortedCourses = courses;

            if (!string.IsNullOrEmpty(SortbyFee))
            {
                sortedCourses = courses.OrderByDescending(c => c.Fee).ToList();
            }

            int totalPages = (int)Math.Ceiling((double)sortedCourses.Count / pageSize);

            sortedCourses = sortedCourses.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(sortedCourses);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Course course)
        {
            course.ID = courses.Count + 1;
            courses.Add(course);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            bool found = false;
            Course result = null;
            foreach (var course in courses)
            {
                if (course.ID == Id)
                {
                    result = course;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(int Id, Course updatedCourse)
        {
            bool found = false;
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].ID == Id)
                {
                    updatedCourse.ID = Id;
                    courses[i] = updatedCourse;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            bool found = false;
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].ID == Id)
                {
                    found = true;
                    courses.RemoveAt(i);
                    break;
                }
            }
            if (!found)
            {
                return NotFound();
            }
            return RedirectToAction("Index");

        }
    }
}
