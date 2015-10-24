using System.Collections.Generic;
using JetBrains.ReSharper.Intentions.QuickFixes;
using JetBrains.ReSharper.Feature.Services.Bulbs;
using JetBrains.ReSharper.Psi.Resolve;

namespace Resharper.Paket.CSharp
{
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
}
