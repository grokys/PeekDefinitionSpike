using System.Collections.Generic;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.Services
{
    interface IPullRequestReviewSession
    {
        IEnumerable<PullRequestComment> GetCommentsForFile(string path);
    }
}