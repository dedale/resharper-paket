using JetBrains.Application.Environment;

namespace Resharper.Paket.CSharp
{
    [ZoneActivator]
    class PaketZoneActivator : IActivate<IPaketZone>
    {
        public bool ActivatorEnabled()
        {
            return true;
        }
    }
}