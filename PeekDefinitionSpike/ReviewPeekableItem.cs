using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;

namespace PeekDefinitionSpike
{
    public class ReviewPeekableItem : IPeekableItem
    {
        public ReviewPeekableItem(string text)
        {
        }

        public string DisplayName => "GitHub Code Review";

        public IEnumerable<IPeekRelationship> Relationships => new[] { ReviewPeekRelationship.Instance };

        public IPeekResultSource GetOrCreateResultSource(string relationshipName)
        {
            return new ReviewPeekableResultSource();
        }
    }
}
