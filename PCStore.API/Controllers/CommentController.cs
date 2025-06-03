using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PCStore.API.Controllers.Base;
using PCStore.BLL.MediatR.CommentHandlers.CreateCommentHandler;
using PCStore.BLL.MediatR.CommentHandlers.CreateCommentResponseHandler;
using PCStore.BLL.MediatR.CommentHandlers.CreateReviewHandler;
using PCStore.BLL.MediatR.CommentHandlers.DeleteCommentHandler;
using PCStore.BLL.MediatR.CommentHandlers.UpdateCommentHandler;
using PCStore.BLL.MediatR.OtherHandlers.GetSearchResults;
using PCStore.Data.DTOs.CommentDTOs;
using System.Security.Claims;

namespace PCStore.API.Controllers
{
    public class CommentController : BaseApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewDTO createReviewDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var fullName = User.FindFirst("firstName")?.Value +" "+ User.FindFirst("lastName")?.Value;

            return HandleResult(await Mediator.Send(new CreateReviewCommand(createReviewDTO,userId,fullName)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CreateCommentDTO createCommentDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var fullName = User.FindFirst("firstName")?.Value + " " + User.FindFirst("lastName")?.Value;

            return HandleResult(await Mediator.Send(new CreateCommentCommand(createCommentDTO, userId, fullName)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCommentResponse([FromBody] CreateCommentResponseDTO createCommentDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var fullName = User.FindFirst("firstName")?.Value + " " + User.FindFirst("lastName")?.Value;

            return HandleResult(await Mediator.Send(new CreateCommentResponseCommand(createCommentDTO, userId, fullName)));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody] UpdateCommentDTO updateCommentDTO)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return HandleResult(await Mediator.Send(new UpdateCommentCommand(updateCommentDTO, userId)));
        }

        [Authorize]
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return HandleResult(await Mediator.Send(new DeleteCommentCommand(id, userId)));
        }
    }
}
