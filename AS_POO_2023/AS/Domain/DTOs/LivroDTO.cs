using Domain.Entities;

namespace Domain.DTOs
{
    public class LivroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }

        // Relacionamento MUITO pra MUITOS, onde um livro tem muitos autores
        public IList<AutorDTO> Autores { get; set; }
    }
}