namespace SchoolCollaborationWebApp.Models
{
    public class Assignments
    {
        public int assignment_id { get; set; }
        public Course course_id { get; set;}
        public string assignment_title { get; set;}
        public string assignment_description { get; set;}
        public DateTime deadline { get; set;}
        public bool submission { get; set; }
        public string submission_file_url { get; set; }

    }
}
