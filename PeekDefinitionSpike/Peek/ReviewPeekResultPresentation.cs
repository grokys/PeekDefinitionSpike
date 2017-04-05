﻿using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualStudio.Language.Intellisense;
using PeekDefinitionSpike.ViewModels;
using PeekDefinitionSpike.Views;

namespace PeekDefinitionSpike.Peek
{
    class ReviewPeekResultPresentation : IPeekResultPresentation
    {
        readonly ReviewPeekResult result;

        public bool IsDirty => false;
        public bool IsReadOnly => true;

        public ReviewPeekResultPresentation(ReviewPeekResult result)
        {
            this.result = result;
        }

        public double ZoomLevel
        {
            get { return 1.0; }
            set { }
        }

        public event EventHandler IsDirtyChanged;
        public event EventHandler IsReadOnlyChanged;
        public event EventHandler<RecreateContentEventArgs> RecreateContent;

        public bool CanSave(out string defaultPath)
        {
            defaultPath = null;
            return false;
        }

        public IPeekResultScrollState CaptureScrollState()
        {
            return null;
        }

        public void Close()
        {
        }

        public UIElement Create(IPeekSession session, IPeekResultScrollState scrollState)
        {
            var viewModel = new CommentBlockViewModel();
            var view = new CommentBlockView();

            foreach (var comment in result.Comments)
            {
                viewModel.Comments.Add(comment);
            }

            view.DataContext = viewModel;
            return view;
        }

        public void Dispose()
        {
        }

        public void ScrollIntoView(IPeekResultScrollState scrollState)
        {
        }

        public void SetKeyboardFocus()
        {
        }

        public bool TryOpen(IPeekResult otherResult) => false;

        public bool TryPrepareToClose() => true;

        public bool TrySave(bool saveAs) => true;
    }
}
