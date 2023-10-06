using Faturamento.Domain.Entities.v1;
using MediatR;

namespace Faturamento.Infra.Data.Queries.Queries.v1.GetAll;

public class GetAllFaturamentosQuery : IRequest<IEnumerable<Faturamentos>>
{
}
