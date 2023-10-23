using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class VoluntariadoRepository : IVoluntariadoRepository
    {
        private readonly DataContext _context;
        public VoluntariadoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Voluntariado entity, IList<VoluntariadoResponsabilidade> responsabilidades, IList<VoluntariadoBeneficio> beneficios)
        {
            entity.Beneficios = beneficios;
            entity.Responsabilidade = responsabilidades;

            _context.Add(entity);

            foreach (var responsabilidade in responsabilidades)
            {
                _context.Add(responsabilidade);
            }

            foreach(var beneficio in beneficios)
            {
                _context.Add(beneficio);
            }

            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int entityId)
        {
             var existVoluntariado = await _context.Voluntariados
                                .Include(b => b.Beneficios)
                                .Include(r => r.Responsabilidade)
                                .FirstOrDefaultAsync(v => v.Id == entityId);
            if(existVoluntariado != null)
            {
                _context.Voluntariados.Remove(existVoluntariado);
                await
                    _context.SaveChangesAsync();
            }
        }

        public async Task<IList<Voluntariado>> GetAllAsync()
        {
            return
                await _context.Voluntariados
                    .Include(b => b.Beneficios)
                    .Include(r => r.Responsabilidade)
                    .ToListAsync();
        }

        public async Task<Voluntariado> GetByIdAsync(int entityId)
        {
            return
                await _context.Voluntariados
                    .Include(b => b.Beneficios)
                    .Include(r => r.Responsabilidade)
                    .SingleOrDefaultAsync(v => v.Id == entityId);
        }

        public async Task UpdateAsync(Voluntariado entity)
        {
            var existVoluntariado = await _context.Voluntariados
                                .Include(b => b.Beneficios)
                                .Include(r => r.Responsabilidade)
                                .FirstOrDefaultAsync(v => v.Id == entity.Id);
            if(existVoluntariado != null)
            {
                _context.Entry(existVoluntariado).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }
        }
    }
}