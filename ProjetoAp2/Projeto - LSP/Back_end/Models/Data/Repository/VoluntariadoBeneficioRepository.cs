using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class VoluntariadoBeneficioRepository : IVoluntariadoBeneficioRepository
    {
        private readonly DataContext _context;
        public VoluntariadoBeneficioRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(VoluntariadoBeneficio entity, Voluntariado voluntariado)
        {
            if (voluntariado == null)
            {
                throw new ArgumentNullException(nameof(voluntariado), "Volunteering cannot be null.");
            }

            var existVoluntariado = await _context.Voluntariados
                .SingleOrDefaultAsync(v => v.Id == voluntariado.Id);
            
            entity.Voluntariado = existVoluntariado ?? throw new ArgumentException($"Voluntariado de Id. {voluntariado.Id} não existe no banco.");

            _context.Add(entity);
            await
                _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var existBeneficio = await _context.VoluntariadoBeneficios
                                .Include(v => v.Voluntariado)
                                .FirstOrDefaultAsync(b => b.Id == entityId);
            if(existBeneficio != null)
            {
                _context.VoluntariadoBeneficios.Remove(existBeneficio);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<VoluntariadoBeneficio>> GetAllAsync()
        {
            return
                await _context.VoluntariadoBeneficios
                    .Include(v => v.Voluntariado)
                    .ToListAsync();
        }

        public async Task<VoluntariadoBeneficio> GetByIdAsync(int entityId)
        {
            return 
                await _context.VoluntariadoBeneficios
                    .Include(v => v.Voluntariado)
                    .SingleOrDefaultAsync(b => b.Id == entityId);
        }

        public async Task UpdateAsync(VoluntariadoBeneficio entity)
        {
            var existBeneficio = await _context.VoluntariadoBeneficios
                                .Include(v => v.Voluntariado)
                                .FirstOrDefaultAsync(b => b.Id == entity.Id);
            if(existBeneficio != null)
            {
                _context.Entry(existBeneficio).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }
    }
}