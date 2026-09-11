# Course Enrollment System
A web-based CRUD application built in ASP.NET Core MVC (.NET 10), simulating a course enrollment system with student records and course management. Built to practice core MVC concepts (Controllers, Models, Razor Views, routing, LINQ, and in-memory data handling) in C#.

# Features
Student Management — add, view, edit, and delete students, each with personal details (name, age, gender, contact number, email, enrollment date)
Course Management — add, view, edit, and delete courses, each with course-specific attributes (course name, instructor, duration, credits, fee)
Search Student — filters the student list by name using a case-insensitive substring match
View Courses (Paginated) — displays courses in a table, 2 per page, with Next / Previous navigation
Sort By Fee — sorts courses by fee (descending) via a query-string toggle, with sort state preserved across pagination
Client-Side Validation — JavaScript validation in site.js checking required fields on Add/Edit forms before submission
Custom Styling — tables, forms, pagination links, and sort/action links styled via site.css
# Tech Stack
C# (.NET 10)
ASP.NET Core MVC
Razor Views (.cshtml)
HTML / CSS (custom) / JavaScript (vanilla)
In-memory data storage using List<T> (no external database)
Architecture / MVC Concepts Used
Model — Student and Course are plain classes defining the shape of the data (Id, Name, Age, etc. and CourseName, Instructor, Duration, Credits, Fee)
Controller — StudentController and CourseController hold all CRUD logic and in-memory data; each has actions for Index, Add, Edit, and Delete
View — Razor views (Index.cshtml, Add.cshtml, Edit.cshtml) render the tables and forms, using @model for strong typing and @foreach to loop over lists
Routing — the default route {controller}/{action}/{id?} maps URLs like /Student/Edit/3 to the correct action, with [HttpGet] / [HttpPost] disambiguating the two Edit overloads
In-Memory Storage — data lives in a static List<T> inside each controller; changes are lost on restart and there is no persistence layer (by design — this project intentionally precedes the Entity Framework / database stage of the roadmap)
LINQ — used for filtering (Where(s => s.Name.Contains(SearchName))), sorting (OrderByDescending(c => c.Fee)), and pagination (Skip((page - 1) * pageSize).Take(pageSize))
ViewBag — used to pass small, non-model values to the view alongside the main model — CurrentPage, TotalPages, and the active SortbyFee state, so pagination links can preserve the current sort order
# Project Structure
Course Enrollment System/
├── Controllers/
│   ├── StudentController.cs   — CRUD + search + in-memory student data
│   └── CourseController.cs    — CRUD + sort + pagination + in-memory course data
│
├── Models/
│   ├── Student.cs              — Id, Name, Age, Gender, ContactNumber, Email, EnrollmentDate
│   └── Course.cs                — Id, CourseName, Instructor, Duration, Credits, Fee
│
├── Views/
│   ├── Student/
│   │   ├── Index.cshtml          — list + search form
│   │   ├── Add.cshtml             — add student form
│   │   └── Edit.cshtml             — edit student form
│   ├── Course/
│   │   ├── Index.cshtml            — list + sort toggle + pagination
│   │   ├── Add.cshtml                — add course form
│   │   └── Edit.cshtml                 — edit course form
│   └── Shared/
│       └── _Layout.cshtml               — master layout (nav, CSS/JS links)
│
├── wwwroot/
│   ├── css/site.css                      — table, form, pagination, and link styling
│   └── js/site.js                         — client-side required-field validation
│
└── Program.cs                              — app startup / middleware pipeline
# How to Run
Clone the repository
Open the .slnx file in Visual Studio
Run with F5 / the green Run button, or dotnet run
Navigate to /Student or /Course in the browser to reach the respective directories
# Sample Usage
#Student
1 - View all students
2 - Search student by name
3 - Add student
4 - Edit student
5 - Delete student

#Course
1 - View all courses (paginated, 2 per page)
2 - Sort courses by fee
3 - Next / Previous page
4 - Add course
5 - Edit course
6 - Delete course

# What I Learned
This project ties together Models, Controllers, and Razor Views into a single working two-entity MVC application, along with practical patterns like static List<T> in-memory storage, LINQ queries for search / sort / pagination (Where, OrderByDescending, Skip, Take), preserving query-string state (SortbyFee, page) across navigation links, disambiguating multiple Edit actions with [HttpGet] / [HttpPost], and connecting hand-written HTML/CSS/JavaScript to a Razor-rendered page rather than relying on scaffolded output.
