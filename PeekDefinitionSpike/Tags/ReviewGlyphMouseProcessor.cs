﻿using System;
using System.Linq;
using System.Windows.Input;
using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Editor;
using Microsoft.VisualStudio.Text.Tagging;
using PeekDefinitionSpike.Peek;

namespace PeekDefinitionSpike.Tags
{
    class ReviewGlyphMouseProcessor : MouseProcessorBase
    {
        readonly IPeekBroker peekBroker;
        readonly ITextView textView;
        readonly IWpfTextViewMargin margin;
        readonly ITagAggregator<ReviewTag> tagAggregator;

        public ReviewGlyphMouseProcessor(
            IPeekBroker peekBroker,
            ITextView textView,
            IWpfTextViewMargin margin,
            ITagAggregator<ReviewTag> aggregator)
        {
            this.peekBroker = peekBroker;
            this.textView = textView;
            this.margin = margin;
            this.tagAggregator = aggregator;
        }

        public override void PreprocessMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            var y = e.GetPosition(margin.VisualElement).Y + textView.ViewportTop;
            var line = textView.TextViewLines.GetTextViewLineContainingYCoordinate(y);

            if (line != null)
            {
                var tag = tagAggregator.GetTags(line.ExtentAsMappingSpan).FirstOrDefault();

                if (tag != null)
                {
                    var snapshotPoint = tag.Span.Start.GetPoint(textView.TextBuffer, PositionAffinity.Predecessor);
                    var trackingPoint = textView.TextSnapshot.CreateTrackingPoint(snapshotPoint.Value.Position, PointTrackingMode.Positive);

                    var session = peekBroker.TriggerPeekSession(
                        textView,
                        trackingPoint,
                        ReviewPeekRelationship.Instance.Name);
                }
            }
        }
    }
}
