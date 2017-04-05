using System;
using System.Collections.ObjectModel;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.ViewModels
{
    class CommentBlockViewModel
    {
        public CommentBlockViewModel()
        {
            Comments = new ObservableCollection<PullRequestComment>();
        }

        public ObservableCollection<PullRequestComment> Comments { get; }
    }
}
