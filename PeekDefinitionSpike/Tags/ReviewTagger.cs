using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;

namespace PeekDefinitionSpike.Tags
{
    public class ReviewTagger : ITagger<ReviewTag>
    {
        readonly ITextBuffer buffer;

        public ReviewTagger(ITextBuffer buffer)
        {
            this.buffer = buffer;
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public IEnumerable<ITagSpan<ReviewTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            foreach (var span in spans)
            {
                if (span.Start.GetContainingLine().LineNumber <= 10 &&
                    span.End.GetContainingLine().LineNumber >= 10)
                {
                    var line = span.Snapshot.GetLineFromLineNumber(10);
                    yield return new TagSpan<ReviewTag>(new SnapshotSpan(line.Start, line.End), new ReviewTag());
                }
            }
        }
    }
}
