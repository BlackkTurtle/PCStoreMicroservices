using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCStore.BLL.Services.Contracts;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Responses;

namespace Cinema.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsService productsService { get; }

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        [HttpGet("New3Products")]
        [ProducesResponseType(typeof(List<GetProductWithRatingDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<GetProductWithRatingDTO>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<GetProductWithRatingDTO>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetNew2Products()
        {
            var response = await productsService.GetProductWithRatingDTOAsync();

            return response.StatusCode switch
            {
                PCStore.Data.Responses.Enums.StatusCode.Ok => Ok(response.Data),
                PCStore.Data.Responses.Enums.StatusCode.NotFound => NotFound(response.Data),
                PCStore.Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response.Data),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [HttpGet("MultipleByIds")]
        [ProducesResponseType(typeof(List<GetProductWithRatingDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(List<GetProductWithRatingDTO>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(List<GetProductWithRatingDTO>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetMultipleProductsByIds([FromQuery] int[] ints)
        {
            if (ints == null || ints.Length == 0)
            {
                return BadRequest("No IDs provided.");
            }
            var response = await productsService.GetMultipleProductWithRatingDTOByIdAsync(ints);

            return response.StatusCode switch
            {
                PCStore.Data.Responses.Enums.StatusCode.Ok => Ok(response.Data),
                PCStore.Data.Responses.Enums.StatusCode.NotFound => NotFound(response.Data),
                PCStore.Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response.Data),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        /*[HttpGet]
        [Route("[action]/{id}", Name = "GetActorById")]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(BaseResponse<GetActorDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetActorById(Guid id)
        {
            var response = await Service.GetByIdAsync(id);

            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [Authorize(Policy = "OnlyAdmin")]
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<AddActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<AddActorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<AddActorDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> PostActor(AddActorDto actor)
        {
            var response = await Service.InsertAsync(actor);

            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [Authorize(Policy = "OnlyAdmin")]
        [HttpPut]
        [ProducesResponseType(typeof(BaseResponse<UpdateActorDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<UpdateActorDto>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<UpdateActorDto>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> UpdateActor(UpdateActorDto actor)
        {
            var response = await Service.UpdateAsync(actor);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        [Authorize(Policy = "OnlyAdmin")]
        [HttpDelete]
        [Route("[action]/{id}", Name = "DeleteActorById")]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> DeleteActor(Guid id)
        {
            var response = await Service.DeleteAsync(id);
            
            return response.StatusCode switch
            {
                Data.Responses.Enums.StatusCode.Ok => Ok(response),
                Data.Responses.Enums.StatusCode.NotFound => NotFound(response),
                Data.Responses.Enums.StatusCode.BadRequest => BadRequest(response),
                Data.Responses.Enums.StatusCode.InternalServerError => StatusCode(500, response),
                _ => throw new ArgumentOutOfRangeException()
            };
        }*/
    }
}