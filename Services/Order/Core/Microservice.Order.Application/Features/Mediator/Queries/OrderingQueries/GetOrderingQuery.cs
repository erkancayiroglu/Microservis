using MediatR;
using Microservis.Order.Application.Features.Mediator.Results.OrderingResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservis.Order.Application.Features.Mediator.Queries.OrderingQueries
{
    public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>//MEdiatr kütüphanesinden IRequest arayüzünü implemente ediyoruz ve bu sorgunun sonucunda GetOrderingQueryResult tipinde bir liste döneceğimizi belirtiyoruz.
    {
    }

}
