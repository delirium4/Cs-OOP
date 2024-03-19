using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Message;

public class MessageBuilder
{
    private string? _title;
    private ImportanceLevel? _importanceLevel;
    private string? _body;
    public MessageBuilder WithTitle(string title)
    {
        _title = title;
        return this;
    }

    public MessageBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public MessageBuilder WithImportanceLevel(ImportanceLevel importanceLevel)
    {
        _importanceLevel = importanceLevel;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _importanceLevel ?? throw new ArgumentNullException(nameof(_importanceLevel)),
            _title,
            _body ?? throw new ArgumentNullException(nameof(_body)));
    }
}