using FluentResults;
using MediatR;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.BLL.Specifications.CommentSpecifications;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.DTOs.CommentDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.CommentHandlers.GetCommentReviewsHandler
{
    public class GetCommentReviewHandler : IRequestHandler<GetCommentReviewsQuery, Result<IEnumerable<CommentReviewDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService _logger;

        public GetCommentReviewHandler(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<CommentReviewDTO>>> Handle(GetCommentReviewsQuery request, CancellationToken cancellationToken)
        {
            var entitiesFromDB = await unitOfWork.CommentRepository
                .GetAllAsync(new CommentReviewDTOSpecification());

            if (entitiesFromDB is null)
            {
                string errorMsg = "Cannot find entities!";
                _logger.LogError(request, errorMsg);
                return new Error(errorMsg);
            }

            return Result.Ok(entitiesFromDB);
        }
    }
}
