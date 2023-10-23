using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class VoluntariadoResponsabilidadeRepository : IVoluntariadoResponsabilidadeRepository
    {
        private readonly DataContext _context;
        public VoluntariadoResponsabilidadeRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(VoluntariadoResponsabilidade entity, Voluntariado voluntariado)
        {
            if (voluntariado == null)
            {
                throw new ArgumentException(nameof(voluntariado), "Volunteering cannot be null.");
            }

            var existVoluntariado = await _context.Voluntariados
                .SingleOrDefaultAsync(v => v.Id == voluntariado.Id);
            
            entity.Voluntariado = existVoluntariado ?? throw new ArgumentException($"Volunteering with Id {voluntariado.Id} does not exist in the database.");
            _context.Add(entity);
            await
                _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var existResponsabilidade = await _context.VoluntariadoResponsabilidades
                                            .Include(v => v.Voluntariado)
                                            .FirstOrDefaultAsync(r => r.Id == entityId);
            if(existResponsabilidade != null)
            {
                _context.VoluntariadoResponsabilidades.Remove(existResponsabilidade);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<VoluntariadoResponsabilidade>> GetAllAsync()
        {
            return
                await _context.VoluntariadoResponsabilidades
                    .Include(v => v.Voluntariado)
                    .ToListAsync();
        }

        public async Task<VoluntariadoResponsabilidade> GetByIdAsync(int entityId)
        {
            return
                await _context.VoluntariadoResponsabilidades
                    .Include(v => v.Voluntariado)
                    .SingleOrDefaultAsync(r => r.Id == entityId);
        }

        public async Task UpdateAsync(VoluntariadoResponsabilidade entity)
        {
            var existResponsabilidade = await _context.VoluntariadoResponsabilidades
                                        .Include(v => v.Voluntariado)
                                        .FirstOrDefaultAsync(r => r.Id == entity.Id);
            if(existResponsabilidade != null)
            {
                _context.Entry(existResponsabilidade).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }
    }
}