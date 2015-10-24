using JetBrains.Application.BuildScript.Application.Zones;

namespace Resharper.Paket.CSharp
{
    [ZoneMarker]
    public class ZoneMarker : IRequire<IPaketZone>//, IRequire<ICodeEditingZone>
    {
    }
}