namespace SchoolCollaborationWebApp.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        

        public ICollection<Course> Courses { get; set; }
    }
}
