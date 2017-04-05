using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Utilities;

namespace PeekDefinitionSpike.Peek
{
    [Export(typeof(IPeekableItemSourceProvider))]
    [ContentType("text")]
    [Name("GitHub Peekable Review Provider")]
    public class ReviewPeekableItemSourceProvider : IPeekableItemSourceProvider
    {
        public IPeekableItemSource TryCreatePeekableItemSource(ITextBuffer textBuffer)
        {
            return new ReviewPeekableItemSource();
        }
    }
}
