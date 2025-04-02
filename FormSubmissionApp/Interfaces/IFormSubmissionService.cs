using FormSubmissionApp.Models;

namespace FormSubmissionApp.Interfaces
{
    public interface IFormSubmissionService
    {
        Task<FormSubmission> SubmitForm(string formType, Dictionary<string, object> formData);
        Task<IEnumerable<FormSubmission>> GetAllSubmissions();
        Task<IEnumerable<FormSubmission>> SearchSubmissions(string formType, string searchTerm);
    }
}
