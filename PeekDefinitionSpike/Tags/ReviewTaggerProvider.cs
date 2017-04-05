using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace PeekDefinitionSpike.Tags
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(ReviewTag))]
    public class ReviewTaggerProvider : ITaggerProvider
    {
        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            return new ReviewTagger(buffer) as ITagger<T>;
        }
    }
}
