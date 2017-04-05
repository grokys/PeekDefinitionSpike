using System;

namespace PeekDefinitionSpike.Models
{
    class PullRequestComment
    {
        public string Path { get; set; }
        public int Position { get; set; }
        public User User { get; set; }
        public string Body { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
