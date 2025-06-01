using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCStore.API.Controllers.Base;
using PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements;
using PCStore.BLL.MediatR.OtherHandlers.GetCatalogSearchResult;
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;

namespace PCStore.API.Controllers
{
    public class CatalogController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> GetCatalogSearchResult([FromBody] CatalogSearchRequestDTO catalogSearchRequestDTO)
        {
            return HandleResult(await Mediator.Send(new GetCatalogSearchResultQuery(catalogSearchRequestDTO)));
        }
    }
}
