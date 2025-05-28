using Microsoft.AspNetCore.Mvc;
using PCStore.API.Controllers.Base;
using PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements;

namespace PCStore.API.Controllers
{
    public class AdvertisementController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrderedAdvertisements()
        {
            return HandleResult(await Mediator.Send(new GetOrderedAdvertisementsQuery()));
        }
    }
}
