using FluentResults;
using MediatR;
using PCStore.Data.DTOs.CommentDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.CommentHandlers.GetCommentReviewsHandler
{
    public record GetCommentReviewsQuery : IRequest<Result<IEnumerable<CommentReviewDTO>>>
    {
    }
}
