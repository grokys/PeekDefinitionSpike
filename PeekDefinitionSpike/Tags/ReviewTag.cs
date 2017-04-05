using System;
using Microsoft.VisualStudio.Text.Editor;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.Tags
{
    class ReviewTag : IGlyphTag
    {
        public ReviewTag(PullRequestComment comment)
        {
            Comment = comment;
        }

        public PullRequestComment Comment { get; }
    }
}
