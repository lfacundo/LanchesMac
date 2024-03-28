using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Areas.Admin.Services
{
    public class RelatorioVendasService
    {
        private readonly AppDbContext _context;

        public RelatorioVendasService(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedido select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(p => p.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(p => p.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                            .Include(p => p.PedidoItens)
                            .ThenInclude(p => p.Lanche)
                            .OrderByDescending(p => p.PedidoEnviado)
                            .ToListAsync();
        }
    }
}
