# resharper-paket
Plugin for ReSharper to support Paket references correctly.

I am currently unable to get my Resharper plugin work with version 9.2 (`Resharper Ultimate 2015.2`) ...


Following 
[Deployment](https://www.jetbrains.com/resharper/devguide/Extensions/Packaging.html) guide:

* Plugin assemblies are located in `DotFiles` folder.
* Currently, my code doesn't require extra nuget dependencies.
* Nuget package has only one dependency to `Wave 3.0`.
* My package has a "." separator: `Resharper.Paket`.

I have defined the following classes:

    [ZoneMarker]
    public class ZoneMarker : IRequire<IPaketZone>
    {
    }
    [ZoneDefinition]
    public interface IPaketZone : IZone, IRequire<ILanguageCSharpZone>
    {
    }
    [ZoneActivator]
    class PaketZoneActivator : IActivate<IPaketZone>
    {
        public bool ActivatorEnabled()
        {
            return true;
        }
    }
    [ShellComponent]
    class PaketRegistrar
    {
        public PaketRegistrar(Lifetime lifetime, IQuickFixes table)
        {
            // dotPeeked from Jetbrains.Resharper.SDK
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
                var list = new List<IBulbAction> { new PaketFixItem() };
                return list.ToArray();
            }
        }
    }
    class PaketFixItem : BulbActionBase
    {
        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            return null;
        }
        public override string Text => "Add '***' Paket dependency and use '***'";
    }

