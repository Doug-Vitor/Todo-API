using System;

namespace TodoApi.Domain.Entities
{
    public class Todo : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsFinished { get; set; }

        public Todo(string title, string description, bool isFinished)
        {
            Title = title;
            Description = description;
            IsFinished = isFinished;
        }
    }
}
