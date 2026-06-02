namespace InterviewSenseAPI.Models;

public class ResumeAnalysisResult
{
    public int AtsScore { get; set; }

    public List<string> FoundSkills { get; set; } = new();

    public List<string> MissingSkills { get; set; } = new();

    public List<string> Questions { get; set; } = new();
}