using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VH.Core.Transport;
using VH.Data.Repository;
using VH.Services.Interfaces;

namespace VH.Services.Services
{
    public class AssetService : IAssetService
    {
        private readonly AssetRepository _repo;
        private readonly IMapper _mapper;

        public AssetService(AssetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AssetDTO>> ListAssets()
        {
            var assets = await _repo.GetAll();
            return assets.Select(x => _mapper.Map<AssetDTO>(x));
        }
    }
}
