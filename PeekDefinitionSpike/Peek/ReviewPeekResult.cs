using System;
using Microsoft.VisualStudio.Language.Intellisense;

namespace PeekDefinitionSpike.Peek
{
    class ReviewPeekResult : IPeekResult
    {
        public bool CanNavigateTo => true;

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
