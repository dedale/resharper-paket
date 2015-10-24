using JetBrains.Application.BuildScript.Application.Zones;
using JetBrains.ReSharper.Psi.CSharp;

namespace Resharper.Paket.CSharp
{
    [ZoneDefinition]
    public interface IPaketZone : IZone, IRequire<ILanguageCSharpZone>
    {
    }
}