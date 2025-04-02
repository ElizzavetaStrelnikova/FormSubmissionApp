using FormSubmissionApp.Interfaces;
using FormSubmissionApp.Models;

namespace FormSubmissionApp.Services
{
    public class FormSubmissionService : IFormSubmissionService
    {
        private static readonly List<FormSubmission> _submissions = new();

        public Task<FormSubmission> SubmitForm(string formType, Dictionary<string, object> formData)
        {
            var submission = new FormSubmission
            {
                Id = Guid.NewGuid(),
                FormType = formType,
                FormData = formData,
                SubmissionDate = DateTime.UtcNow
            };

            _submissions.Add(submission);
            return Task.FromResult(submission);
        }

        public Task<IEnumerable<FormSubmission>> GetAllSubmissions()
        {
            return Task.FromResult(_submissions.AsEnumerable());
        }

        public Task<IEnumerable<FormSubmission>> SearchSubmissions(string formType, string searchTerm)
        {
            var query = _submissions.AsEnumerable();

            if (!string.IsNullOrEmpty(formType))
            {
                query = query.Where(s => s.FormType.Contains(formType, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(s =>
                    s.FormData.Any(fd =>
                        fd.Value?.ToString()?.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            return Task.FromResult(query);
        }
    }
}
