namespace FormSubmissionApp.Models
{
    public class SubmissionRequest
    {
        public string FormType { get; set; }
        public Dictionary<string, object> FormData { get; set; }
    }
}
