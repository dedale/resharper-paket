using JetBrains.ReSharper.Psi.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using JetBrains.Metadata.Reader.API;
using JetBrains.ReSharper.Psi;
using JetBrains.ProjectModel.Model2.Assemblies.Interfaces;

namespace Resharper.Paket.CSharp
{
    public class PaketModuleReferencer : IModuleReferencer
    {
        #region Fields
        [NotNull]
        private readonly PaketModuleReferencerImpl moduleReferencer;
        #endregion
        public PaketModuleReferencer([NotNull] PaketModuleReferencerImpl moduleReferencer)
        {
            this.moduleReferencer = moduleReferencer;
        }
        public bool CanReferenceModule([NotNull] IPsiModule module, [CanBeNull] IPsiModule moduleToReference, IModuleReferenceResolveContext context)
        {
            return moduleReferencer.CanReferenceModule(module, moduleToReference);
        }
        public bool ReferenceModule([NotNull] IPsiModule module, [NotNull] IPsiModule moduleToReference)
        {
            return moduleReferencer.ReferenceModule(module, moduleToReference);
        }
        public bool ReferenceModuleWithType(IPsiModule module, ITypeElement typeToReference, IModuleReferenceResolveContext resolveContext)
        {
            return ReferenceModule(module, typeToReference.Module);
        }
    }
}
