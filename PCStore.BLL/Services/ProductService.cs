using PCStore.BLL.Helpers;
using PCStore.BLL.Services.Contracts;
using PCStore.DAL.Infrastructure.Interfaces;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Responses.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.Services
{
    public class ProductService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ResponseCreator _responseCreator;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _responseCreator = new ResponseCreator();
        }

        public async Task<IBaseResponse<List<GetProductWithRatingDTO>>> GetProductWithRatingDTOAsync()
        {
            try
            {
                var productsFromDatabase = await _unitOfWork.ProductRepository.GetLastNProductsWith1Photo(2);

                if (productsFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetProductWithRatingDTO>>("No Products found.");

                var result=new List<GetProductWithRatingDTO>();
                foreach (var product in productsFromDatabase)
                {
                    double rating=await _unitOfWork.CommentRepository.GetRatingByProductId(product.Id);
                    bool availlability=await _unitOfWork.ProductStoragesRepository.CheckAvaillabilityByProductId(product.Id);
                    result.Add(new GetProductWithRatingDTO()
                    {
                        Id=product.Id,
                        Name=product.Name,
                        Rating=rating,
                        Availlability=!availlability,
                        PhotoLink = product.Photos.FirstOrDefault().PhotoLink,
                        Price=product.Price
                    });
                }

                return _responseCreator.CreateBaseOk(result, result.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetProductWithRatingDTO>>(e.Message);
            }
        }


        public async Task<IBaseResponse<List<GetProductWithRatingDTO>>> GetMultipleProductWithRatingDTOByIdAsync(int[] ints)
        {
            try
            {
                var productsFromDatabase = await _unitOfWork.ProductRepository.GetMultipleById(ints);

                if (productsFromDatabase.Count == 0)
                    return _responseCreator.CreateBaseNotFound<List<GetProductWithRatingDTO>>("No Products found.");

                var result = new List<GetProductWithRatingDTO>();
                foreach (var product in productsFromDatabase)
                {
                    double rating = await _unitOfWork.CommentRepository.GetRatingByProductId(product.Id);
                    bool availlability = await _unitOfWork.ProductStoragesRepository.CheckAvaillabilityByProductId(product.Id);
                    result.Add(new GetProductWithRatingDTO()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Rating = rating,
                        Availlability = !availlability,
                        PhotoLink = product.Photos.FirstOrDefault().PhotoLink,
                        Price = product.Price
                    });
                }

                return _responseCreator.CreateBaseOk(result, result.Count);
            }
            catch (Exception e)
            {
                return _responseCreator.CreateBaseServerError<List<GetProductWithRatingDTO>>(e.Message);
            }
        }
    }
}
