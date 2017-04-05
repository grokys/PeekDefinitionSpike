using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Language.Intellisense;

namespace PeekDefinitionSpike.Peek
{
    public class ReviewPeekableItemSource : IPeekableItemSource
    {
        public void AugmentPeekSession(IPeekSession session, IList<IPeekableItem> peekableItems)
        {
            peekableItems.Add(new ReviewPeekableItem("This looks a bit fishy!"));
        }

        public void Dispose()
        {
        }
    }
}
