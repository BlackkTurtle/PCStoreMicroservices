using MediatR;
using Microsoft.AspNetCore.Mvc;
using PCStore.API.Controllers.Base;
using PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements;
using PCStore.BLL.MediatR.ProductHandlers.GetLastNProductsWithImage;
using PCStore.BLL.MediatR.ProductHandlers.GetMultipleProductsByIds;

namespace PCStore.API.Controllers
{
    public class ProductController : BaseApiController
    {
        [HttpGet("{n:int}")]
        public async Task<IActionResult> GetLastNProductswithImage([FromRoute] int n)
        {
            return HandleResult(await Mediator.Send(new GetLastNProductsWithImageQuery(n)));
        }

        [HttpGet("{intsstr}")]
        public async Task<IActionResult> GetMultipleProductsByIds([FromRoute] string intsstr)
        {
            var ints = intsstr.Split(',').Select(int.Parse).ToArray();
            return HandleResult(await Mediator.Send(new GetMultipleProductsByIdsQuery(ints)));
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RelatedTermDto relatedTerm)
        {
            return HandleResult(await Mediator.Send(new CreateRelatedTermCommand(relatedTerm)));
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] RelatedTermDto relatedTerm)
        {
            return HandleResult(await Mediator.Send(new UpdateRelatedTermCommand(relatedTerm)));
        }

        [HttpDelete("{word}/{termId:int}")]
        public async Task<IActionResult> Delete([FromRoute] string word, [FromRoute] int termId)
        {
            return HandleResult(await Mediator.Send(new DeleteRelatedTermCommand(word, termId)));
        }*/
    }
}
