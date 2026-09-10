namespace Course_Enrollment_System.Models
{
    public class Student
    {
        public int ID{ get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
