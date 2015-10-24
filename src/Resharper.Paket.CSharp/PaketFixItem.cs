using System;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.TextControl;

namespace Resharper.Paket.CSharp
{
    class PaketFixItem : BulbActionBase
    {
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            return null;
        }
        public override string Text => "Add 'Hardcoded' Paket dependency and use 'Hardcoded'";
    }
}