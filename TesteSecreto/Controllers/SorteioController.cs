using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Aplication;
using Domain.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace TesteSecreto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteioController : ControllerBase
    {
        private IFamiliaService _familiaService;
        private IMemoryCache _memoryCache;
        public SorteioController(IFamiliaService familiaService, IMemoryCache memoryCache)
        {
            _familiaService = familiaService;
            _memoryCache = memoryCache;
        }


        public List<FamiliaDto> Sorteio()
        {
            _ = new List<FamiliaDto>();
            if (!_memoryCache.TryGetValue("sorteio", out List<FamiliaDto> familias))
            {
                familias = _familiaService.SortearFamilia();
                MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions();
                cacheOptions.SetPriority(CacheItemPriority.High);
                cacheOptions.AbsoluteExpiration = DateTime.Now.AddMinutes(10);
                _memoryCache.Set("sorteio", familias, cacheOptions);
            }

            return familias;
        }
    }
}