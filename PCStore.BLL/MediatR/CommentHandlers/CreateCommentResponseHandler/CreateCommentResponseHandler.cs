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

namespace PCStore.BLL.MediatR.CommentHandlers.CreateCommentResponseHandler
{
    public class CreateCommentResponseHandler : IRequestHandler<CreateCommentResponseCommand, Result<GetCommentDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelAPIService modelAPIService;
        private readonly ILoggerService _logger;

        public CreateCommentResponseHandler(IUnitOfWork unitOfWork, ILoggerService logger, IModelAPIService modelAPIService)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
            this.modelAPIService = modelAPIService;
        }

        public async Task<Result<GetCommentDTO>> Handle(CreateCommentResponseCommand request, CancellationToken cancellationToken)
        {
            var commentExist = await unitOfWork.CommentRepository.CheckIfCommentWithProductIdExist(request.createCommentDto.ProductId, request.createCommentDto.CommentId);

            if (!commentExist)
            {
                string errorMsg = $"Comment with id: {request.createCommentDto.CommentId} and ProductId: {request.createCommentDto.ProductId} does not exist!";
                _logger.LogError(request, errorMsg);
                throw new EntityNotFoundException();
            }

            double modelResult = await modelAPIService.GetModelPrediction(request.createCommentDto.Content);

            if (modelResult >= 0.8)
            {
                string errorMsg = $"Comment was very abusive!";
                _logger.LogError(request, errorMsg);
                throw new CommentToxicException();
            }

            var comment = new Comment()
            {
                UserId = request.userId,
                FullName = request.fullName,
                ProductId = request.createCommentDto.ProductId,
                ParentId = request.createCommentDto.CommentId,
                CreatedDate = DateTime.Now,
                Content = request.createCommentDto.Content,
                IsReview = false,
                CommentStatus = modelResult <= 0.1 ? CommentStatusEnum.Valid : CommentStatusEnum.Review
            };

            var createdcomment = unitOfWork.CommentRepository.Create(comment);

            var isSuccessResult = await unitOfWork.SaveChangesAsync() > 0;

            if (!isSuccessResult)
            {
                const string errorMsg = "Cannot save changes in the database after entity creation!";
                _logger.LogError(request, errorMsg);
                throw new InternalServerErrorException();
            }

            var result = new GetCommentDTO()
            {
                Id = createdcomment.Id,
                UserId = createdcomment.UserId,
                FullName = createdcomment.FullName,
                CreatedDate = createdcomment.CreatedDate,
                DateModified = createdcomment.DateModified,
                Content = createdcomment.Content,
            };

            return Result.Ok(result);
        }
    }
}
