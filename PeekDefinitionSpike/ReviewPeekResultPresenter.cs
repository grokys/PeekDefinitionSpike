using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Utilities;

namespace PeekDefinitionSpike
{
    [Export(typeof(IPeekResultPresenter))]
    [Name("GitHub Review Peek Presenter")]
    class ReviewPeekResultPresenter : IPeekResultPresenter
    {
        public IPeekResultPresentation TryCreatePeekResultPresentation(IPeekResult result)
        {
            var review = result as ReviewPeekResult;

            if (review != null)
            {
                return new ReviewPeekResultPresentation(review);
            }

            return null;
        }
    }
}
