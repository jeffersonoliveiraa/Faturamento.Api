using Faturamento.Domain.Entities.v1;

namespace Faturamento.Domain.Contracts.v1.Repository;

public interface IFaturamentoRepository
{
    Task<IEnumerable<Faturamentos>> GetFaturamentosAsync();
    Task<Faturamentos> GetFaturamentosByIdAsync(int id);
    Task<Faturamentos> CreateFaturamentosAsync(Faturamentos faturamentos);
    Task<bool> UpdateFaturamentosAsync(Faturamentos faturamentos);
    Task<bool> DeleteFaturamentosAsync(Faturamentos faturamentos);
}
