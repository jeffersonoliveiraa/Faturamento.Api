using Faturamento.Domain.Contracts.v1.Repository;
using Faturamento.Domain.Entities.v1;
using Faturamento.Infra.Data.Context.v1;
using Microsoft.EntityFrameworkCore;

namespace Faturamento.Infra.Data.Repositories.v1;

public class FaturamentosRepository : IFaturamentoRepository
{
    private readonly DbContextClass _context;

    public FaturamentosRepository(DbContextClass context)
    {
        _context = context;
    }

    public async Task<Faturamentos> CreateFaturamentosAsync(Faturamentos faturamentos)
    {
        try
        {
            var result = _context.Faturamentos!.Add(faturamentos);
            await _context.SaveChangesAsync();

            return result.Entity;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<bool> DeleteFaturamentosAsync(Faturamentos faturamentos)
    {
        try
        {
            _context.Faturamentos!.Remove(faturamentos);
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<IEnumerable<Faturamentos>> GetFaturamentosAsync()
    {
        try
        {
            return await _context.Faturamentos!.ToListAsync();
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<Faturamentos> GetFaturamentosByIdAsync(int id)
    {
        try
        {
            var faturamento = await _context.Faturamentos!.FirstOrDefaultAsync(f => f.Id.Equals(id));
            return faturamento!;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public async Task<bool> UpdateFaturamentosAsync(Faturamentos faturamentos)
    {
        try
        {
            _context.Entry(faturamentos).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();

            return result > 0;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
