using Aplicada1.Core;
using Microsoft.EntityFrameworkCore;
using PrimerParcialAP1Dharianny.Context;
using PrimerParcialAP1Dharianny.Models;
using System.Linq.Expressions;

namespace PrimerParcialAP1Dharianny.Services;

public class ColectasService(IDbContextFactory<Contexto> contextFactory) : IService<Colectas, int>
{
    public async Task<bool> Guardar(Colectas colecta)
    {
        if (!await Existe(colecta.AporteId))
        {
            return await Insertar(colecta);
        }
        else
        {
            return await Modificar(colecta);
        }
    }

    public async Task<bool> Existe(int idAporte)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Colectas
            .AnyAsync(c => c.AporteId == idAporte);
    }

    public async Task<bool> Insertar(Colectas colecta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Colectas.Add(colecta);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Modificar(Colectas colecta)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        contexto.Update(colecta);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<Colectas?> Buscar(int idAporte)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Colectas
            .FirstOrDefaultAsync(c => c.AporteId == idAporte);
    }

    public async Task<List<Colectas>> GetList(Expression<Func<Colectas, bool>> criterio)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Colectas
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> Eliminar(int idAporte)
    {
        await using var contexto = await contextFactory.CreateDbContextAsync();
        return await contexto.Colectas
            .Where(c => c.AporteId == idAporte)
            .ExecuteDeleteAsync() > 0;
    }
}
