using MediatR;

namespace Faturamento.Domain.Commands.v1.Faturamento.Delete;

public class DeleteFaturamentosCommand : IRequest<bool>
{
    public int Id { get; set; }
}
