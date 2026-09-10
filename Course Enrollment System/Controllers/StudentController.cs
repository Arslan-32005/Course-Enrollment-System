using Course_Enrollment_System.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Immutable;

namespace Course_Enrollment_System.Controllers
{
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>
        {
            new Student { ID = 1, Name = "Arslan Zahid", Age = 20, Gender = "Male", ContactNumber = 1234567890, Email = "sani@san.com", EnrollmentDate = new DateTime(2023, 1, 18)},
            new Student { ID = 2, Name = "Usama Aslam", Age = 22, Gender = "Male", ContactNumber = 876954321, Email = "usama@example.com", EnrollmentDate = new DateTime(2025, 5, 16)},
            new Student { ID = 3, Name = "Hamza Saleem", Age = 21, Gender = "Male", ContactNumber = 6789012345, Email = "hamza@sam.com", EnrollmentDate = new DateTime(2026, 9, 29)},
            new Student { ID = 4, Name = "Salman Nazir", Age = 19, Gender = "Male", ContactNumber = 0987654321, Email = "salam@kala.com", EnrollmentDate = new DateTime(2020, 1, 18)},
            new Student { ID = 5, Name = "Adnan Shokat", Age = 23, Gender = "Male", ContactNumber = 926719234, Email = "adnan@chacha.com", EnrollmentDate = new DateTime(2026, 1, 8) }
        };
        public IActionResult Index(string SearchName)
        {
            List<Student> filteredStudents = students;
            if(!string.IsNullOrEmpty(SearchName))
            {
                filteredStudents=students.Where(s=> s.Name.Contains(SearchName)).ToList();
            }
            return View(filteredStudents);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Student student)
        {
            student.ID = students.Count + 1;
            students.Add(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            bool found = false;
            Student result = null;
            foreach (var student in students)
            {
                if (student.ID == Id)
                {
                    result = student;
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
        public IActionResult Edit(int Id, Student updatedStudent)
        {
            bool found = false;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == Id)
                {
                    updatedStudent.ID = Id;
                    students[i] = updatedStudent;
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
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == Id)
                {
                    found = true;
                    students.RemoveAt(i);
                    break;
                }
            }
            if(!found)
            {
                return NotFound();
            }
            return RedirectToAction("Index"); 

        }
    }
}

