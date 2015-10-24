using JetBrains.Annotations;
using JetBrains.ProjectModel.Model2.Assemblies.Interfaces;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Modules;
using JetBrains.Util;
using System.Collections.Generic;
using System.Linq;

namespace Resharper.Paket.CSharp
{
    [PsiSharedComponent]
    public class PaketModuleReferencerImpl
    {
        #region Private stuff
        private static bool IsProjectModule(IPsiModule module)
        {
            return module is IProjectPsiModule;
        }
        private static bool IsAssemblyModule(IPsiModule module)
        {
            return module is IAssemblyPsiModule;
        }
        private static IList<FileSystemPath> GetAllAssemblyLocations(IPsiModule psiModule)
        {
            var projectModelAssembly = psiModule.ContainingProjectModule as IAssembly;
            if (projectModelAssembly == null)
                return EmptyList<FileSystemPath>.InstanceList;

            // ReSharper maintains a list of unique assemblies, and each assembly keeps a track of
            // all of the file copies of itself that the solution knows about. This list of file
            // locations includes sources for references (including NuGet packages), but can also
            // include outputs, e.g. if CopyLocal is set to True. The IAssemblyPsiModule.Assembly.Location
            // returns back the file location of the first copy of the assembly, but the order of
            // the list is undefined - it is entirely possible to get back a file location in a bin\Debug
            // folder. This doesn't help us when trying to add NuGet references - we need to look
            // at all of the locations to try and find the NuGet package location. So we use the
            // ProjectModel instead of the PSI, and get all file locations of the IAssembly
            return projectModelAssembly.GetFiles().Select(f => f.Location).ToList();
        }
        #endregion
        internal bool CanReferenceModule([NotNull] IPsiModule module, [CanBeNull] IPsiModule moduleToReference)
        {
            if (!IsProjectModule(module) || !IsAssemblyModule(moduleToReference))
                return false;
            return true;
            /*
            //Logger.LogMessage(LoggingLevel.VERBOSE, "[PAKET PLUGIN] Checking if module '{0}' is a paket package", moduleToReference.DisplayName);
            var assemblyLocations = GetAllAssemblyLocations(moduleToReference);
            var canReference = module.GetSolution().GetComponent<PaketApi>().AreAnyAssemblyFilesPaketPackages(assemblyLocations);
            //Logger.LogMessage(LoggingLevel.VERBOSE, "[PAKET PLUGIN] Module '{0}' is {1}a paket package", moduleToReference.DisplayName, canReference ? string.Empty : "NOT ");
            return canReference;
            */
        }
        internal bool ReferenceModule(IPsiModule module, IPsiModule moduleToReference)
        {
            return false;
            //throw new NotImplementedException();
        }
    }
}
