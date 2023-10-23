using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Back_end.Models.Domain.Entities;
using Back_end.Models.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_end.Models.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly DataContext _context;
        public EnderecoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Endereco entity, int institutoId, int pontoDoacaoId)
        {
            entity.InstitutoId = institutoId;
            entity.PontoDoacaoId = pontoDoacaoId;

            _context.Add(entity);
            await
                _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
          var exitEndereco = await _context.Enderecos
                            .Include(i => i.Instituto)
                            .Include(p => p.PontoDoacao)
                            .FirstOrDefaultAsync(e => e.Id == entityId);
            if(exitEndereco != null)
            {
                _context.Enderecos.Remove(exitEndereco);
                await
                    _context.SaveChangesAsync();
            } 
        }

        public async Task<IList<Endereco>> GetAllAsync()
        {
            return
                await _context.Enderecos
                    .Include(i => i.Instituto)
                    .Include(p => p.PontoDoacao)
                    .ToListAsync();

        }

        public async Task<Endereco> GetByIdAsync(int entityId)
        {
            return
                await _context.Enderecos
                    .Include(i => i.Instituto)
                    .Include(p => p.PontoDoacao)
                    .SingleOrDefaultAsync(e => e.Id == entityId);
        }

        public async Task UpdateAsync(Endereco entity)
        {
            var exitEndereco = await _context.Enderecos
                            .Include(i => i.Instituto)
                            .Include(p => p.PontoDoacao)
                            .FirstOrDefaultAsync(e => e.Id == entity.Id);
            if(exitEndereco != null)
            {
                _context.Entry(exitEndereco).CurrentValues.SetValues(entity);
                await
                    _context.SaveChangesAsync();
            }

        }
    }
}