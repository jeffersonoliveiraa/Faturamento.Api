using Faturamento.Domain.Contracts.v1.Repository;
using Faturamento.Domain.Entities.v1;
using MediatR;

namespace Faturamento.Domain.Commands.v1.Faturamento.Create;

public class CreateFaturamentosCommandHandler : IRequestHandler<CreateFaturamentosCommand, Faturamentos>
{
    private readonly IFaturamentoRepository _faturamentoRepository;

    public CreateFaturamentosCommandHandler(IFaturamentoRepository faturamentoRepository)
    {
        _faturamentoRepository = faturamentoRepository;
    }

    public async Task<Faturamentos> Handle(CreateFaturamentosCommand request, CancellationToken cancellationToken)
    {
        Faturamentos faturamentos = new()
        {
            PedidoId = request.PedidoId,
            NomeCliente = request.NomeCliente,
            ValorTotalPedido = request.ValorTotalPedido
        };

        var result = await _faturamentoRepository.CreateFaturamentosAsync(faturamentos);

        return result;
    }
}
