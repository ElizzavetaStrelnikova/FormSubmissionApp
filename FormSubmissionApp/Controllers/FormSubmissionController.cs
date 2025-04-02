using FormSubmissionApp.Interfaces;
using FormSubmissionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormSubmissionApp.Controllers;

[ApiController]
[Route("api/formsubmission")]
public class FormSubmissionController : ControllerBase
{
    private readonly IFormSubmissionService _submissionService;

    public FormSubmissionController(IFormSubmissionService submissionService)
    {
        _submissionService = submissionService;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitForm([FromBody] SubmissionRequest request)
    {
        var submission = await _submissionService.SubmitForm(request.FormType, request.FormData);
        return Ok(submission);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubmissions()
    {
        var submissions = await _submissionService.GetAllSubmissions();
        return Ok(submissions);
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchSubmissions([FromQuery] string formType, [FromQuery] string query)
    {
        var submissions = await _submissionService.SearchSubmissions(formType, query);
        return Ok(submissions);
    }


}
