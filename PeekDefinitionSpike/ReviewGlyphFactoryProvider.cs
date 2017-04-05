using System;
using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace PeekDefinitionSpike
{
    [Export(typeof(IGlyphFactoryProvider))]
    [Export(typeof(IGlyphMouseProcessorProvider))]
    [Name("ReviewGlyph")]
    [Order(Before = "VsTextMarker")]
    [ContentType("code")]
    [TagType(typeof(ReviewTag))]
    public class ReviewGlyphFactoryProvider : IGlyphFactoryProvider, IGlyphMouseProcessorProvider
    {
        readonly IPeekBroker peekBroker;
        readonly IViewTagAggregatorFactoryService aggregator;

        [ImportingConstructor]
        public ReviewGlyphFactoryProvider(IPeekBroker peekBroker, IViewTagAggregatorFactoryService aggregator)
        {
            this.peekBroker = peekBroker;
            this.aggregator = aggregator;
        }

        public IGlyphFactory GetGlyphFactory(IWpfTextView view, IWpfTextViewMargin margin)
        {
            return new ReviewGlyphFactory();
        }

        public IMouseProcessor GetAssociatedMouseProcessor(IWpfTextViewHost wpfTextViewHost, IWpfTextViewMargin margin)
        {
            return new ReviewGlyphMouseProcessor(
                peekBroker,
                wpfTextViewHost.TextView,
                margin,
                aggregator.CreateTagAggregator<ReviewTag>(wpfTextViewHost.TextView));
        }
    }
}
