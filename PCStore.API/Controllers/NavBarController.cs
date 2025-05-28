using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCStore.API.Controllers.Base;
using PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements;
using PCStore.BLL.MediatR.OtherHandlers.GetSearchResults;
using PCStore.BLL.MediatR.ProductHandlers.GetMultipleProductsByIds;

namespace PCStore.API.Controllers
{
    public class NavBarController : BaseApiController
    {
        [HttpGet("{nameLike}")]
        public async Task<IActionResult> GetMultipleProductsByIds([FromRoute] string nameLike)
        {
            return HandleResult(await Mediator.Send(new GetSearchResultsQuery(nameLike)));
        }
    }
}
