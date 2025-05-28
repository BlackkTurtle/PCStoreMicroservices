using FluentResults;
using MediatR;
using PCStore.Data.DTOs.OtherDTOs;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.OtherHandlers.GetSearchResults
{
    public record GetSearchResultsQuery(string nameLike) : IRequest<Result<SearchBarResultDTO>>
    {
    }
}
