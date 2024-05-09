﻿using shelter.Domain.Article.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Article;

public sealed class Article : AggregateRoot<ArticleId>
{
    public string Heading { get; }
    public string Description { get; }
    public DateTime DateTime { get; }
    private Article(ArticleId id, string heading, string description, DateTime dateTime)
        : base(id)
    {
        Heading = heading;
        Description = description;
        DateTime = dateTime;
    }

    public static Article Create(string heading, string description)
    {
        return new(ArticleId.CreateUnique(), heading, description, DateTime.UtcNow);
    }
}
