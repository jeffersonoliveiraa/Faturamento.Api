using Faturamento.Domain.Contracts.v1.Repository;
using MediatR;

namespace Faturamento.Domain.Commands.v1.Faturamento.Delete;

public class DeleteFaturamentosCommandHandler : IRequestHandler<DeleteFaturamentosCommand, bool>
{
    private readonly IFaturamentoRepository _faturamentoRepository;

    public DeleteFaturamentosCommandHandler(IFaturamentoRepository faturamentoRepository)
    {
        _faturamentoRepository = faturamentoRepository;
    }

    public async Task<bool> Handle(DeleteFaturamentosCommand request, CancellationToken cancellationToken)
    {
        var faturamento = await _faturamentoRepository.GetFaturamentosByIdAsync(request.Id);

        if (faturamento == null)
            return false;

        return await _faturamentoRepository.DeleteFaturamentosAsync(faturamento);
    }
}
