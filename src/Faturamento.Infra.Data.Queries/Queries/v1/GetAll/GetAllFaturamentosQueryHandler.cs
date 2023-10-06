using Faturamento.Domain.Contracts.v1.Repository;
using Faturamento.Domain.Entities.v1;
using Faturamento.Infra.Data.Repositories.v1;
using MediatR;

namespace Faturamento.Infra.Data.Queries.Queries.v1.GetAll;

public class GetAllFaturamentosQueryHandler : IRequestHandler<GetAllFaturamentosQuery, IEnumerable<Faturamentos>>
{
    private IFaturamentoRepository _faturamentosRepository;

    public GetAllFaturamentosQueryHandler(IFaturamentoRepository faturamentosRepository)
    {
        _faturamentosRepository = faturamentosRepository;
    }
    public async Task<IEnumerable<Faturamentos>> Handle(GetAllFaturamentosQuery request, CancellationToken cancellationToken)
    {
        var faturamentos = await _faturamentosRepository.GetFaturamentosAsync();
        return faturamentos;
    }
}
