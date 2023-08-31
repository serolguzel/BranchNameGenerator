using Microsoft.VisualStudio.Shell;
using System;
using System.Runtime.InteropServices;

namespace BranchNameGenerator
{
    [Guid("60987478-921c-451c-9850-f6ac9775d057")]
    public class BranchCreatorWindow : ToolWindowPane
    {
        public BranchCreatorWindow() : base(null)
        {
            this.Caption = "Branch Generator";
            this.Content = new BranchCreatorWindowControl();
        }
    }
}
