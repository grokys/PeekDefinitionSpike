using System;
using Microsoft.VisualStudio.Language.Intellisense;

namespace PeekDefinitionSpike
{
    class ReviewPeekRelationship : IPeekRelationship
    {
        static ReviewPeekRelationship instance;

        private ReviewPeekRelationship()
        {
        }

        public static ReviewPeekRelationship Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ReviewPeekRelationship();
                }

                return instance;
            }
        }

        public string DisplayName => "GitHub Code Review";
        public string Name => "GitHubCodeReview";
    }
}
