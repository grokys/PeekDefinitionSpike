using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Language.Intellisense;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.Peek
{
    class ReviewPeekableItem : IPeekableItem
    {
        readonly IList<PullRequestComment> comments;

        public ReviewPeekableItem(IList<PullRequestComment> comments)
        {
            this.comments = comments;
        }

        public string DisplayName => "GitHub Code Review";

        public IEnumerable<IPeekRelationship> Relationships => new[] { ReviewPeekRelationship.Instance };

        public IPeekResultSource GetOrCreateResultSource(string relationshipName)
        {
            return new ReviewPeekableResultSource(comments);
        }
    }
}
