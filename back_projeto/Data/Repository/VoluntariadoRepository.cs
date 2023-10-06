using Domain.Entities;
using Domain.Intarfaces;

namespace Data.Repository
{
    public class VoluntariadoRepository : IVoluntariadoRepository
    {
        private readonly DataContext _context;
        public VoluntariadoRepository(DataContext context)
        {
            _context = context;
        }
      
        public Task CreateAsync(Voluntariado entity, Instituto instituto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Voluntariado>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Voluntariado> GetByIdAsync(int entityId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Voluntariado entity)
        {
            throw new NotImplementedException();
        }

        //Voluntarido Inscricao
        public Task InscreverUsuarioAsync(int voluntariadoId, int usuarioId)
        {
            throw new NotImplementedException();
        }

        public Task CancelarInscricaoUsuarioAsync(int voluntariadoId, int usuarioId)
        {
            throw new NotImplementedException();
        }

    }
}