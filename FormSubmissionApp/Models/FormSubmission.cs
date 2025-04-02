namespace FormSubmissionApp.Models
{
    public class FormSubmission
    {
        public Guid Id { get; set; }
        public string FormType { get; set; }
        public Dictionary<string, object> FormData { get; set; }
        public DateTime SubmissionDate { get; set; }
    }
}
