using Microsoft.AspNetCore.Mvc;
using UglyToad.PdfPig;
using InterviewSenseAPI.Models;
using InterviewSenseAPI.Services;
namespace InterviewSenseAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResumeController : ControllerBase
{
    [HttpPost("analyze")]
    public async Task<IActionResult>AnalyzeResume(IFormFile file)
    {
        if (file == null)
        {
            return BadRequest("No file uploaded");
        }

        string text = "";

        using (var stream = file.OpenReadStream())
        using (var pdf = PdfDocument.Open(stream))
        {
            foreach (var page in pdf.GetPages())
            {
                text += page.Text + " ";
            }
        }

        string[] skills =
        {
            "python",
            "java",
            "javascript",
            "react",
            "node",
            "sql",
            "mongodb",
            "aws",
            "azure",
            ".net",
            "git"
        };

        var found = new List<string>();
        var missing = new List<string>();

        foreach (var skill in skills)
        {
            if (text.ToLower().Contains(skill))
                found.Add(skill);
            else
                missing.Add(skill);
        }

        int score = found.Count * 10;

        var result = new ResumeAnalysisResult
        {
            AtsScore = score,
            FoundSkills = found,
            MissingSkills = missing,
            Questions = new List<string>
            {
                "Explain OOP concepts",
                "What is REST API?",
                "Difference between SQL and NoSQL?"
            }
        };
        await _mongoService.SaveAsync(
            new ResumeRecord
            {
                AtsScore = score,
                FoundSkills = found,
                MissingSkills = missing,
                CreatedAt = DateTime.UtcNow
            }
        );

        return Ok(result);
    }
    private readonly MongoService _mongoService;

    public ResumeController(
        MongoService mongoService
    )
    {
        _mongoService = mongoService;
    }
    [HttpGet("history")]
    public async Task<IActionResult>
    History()
    {
        var results =
            await _mongoService.GetAllAsync();

        return Ok(results);
    }
}