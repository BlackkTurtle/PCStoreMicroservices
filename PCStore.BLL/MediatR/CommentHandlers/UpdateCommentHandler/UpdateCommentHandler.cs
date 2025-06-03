using FluentResults;
using MediatR;
using PCStore.BLL.APIData.Contracts;
using PCStore.BLL.Exceptions;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.BLL.Specifications.BrandSpecifications;
using PCStore.BLL.Specifications.CategorySpecifications;
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

namespace PCStore.BLL.MediatR.CommentHandlers.UpdateCommentHandler
{
    public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Result<GetCommentDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelAPIService modelAPIService;
        private readonly ILoggerService _logger;

        public UpdateCommentHandler(IUnitOfWork unitOfWork, ILoggerService logger, IModelAPIService modelAPIService)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
            this.modelAPIService = modelAPIService;
        }

        public async Task<Result<GetCommentDTO>> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var entityFromDB = await unitOfWork.CommentRepository.GetFirstOrDefaultAsync(request.updateCommentDTO.CommentId);

            if (entityFromDB is null)
            {
                string errorMsg = $"Comment with id: {request.updateCommentDTO.CommentId} does not exist!";
                _logger.LogError(request, errorMsg);
                throw new EntityNotFoundException();
            }

            if(entityFromDB.UserId != request.userId)
            {
                string errorMsg = $"Access forbiden!";
                _logger.LogError(request, errorMsg);
                throw new ForbiddenAccessException();
            };

            double modelResult = await modelAPIService.GetModelPrediction(request.updateCommentDTO.Content);

            if (modelResult >= 0.8)
            {
                string errorMsg = $"Comment was very abusive!";
                _logger.LogError(request, errorMsg);
                throw new CommentToxicException();
            }

            entityFromDB.DateModified = DateTime.Now;
            entityFromDB.Content = request.updateCommentDTO.Content;
            entityFromDB.CommentStatus = modelResult <= 0.1 ? CommentStatusEnum.Valid : CommentStatusEnum.Review;

            var isSuccessResult = await unitOfWork.SaveChangesAsync() > 0;

            if (!isSuccessResult)
            {
                const string errorMsg = "Cannot save changes in the database after entity update!";
                _logger.LogError(request, errorMsg);
                throw new InternalServerErrorException();
            }

            var result = new GetCommentDTO()
            {
                Id = entityFromDB.Id,
                UserId = entityFromDB.UserId,
                FullName = entityFromDB.FullName,
                CreatedDate = entityFromDB.CreatedDate,
                DateModified = entityFromDB.DateModified,
                Content = entityFromDB.Content,
            };

            return Result.Ok(result);
        }
    }
}
