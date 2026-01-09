using Microservis.Order.Application.Features.CQRS.Results.AdressResults;
using Microservis.Order.Application.Interfaces;
using Microservis.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservis.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail1,
                District = x.District,
                UserId = x.UserId
            }).ToList();
        }

    }
}
