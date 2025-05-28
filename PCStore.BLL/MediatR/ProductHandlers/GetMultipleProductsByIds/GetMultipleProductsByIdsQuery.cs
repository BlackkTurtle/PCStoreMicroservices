using FluentResults;
using MediatR;
using PCStore.Data.DTOs.ProductDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.ProductHandlers.GetMultipleProductsByIds
{
    public record GetMultipleProductsByIdsQuery(int[] ints) : IRequest<Result<List<GetProductWithRatingDTO>>>
    {
    }
}
