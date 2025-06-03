using FluentResults;
using MediatR;
using PCStore.BLL.Exceptions;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.BLL.Specifications.ProductSpecifications;
using PCStore.DAL.Repositories.Contracts;
using PCStore.DAL.Specification;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.ProductHandlers.GetFullProductById
{
    public class GetFullProductByIdHandler : IRequestHandler<GetFullProductByIdQuery, Result<GetFullProductDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService _logger;

        public GetFullProductByIdHandler(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<GetFullProductDTO>> Handle(GetFullProductByIdQuery request, CancellationToken cancellationToken)
        {
            var entityFromDB = await unitOfWork.ProductRepository
                .GetFullProductById(request.id);

            if (entityFromDB is null)
            {
                string errorMsg = "Cannot find entity!";
                _logger.LogError(request, errorMsg);
                throw new EntityNotFoundException();
            }

            var result = new GetFullProductDTO()
            {
                Id = entityFromDB.Id,
                Name = entityFromDB.Name,
                Price = entityFromDB.Price,
                Images = entityFromDB.Photos.Select(x => x.PhotoLink).ToList(),
                CategoryIdNameDTO = new Data.DTOs.CategoryDTOs.CategoryIdNameDTO()
                {
                    Id = entityFromDB.Category.Id,
                    Name = entityFromDB.Category.Name,
                },
                BrandName = entityFromDB.Brand.Name,
                Description = entityFromDB.Description,
                CreatedDate = entityFromDB.CreatedDate,
                Rating = entityFromDB.Comments.Average(c => (double?)c.Rating) ?? 0.0,
                Availlability = entityFromDB.ProductStorages.Any(x => x.Quantity > 0),
                Comments = entityFromDB.Comments.Where(c => !c.IsReview && c.ParentId == null).OrderByDescending(c => c.CreatedDate).Select(c => new Data.DTOs.CommentDTOs.GetCommentDTO()
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    FullName = c.FullName,
                    CreatedDate = c.CreatedDate,
                    DateModified = c.DateModified,
                    Content = c.Content,
                    Children = c.Children.OrderBy(ch => ch.CreatedDate).Select(ch => new Data.DTOs.CommentDTOs.GetCommentDTO()
                    {
                        Id = ch.Id,
                        UserId = ch.UserId,
                        FullName = ch.FullName,
                        CreatedDate = ch.CreatedDate,
                        DateModified = ch.DateModified,
                        Content = ch.Content,
                    }).ToList(),
                }).ToList(),
                Reviews = entityFromDB.Comments.Where(c => c.IsReview).OrderByDescending(c => c.CreatedDate).Select(c => new Data.DTOs.CommentDTOs.GetReviewDTO()
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    FullName = c.FullName,
                    CreatedDate = c.CreatedDate,
                    DateModified = c.DateModified,
                    Rating = c.Rating ?? 0,
                    Content = c.Content,
                }).ToList(),
                ProductCharacteristics = entityFromDB.ProductCharacteristics.OrderBy(x => x.Order).Select(pc => new Data.DTOs.ProductCharacteristicsDTOs.GetProductCharacteristicDTO()
                {
                    Id = pc.Id,
                    Name = pc.Name,
                    CharacteristicId = pc.CharacteristicId,
                    CharacteristicName = pc.Characteristic.Name,
                    Linkable = entityFromDB.Category.Characteristics.Any(x => x.Id == pc.CharacteristicId),
                }).ToList(),
            };

            return Result.Ok(result);
        }
    }
}
