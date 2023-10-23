using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class InstitutoRepository : IInstitutoRepository
    {
        private readonly DataContext _context;
        public InstitutoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Instituto entity, Endereco endereco)
        {
            entity.Endereco = endereco;
            _context.Add(entity);

            await
                _context.SaveChangesAsync();
        }

        public  async Task DeleteAsync(int entityId)
        {
            var existInstitute = await _context.Institutos
                                .Include(v => v.Voluntariados)
                                .Include(e => e.Endereco)
                                .FirstOrDefaultAsync(i => i.Id == entityId);
            if(existInstitute != null)
            {
                _context.Institutos.Remove(existInstitute);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Instituto>> GetAllAsync()
        {
            return 
                await _context.Institutos
                    .Include(v => v.Voluntariados)
                    .Include(e => e.Endereco)
                    .ToListAsync();
        }

        public async Task<Instituto> GetByIdAsync(int entityId)
        {
            return 
                await _context.Institutos
                    .Include(v => v.Voluntariados)
                    .Include(e => e.Endereco)
                    .FirstOrDefaultAsync(i => i.Id == entityId);
        }

        public async Task UpdateAsync(Instituto entity)
        {
            var existInstitute = await _context.Institutos
                                .Include(v => v.Voluntariados)
                                .Include(e => e.Endereco)
                                .FirstOrDefaultAsync(i => i.Id == entity.Id);
            if(existInstitute != null)
            {
                _context.Entry(existInstitute).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }
    }
}