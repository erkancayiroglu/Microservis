using Microservis.Order.Application.Features.CQRS.Commands.AdressCommands;
using Microservis.Order.Application.Interfaces;
using Microservis.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservis.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class RemoveAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.DeleteAsync(value);
        }

    }
}
