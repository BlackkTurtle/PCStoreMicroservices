using FluentResults;
using MediatR;
using PCStore.Data.DTOs.CommentDTOs;
using PCStore.Data.DTOs.OtherDTOs;
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.CommentHandlers.CreateCommentResponseHandler
{
    public record CreateCommentResponseCommand(CreateCommentResponseDTO createCommentDto, string userId, string fullName) : IRequest<Result<GetCommentDTO>>
    {
    }
}
