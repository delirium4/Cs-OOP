namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class Message
{
    public Message(ImportanceLevel importanceLevel, string? title, string? body)
    {
        ImportanceLevel = importanceLevel;
        Title = title;
        Body = body;
    }

    public string? Title { get; private set; }
    public ImportanceLevel ImportanceLevel { get; private set; }
    public string? Body { get; private set; }
}