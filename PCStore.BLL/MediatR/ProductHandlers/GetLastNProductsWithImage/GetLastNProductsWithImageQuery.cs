using FluentResults;
using MediatR;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.ProductHandlers.GetLastNProductsWithImage
{
    public record GetLastNProductsWithImageQuery(int n) : IRequest<Result<List<GetProductWithRatingDTO>>>
    {
    }
}
