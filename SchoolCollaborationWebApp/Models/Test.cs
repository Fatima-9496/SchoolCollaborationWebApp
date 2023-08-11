namespace SchoolCollaborationWebApp.Models
{
    public class Test
    {
        public int Test_id { get; set; }
        public Course course_id { get; set;}
        public string quiz_title { get; set; }
        public string quiz_description { get; set; }
        public DateTime quiz_start_time { get; set; }
        public DateTime  quiz_end_time { get; set; }
        public string question_text { get; set; }
        public string correct_answer { get; set; }

    }
}
