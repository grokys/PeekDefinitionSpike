using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.TeamFoundation.Git.Extensibility;
using PeekDefinitionSpike.Models;

namespace PeekDefinitionSpike.Services
{
    [Export(typeof(IPullRequestReviewSession))]
    class PullRequestReviewSession : IPullRequestReviewSession
    {
        readonly IServiceProvider serviceProvider;

        [ImportingConstructor]
        public PullRequestReviewSession(
            [Import(typeof(SVsServiceProvider))] IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IEnumerable<PullRequestComment> GetCommentsForFile(string path)
        {
            const string FileWithComments = "PeekDefinitionSpike\\Services\\PullRequestReviewSession.cs";

            var relativePath = FullPathToRelativePath(path);

            if (relativePath != FileWithComments)
                return Enumerable.Empty<PullRequestComment>();

            return new[]
            {
                new PullRequestComment
                {
                    Path = FileWithComments,
                    Position = 39,
                    Body = "Wait, what's this?",
                    User = new User
                    {
                        Login = "grokys",
                        AvatarUrl = "https://avatars2.githubusercontent.com/u/1775141?v=3",
                    }
                },
                new PullRequestComment
                {
                    Path = FileWithComments,
                    Position = 39,
                    Body = "Things seem to be getting a little inceptiony.",
                    User = new User
                    {
                        Login = "jcansdale",
                        AvatarUrl = "https://avatars0.githubusercontent.com/u/11719160?v=3",
                    }
                },
            };
        }

        string FullPathToRelativePath(string path)
        {
            if (Path.IsPathRooted(path))
            {
                var gitExt = (IGitExt)serviceProvider.GetService(typeof(IGitExt));
                var repoRoot = gitExt?.ActiveRepositories.FirstOrDefault()?.RepositoryPath;

                if (repoRoot != null)
                {
                    if (path.StartsWith(repoRoot) && path.Length > repoRoot.Length + 1)
                    {
                        return path.Substring(repoRoot.Length + 1);
                    }
                }
            }

            return null;
        }
    }
}
