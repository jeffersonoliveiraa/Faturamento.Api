using Faturamento.Domain.Entities.v1;
using MediatR;

namespace Faturamento.Infra.Data.Queries.Queries.v1.GetById;

public class GetFaturamentosByIdQuery : IRequest<Faturamentos>
{
    public int Id { get; set; }
}
