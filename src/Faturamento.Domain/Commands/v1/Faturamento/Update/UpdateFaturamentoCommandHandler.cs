using Faturamento.Domain.Contracts.v1.Repository;
using MediatR;

namespace Faturamento.Domain.Commands.v1.Faturamento.Update;

public class UpdateFaturamentoCommandHandler : IRequestHandler<UpdateFaturamentoCommand, bool>
{
    private readonly IFaturamentoRepository _faturamentoRepository;

    public UpdateFaturamentoCommandHandler(IFaturamentoRepository faturamentoRepository)
    {
        _faturamentoRepository = faturamentoRepository;
    }

    public async Task<bool> Handle(UpdateFaturamentoCommand request, CancellationToken cancellationToken)
    {
        var faturamento = await _faturamentoRepository.GetFaturamentosByIdAsync(request.Id);

        if (faturamento == null)
            return false;

        faturamento.NomeCliente = request.NomeCliente;
        faturamento.ValorTotalPedido = request.ValorTotalPedido;
        faturamento.PedidoId = request.PedidoId;

        return await _faturamentoRepository.UpdateFaturamentosAsync(faturamento);
    }
}
