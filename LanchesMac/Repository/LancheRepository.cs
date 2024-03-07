﻿using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;

        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanches.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchesPreferidos => _context.Lanches
                                    .Where(c => c.IsLanchePreferido)
                                    .Include(c => c.Categoria);

        public Lanche GetLancheById(int lancheId) => _context.Lanches
                                    .FirstOrDefault(c => c.LancheId == lancheId);
    }
}
