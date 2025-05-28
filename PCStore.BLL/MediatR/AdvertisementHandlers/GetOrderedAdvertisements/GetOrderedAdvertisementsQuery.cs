using FluentResults;
using MediatR;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements
{
    public record GetOrderedAdvertisementsQuery : IRequest<Result<IEnumerable<Advertisement>>>
    {
    }
}
