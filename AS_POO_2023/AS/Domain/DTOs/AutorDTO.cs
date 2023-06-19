using Domain.Entities;

namespace Domain.DTOs
{
    public class AutorDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        //ADD os IDs na controller quando chamar Autor
        public List<int> LivroIds { get; set; }
    }
}