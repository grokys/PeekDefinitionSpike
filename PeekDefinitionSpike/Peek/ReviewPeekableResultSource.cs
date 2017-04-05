using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.Peek
{
    class ReviewPeekableResultSource : IPeekResultSource
    {
        readonly IList<PullRequestComment> comments;

        public ReviewPeekableResultSource(IList<PullRequestComment> comments)
        {
            this.comments = comments;
        }

        public void FindResults(string relationshipName, IPeekResultCollection resultCollection, CancellationToken cancellationToken, IFindPeekResultsCallback callback)
        {
            resultCollection.Add(new ReviewPeekResult(comments));
        }
    }
}
