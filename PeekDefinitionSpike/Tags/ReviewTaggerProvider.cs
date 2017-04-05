using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;
using PeekDefinitionSpike.Services;

namespace PeekDefinitionSpike.Tags
{
    [Export(typeof(ITaggerProvider))]
    [ContentType("code")]
    [TagType(typeof(ReviewTag))]
    class ReviewTaggerProvider : ITaggerProvider
    {
        readonly IPullRequestReviewSession session;

        [ImportingConstructor]
        public ReviewTaggerProvider(IPullRequestReviewSession session)
        {
            this.session = session;
        }

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            return new ReviewTagger(buffer, session) as ITagger<T>;
        }
    }
}
