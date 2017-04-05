using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Language.Intellisense;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.Peek
{
    class ReviewPeekResult : IPeekResult
    {
        public ReviewPeekResult(IList<PullRequestComment> comments)
        {
            this.Comments = comments;
        }

        public bool CanNavigateTo => true;
        public IList<PullRequestComment> Comments { get; }

        public IPeekResultDisplayInfo DisplayInfo { get; }
            = new PeekResultDisplayInfo("Review", null, "GitHub Review", "GitHub Review");

        public Action<IPeekResult, object, object> PostNavigationCallback => null;

        public event EventHandler Disposed;

        public void Dispose()
        {
        }

        public void NavigateTo(object data)
        {
        }
    }
}
