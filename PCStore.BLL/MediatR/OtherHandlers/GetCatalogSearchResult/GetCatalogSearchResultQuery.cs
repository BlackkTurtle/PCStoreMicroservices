using FluentResults;
using MediatR;
using PCStore.Data.DTOs.OtherDTOs;
using PCStore.Data.DTOs.OtherDTOs.CatalogDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.OtherHandlers.GetCatalogSearchResult
{
    public record GetCatalogSearchResultQuery(CatalogSearchRequestDTO catalogSearchRequestDTO) : IRequest<Result<CatalogSearchResultDTO>>
    {
    }
}
