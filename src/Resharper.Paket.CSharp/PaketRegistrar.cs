using JetBrains.Application;
using JetBrains.DataFlow;
using JetBrains.ReSharper.Daemon.CSharp.Errors;
using JetBrains.ReSharper.Feature.Services.QuickFixes;
using JetBrains.ReSharper.Intentions.CSharp.QuickFixes;
using JetBrains.Util;

namespace Resharper.Paket.CSharp
{
    [ShellComponent]
    class PaketRegistrar
    {
        public PaketRegistrar(Lifetime lifetime, IQuickFixes table)
        {
            table.RegisterQuickFix<NotResolvedError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeOrNamespaceExpectedError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeOrNamespaceExpectedNoCandidateError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeExpectedError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<AttributeNameExpectedError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeInExtendsListExpectedError>(lifetime,
                h => new PaketFix(CSharpImportTypeUtil.GetReferenceByUsage(h.TypeUsage)), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<InterfaceInExtendsListExpectedError>(lifetime,
                h => new PaketFix(CSharpImportTypeUtil.GetReferenceByUsage(h.TypeUsage)), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<ExplicitQualifierIsNotInterfaceError>(lifetime,
                h => new PaketFix(h.Qualifier.Qualifier.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<NotTypeOrInterfaceInTypeParameterConstraintError>(lifetime,
                h => new PaketFix(CSharpImportTypeUtil.GetReferenceByUsage(h.TypeUsageNode)), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<NoTypeParametersInCandidateError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeParametersNumberMismatchError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<TypeParametersNumberMismatchMultipleCandidatesError>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
            table.RegisterQuickFix<NotResolvedInDocCommentWarning>(lifetime,
                h => new PaketFix(h.Reference), typeof(PaketFix), null, (BeforeOrAfter)1);
        }
    }
}