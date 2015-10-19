using JetBrains.ReSharper.Feature.Services.QuickFixes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using JetBrains.ReSharper.Feature.Services.Intentions;
using JetBrains.Util;
using JetBrains.ReSharper.Intentions.QuickFixes;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.TextControl;
using JetBrains.ReSharper.Psi.Resolve;
using JetBrains.Application;
using JetBrains.DataFlow;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Intentions.CSharp.QuickFixes;
using JetBrains.Application.Environment;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Feature.Services;
using JetBrains.ReSharper.Feature.Services.Daemon;

namespace Resharper.Paket.CSharp
{
    /*[ZoneDefinition]
    public interface IPaketZone : IZone, IRequire<ILanguageCSharpZone>
    {
    }*/
    [ZoneMarker]
    public class ZoneMarker : IRequire<ICodeEditingZone>, IRequire<ILanguageCSharpZone>
    {
    }
    /*[ZoneActivator]
    class PaketZoneActivator : IActivate<ILanguageCSharpZone>
    {
        public bool ActivatorEnabled()
        {
            return true;
        }
    }*/
    [ShellComponent]
    class PaketRegistrar
    {
        public PaketRegistrar(Lifetime lifetime, IQuickFixes table)
        {
            table.RegisterQuickFix<NotResolvedError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeOrNamespaceExpectedError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeOrNamespaceExpectedNoCandidateError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeExpectedError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<AttributeNameExpectedError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeInExtendsListExpectedError>(lifetime, h => new PaketFix(CSharpImportTypeUtil.GetReferenceByUsage(h.TypeUsage)), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<InterfaceInExtendsListExpectedError>(lifetime, h => new PaketFix(CSharpImportTypeUtil.GetReferenceByUsage(h.TypeUsage)), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<ExplicitQualifierIsNotInterfaceError>(lifetime, h => new PaketFix(h.Qualifier.Qualifier.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<NotTypeOrInterfaceInTypeParameterConstraintError>(lifetime, h => new PaketFix(CSharpImportTypeUtil.GetReferenceByUsage(h.TypeUsageNode)), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<NoTypeParametersInCandidateError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeParametersNumberMismatchError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeParametersNumberMismatchMultipleCandidatesError>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<NotResolvedInDocCommentWarning>(lifetime, h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
        }
    }
    class PaketFixItem : BulbActionBase
    {
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            return null;
        }
        public override string Text
        {
            get
            {
                return "Add 'Hardcoded' Paket dependency and use 'Hardcoded'";
            }
        }
    }
    class PaketFix : ImportTypeQuickFixBase
    {
        public PaketFix(IReference reference)
            : base(reference)
        {
        }
        public override IBulbAction[] Items
        {
            get
            {
                var list = new List<IBulbAction>();
                list.Add(new PaketFixItem());
                return list.ToArray();
            }
        }
    }
}
