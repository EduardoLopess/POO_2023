using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class MaterialDoacaoRepository : IMaterialDoacaoRepository
    {
        private readonly DataContext _context;
        public MaterialDoacaoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(MaterialDoacao entity, Instituto instituto, PontoDoacao pontoDoacao)
        {
            entity.Instituto = instituto;
            entity.PontoDoacao = pontoDoacao;

           await 
                _context.MateriaisDoacao.AddAsync(entity);
        }

        public async Task DeleteAsync(int entityId)
        {
            var entity = await _context.MateriaisDoacao.FindAsync(entityId);
            if(entity != null)
            {
                _context.MateriaisDoacao.Remove(entity);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<MaterialDoacao>> GetAllAsync()
        {
            return
                await
                    _context.MateriaisDoacao
                    .Include(t => t.TipoMaterial)
                    .Include(p => p.PrioridadeDoacao)
                    .Include(d => d.PontoDoacao)
                    .Include(i => i.Instituto)
                    .ToListAsync();
        }

        public async Task<MaterialDoacao> GetByIdAsync(int entityId)
        {
             return
                await
                    _context.MateriaisDoacao
                    .Include(t => t.TipoMaterial)
                    .Include(p => p.PrioridadeDoacao)
                    .Include(d => d.PontoDoacao)
                    .Include(i => i.Instituto)
                    .SingleOrDefaultAsync(m => m.Id == entityId);
        }

        public async Task UpdateAsync(MaterialDoacao entity)
        {
            var existMaterialDoacao = await _context.MateriaisDoacao
                                    .Include(t => t.TipoMaterial)
                                    .Include(p => p.PrioridadeDoacao)
                                    .Include(d => d.PontoDoacao)
                                    .Include(i => i.Instituto)
                                    .FirstOrDefaultAsync(m => m.Id == entity.Id);
            if(existMaterialDoacao != null)
            {
                _context.Entry(existMaterialDoacao).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }
    }
}