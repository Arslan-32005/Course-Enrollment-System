namespace Course_Enrollment_System.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string CourseName { get; set; }
        public string Instructor { get; set; }
        public int Duration { get; set; } 
        public int Credits { get; set; }
        public double Fee { get; set; }

    }
}
