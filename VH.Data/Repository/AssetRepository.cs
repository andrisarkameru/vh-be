using System;
using System.Collections.Generic;
using System.Text;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class AssetRepository : EfCoreRepository<Asset, VHDbmodelContext>
    {
        public AssetRepository(VHDbmodelContext context) : base(context)
        {
        }
    }
}
