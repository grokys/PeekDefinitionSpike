using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using PeekDefinitionSpike.Services;

namespace PeekDefinitionSpike.Tags
{
    class ReviewTagger : ITagger<ReviewTag>
    {
        readonly ITextBuffer buffer;
        readonly IPullRequestReviewSession session;

        public ReviewTagger(ITextBuffer buffer, IPullRequestReviewSession session)
        {
            this.buffer = buffer;
            this.session = session;
        }

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public IEnumerable<ITagSpan<ReviewTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            var document = buffer.Properties.GetProperty<ITextDocument>(typeof(ITextDocument));
            var comments = session.GetCommentsForFile(document.FilePath);

            foreach (var span in spans)
            {
                // Line numbers here are 0-based but PullRequestComment.Position is 1-based.
                var startLine = span.Start.GetContainingLine().LineNumber + 1;
                var endLine = span.End.GetContainingLine().LineNumber + 1;

                var spanComments = comments.Where(x => x.Position >= startLine && x.Position <= endLine);

                foreach (var comment in spanComments)
                {
                    var line = span.Snapshot.GetLineFromLineNumber(comment.Position - 1);
                    yield return new TagSpan<ReviewTag>(
                        new SnapshotSpan(line.Start, line.End),
                        new ReviewTag(comment));
                }
            }
        }
    }
}
