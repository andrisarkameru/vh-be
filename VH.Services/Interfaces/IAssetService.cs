using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;

namespace VH.Services.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<AssetDTO>> ListAssets();                
    }
}
