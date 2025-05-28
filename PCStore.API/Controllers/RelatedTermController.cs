using Microsoft.AspNetCore.Mvc;
using PCStore.API.Controllers.Base;
using PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements;

namespace PCStore.API.Controllers
{
    public class RelatedTermController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrderedAdvertisements()
        {
            return HandleResult(await Mediator.Send(new GetOrderedAdvertisementsQuery()));
        }

        /*[HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return HandleResult(await Mediator.Send(new GetRelatedTermByIdQuery(id)));
        }

        [HttpGet("{termid:int}")]
        public async Task<IActionResult> GetByTermId([FromRoute] int termid)
        {
            return HandleResult(await Mediator.Send(new GetAllRelatedTermsByTermIdQuery(termid)));
        }

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
