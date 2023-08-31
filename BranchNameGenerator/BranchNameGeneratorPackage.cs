using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace BranchNameGenerator
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [Guid("6b972396-d90d-4234-a06a-8c5b59141e93")]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideToolWindow(typeof(BranchCreatorWindow))]
    public sealed class BranchNameGeneratorPackage : AsyncPackage
    {
        #region Package Members

        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
            await BranchCreatorWindowCommand.InitializeAsync(this);
        }

        #endregion
    }
}
