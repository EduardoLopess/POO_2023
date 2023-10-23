using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class PontoDoacaoRepository : IPontoDoacaoRepository
    {
        private readonly DataContext _context;
        public PontoDoacaoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(PontoDoacao entity, Endereco endereco, MaterialDoacao materialDoacao)
        {
            entity.Endereco = endereco;
            entity.MaterialDoacao = materialDoacao;
            _context.Add(entity);

            await
                _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await _context.PontoDoacao.FindAsync(entityId);
            if(entity != null)
            {
                _context.PontoDoacao.Remove(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<PontoDoacao>> GetAllAsync()
        {
            return
                await
                    _context.PontoDoacao
                    .Include(e => e.Endereco)
                    .Include(i => i.Instituto)
                    .Include(m => m.MaterialDoacao)
                    .ToListAsync();
        }

        public async Task<PontoDoacao> GetByIdAsync(int entityId)
        {
            return
                await
                    _context.PontoDoacao
                    .Include(e => e.Endereco)
                    .Include(i => i.Instituto)
                    .Include(m => m.MaterialDoacao)
                    .SingleOrDefaultAsync(p => p.Id == entityId);        
        }

        public async Task UpdateAsync(PontoDoacao entity)
        {
            var existPontoDoacao = await _context.PontoDoacao
                                .Include(e => e.Endereco)
                                .Include(i => i.Instituto)
                                .Include(m => m.MaterialDoacao)
                                .FirstOrDefaultAsync(p => p.Id == entity.Id);
            if(existPontoDoacao != null)
            {
                _context.Entry(existPontoDoacao).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }
    }
}