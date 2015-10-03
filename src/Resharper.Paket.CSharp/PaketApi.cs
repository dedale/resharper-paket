using JetBrains.ProjectModel;
using JetBrains.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    Paket available: dependencies.locate returns something

    Paket.Constants
        DependenciesFileName: paket.dependencies
        PackagesFolderName: packages

    FileSystemWatcher on paket.dependencies?
    Update cache with list of packages (with list of dlls)
*/

namespace Resharper.Paket.CSharp
{
    [SolutionComponent]
    public class PaketApi
    {
        private bool IsPaketAvailable
        {
            get { return false; }
        }
        private bool TryGetPackageFromAssemblyLocations(IList<FileSystemPath> assemblyLocations, out FileSystemPath installedLocation)
        {
            installedLocation = null;
            return false;
        }
        public bool AreAnyAssemblyFilesPaketPackages(IList<FileSystemPath> fileLocations)
        {
            if (!IsPaketAvailable || fileLocations.Count == 0)
                return false;
            FileSystemPath installedLocation;
            var hasPackageAssembly = TryGetPackageFromAssemblyLocations(fileLocations, out installedLocation);
            if (!hasPackageAssembly)
            {}//LogNoPackageFound(fileLocations);
            return hasPackageAssembly;
        }
    }
}
