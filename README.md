# Course Enrollment System
A web-based CRUD application built in ASP.NET Core MVC (.NET 10), simulating a course enrollment system with student records and course management. Built to practice core MVC concepts (Controllers, Models, Razor Views, routing, and in-memory data handling) in C#.

# Features
Student Management — add, view, edit, and delete students, each with personal details (name, age, gender, contact number, email, enrollment date)
Course Management — add, view, edit, and delete courses, each with course-specific attributes (course name, instructor, duration, credits, fee)
View Students — displays all students in a table with their details
Search Student — filters the student list by name using a case-insensitive substring match
View Courses — displays all courses in a table with pagination (2 courses per page) and Next / Previous navigation
Sort By Fee — sorts courses by fee in ascending order via a SortByFee query parameter
Client-Side Validation — partial JavaScript validation in site.js to check required fields on Add forms

# Tech Stack
C# (.NET 10)
ASP.NET Core MVC
Razor Views (.cshtml)
Bootstrap and jQuery (via wwwroot/lib, not yet applied to views)
In-memory data storage using static List<T> (no external database)

# Architecture / MVC Concepts Used
Model — Student and Course are plain POCO classes defining the shape of data (ID, Name, Age, etc. and CourseName, Instructor, Duration, Credits, Fee)
Controller — StudentController and CourseController hold all CRUD logic and in-memory data; each has actions for Index, Add, Edit, and Delete
View — Razor views (Index.cshtml, Add.cshtml, Edit.cshtml) render the tables and forms, using @model for strong typing and @foreach to loop over the list
Routing — Default route {controller}/{action}/{id?} maps URLs like /Student/Edit/3 to the correct action, with [HttpGet] and [HttpPost] attributes disambiguating the two Edit methods
In-Memory Storage — data lives in a static List<T> inside each controller; changes are lost on restart and there is no persistence layer
LINQ — used for filtering (Where(s => s.Name.Contains(SearchName))), sorting (OrderBy(c => c.Fee)), and pagination (Skip((page - 1) * pageSize).Take(pageSize))

# Project Structure
text
Course Enrollment System/
├── Controllers/
│   ├── StudentController.cs      — CRUD + search + in-memory student data
│   └── CourseController.cs       — CRUD + sort + pagination + in-memory course data
│
├── Models/
│   ├── Student.cs                — ID, Name, Age, Gender, ContactNumber, Email, EnrollmentDate
│   └── Course.cs                 — ID, CourseName, Instructor, Duration, Credits, Fee
│
├── Views/
│   ├── Student/
│   │   ├── Index.cshtml          — list + search form
│   │   ├── Add.cshtml            — add student form
│   │   └── Edit.cshtml           — edit student form
│   ├── Course/
│   │   ├── Index.cshtml          — list + sort + pagination
│   │   ├── Add.cshtml            — add course form
│   │   └── Edit.cshtml           — edit course form
│   └── Shared/
│       └── _Layout.cshtml        — master layout
│
├── wwwroot/
│   ├── css/site.css              — custom styling for tables, forms, pagination
│   ├── js/site.js                — client-side form validation
│   └── lib/                      — Bootstrap and jQuery
│
└── Program.cs                    — app startup / middleware pipeline
# How to Run
Clone the repository
Open the project in Visual Studio / VS Code
Run dotnet run or launch via the IDE
Navigate to /Student or /Course in the browser to reach the respective directories

# Sample Menu Flow
text
/Student
  1 - View all students
  2 - Search student by name
  3 - Add student
  4 - Edit student
  5 - Delete student

/Course
  1 - View all courses (paginated, 2 per page)
  2 - Sort courses by fee
  3 - Next / Previous page
  4 - Add course
  5 - Edit course
  6 - Delete course
# What I Learned
This project ties together Models, Controllers, and Razor Views into a single working MVC application, along with practical patterns like in-memory static List<T> storage, LINQ queries for search / sort / pagination (Where, OrderBy, Skip, Take), query-string driven state (SearchName, SortByFee, page), and disambiguating multiple Edit actions using [HttpGet] and [HttpPost].
