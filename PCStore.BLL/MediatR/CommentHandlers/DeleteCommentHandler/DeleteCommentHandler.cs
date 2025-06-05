using FluentResults;
using MediatR;
using PCStore.BLL.APIData.Contracts;
using PCStore.BLL.Exceptions;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.BLL.Specifications.BrandSpecifications;
using PCStore.BLL.Specifications.CategorySpecifications;
using PCStore.BLL.Specifications.CommentSpecifications;
using PCStore.BLL.Specifications.ProductSpecifications;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.DTOs.BrandDTOs;
using PCStore.Data.DTOs.CategoryDTOs;
using PCStore.Data.DTOs.CommentDTOs;
using PCStore.Data.DTOs.OtherDTOs;
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using PCStore.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.CommentHandlers.DeleteCommentHandler
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Result<object>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelAPIService modelAPIService;
        private readonly ILoggerService _logger;

        public DeleteCommentHandler(IUnitOfWork unitOfWork, ILoggerService logger, IModelAPIService modelAPIService)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
            this.modelAPIService = modelAPIService;
        }

        public async Task<Result<object>> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var entityFromDB = await unitOfWork.CommentRepository.GetFirstOrDefaultAsync(new CommentWithCommentsSpecification(request.commentId));

            if (entityFromDB is null)
            {
                string errorMsg = $"Comment with id: {request.commentId} does not exist!";
                _logger.LogError(request, errorMsg);
                throw new EntityNotFoundException();
            }

            if (entityFromDB.UserId != request.userId)
            {
                string errorMsg = $"Access forbiden!";
                _logger.LogError(request, errorMsg);
                throw new ForbiddenAccessException();
            };

            unitOfWork.CommentRepository.Delete(entityFromDB);

            var isSuccessResult = await unitOfWork.SaveChangesAsync() > 0;

            if (!isSuccessResult)
            {
                const string errorMsg = "Cannot save changes in the database after entity delete!";
                _logger.LogError(request, errorMsg);
                throw new InternalServerErrorException();
            }

            return Result.Ok(new { result =  true });
        }
    }
}
