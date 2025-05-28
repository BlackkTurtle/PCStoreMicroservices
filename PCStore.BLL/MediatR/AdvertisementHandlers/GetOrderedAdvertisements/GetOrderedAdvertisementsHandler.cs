using FluentResults;
using MediatR;
using PCStore.BLL.Services.Contracts;
using PCStore.BLL.Specifications.AdvertisementSpecifications;
using PCStore.DAL.Repositories.Contracts;
using PCStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCStore.BLL.MediatR.AdvertisementHandlers.GetOrderedAdvertisements
{
    public class GetOrderedAdvertisementsHandler : IRequestHandler<GetOrderedAdvertisementsQuery, Result<IEnumerable<Advertisement>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILoggerService _logger;

        public GetOrderedAdvertisementsHandler(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            this.unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<Advertisement>>> Handle(GetOrderedAdvertisementsQuery request, CancellationToken cancellationToken)
        {
            var entitiesFromDB = await unitOfWork.AdvertisementRepository
                .GetAllAsync(new AdvertisementOrderedSpecification());

            if (entitiesFromDB is null)
            {
                string errorMsg = "Cannot find entities!";
                _logger.LogError(request, errorMsg);
                return new Error(errorMsg);
            }

            return Result.Ok(entitiesFromDB);
        }
    }
}
