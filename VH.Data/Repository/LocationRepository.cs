using System;
using System.Collections.Generic;
using System.Text;
using VH.Data.EFCore;

namespace VH.Data.Repository
{
    public class LocationRepository : EfCoreRepository<Location, VHDbmodelContext>
    {
        public LocationRepository(VHDbmodelContext context) : base(context)
        {
        }
    }
}
