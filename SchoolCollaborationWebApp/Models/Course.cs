namespace SchoolCollaborationWebApp.Models
{
    public class Course
    {
        public int course_id { get; set; }
        public string course_name { get; set; }
        public string course_description { get; set; }
        public Student teacher_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime end_date { get; set; }
        


        
    }
}
