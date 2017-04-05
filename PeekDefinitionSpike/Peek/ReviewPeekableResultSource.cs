using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;

namespace PeekDefinitionSpike.Peek
{
    class ReviewPeekableResultSource : IPeekResultSource
    {
        public void FindResults(string relationshipName, IPeekResultCollection resultCollection, CancellationToken cancellationToken, IFindPeekResultsCallback callback)
        {
            resultCollection.Add(new ReviewPeekResult());
        }
    }
}
