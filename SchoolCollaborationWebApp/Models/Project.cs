namespace SchoolCollaborationWebApp.Models
{
    public class Project
    {
        public int project_id { get; set; }
        public Student user_id { get; set; }
        public string project_title { get; set; }
        public DateTime date_completed { get; set; }
        public string project_description { get; set; }
        public string media_url { get; set;}       
    }
}
