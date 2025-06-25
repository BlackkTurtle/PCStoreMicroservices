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

namespace PCStore.BLL.MediatR.CommentHandlers.UpdateCommentStatusesHandler
{
    public class UpdateCommentStatusesHandler : IRequestHandler<UpdateCommentStatusesCommand, Result<bool>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelAPIService modelAPIService;
        private readonly ILoggerService _logger;

        public UpdateCommentStatusesHandler(IUnitOfWork unitOfWork, ILoggerService logger, IModelAPIService modelAPIService)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
            this.modelAPIService = modelAPIService;
        }

        public async Task<Result<bool>> Handle(UpdateCommentStatusesCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(5000);
            var ints = request.updateCommentDTOs.Select(x => x.Id).ToList();

            var updateCommentDTOs = request.updateCommentDTOs.OrderBy(x => x.Id).ToList();

            var entityFromDB = await unitOfWork.CommentRepository.GetAllAsync(new CommentByPredicateSpecification(ints));

            if (entityFromDB is null)
            {
                string errorMsg = $"Comments does not exist!";
                _logger.LogError(request, errorMsg);
                throw new EntityNotFoundException();
            }

            int i = 0;

            foreach (var entity in entityFromDB)
            {
                entity.CommentStatus = updateCommentDTOs[i].Valid ? CommentStatusEnum.Valid : CommentStatusEnum.Deleted;
            }

            var isSuccessResult = await unitOfWork.SaveChangesAsync() > 0;

            if (!isSuccessResult)
            {
                const string errorMsg = "Cannot save changes in the database after entity update!";
                _logger.LogError(request, errorMsg);
                throw new InternalServerErrorException();
            }

            return Result.Ok(true);
        }
    }
}
