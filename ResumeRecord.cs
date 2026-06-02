using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InterviewSenseAPI.Models;

public class ResumeRecord
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public int AtsScore { get; set; }

    public List<string> FoundSkills { get; set; } = new();

    public List<string> MissingSkills { get; set; } = new();

    public DateTime CreatedAt { get; set; }
}