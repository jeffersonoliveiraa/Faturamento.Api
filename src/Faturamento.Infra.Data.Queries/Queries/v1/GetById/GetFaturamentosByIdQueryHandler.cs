using Faturamento.Domain.Contracts.v1.Repository;
using Faturamento.Domain.Entities.v1;
using MediatR;

namespace Faturamento.Infra.Data.Queries.Queries.v1.GetById;

public class GetFaturamentosByIdQueryHandler : IRequestHandler<GetFaturamentosByIdQuery, Faturamentos>
{
    private readonly IFaturamentoRepository _faturamentoRepository;

    public GetFaturamentosByIdQueryHandler(IFaturamentoRepository faturamentoRepository)
    {
        _faturamentoRepository = faturamentoRepository;
    }

    public async Task<Faturamentos> Handle(GetFaturamentosByIdQuery request, CancellationToken cancellationToken)
    {
        return await _faturamentoRepository.GetFaturamentosByIdAsync(request.Id);
    }
}
