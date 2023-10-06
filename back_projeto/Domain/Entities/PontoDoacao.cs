using Domain.Enums;

namespace Domain.Entities
{
    public class PontoDoacao
    {
        public int Id { get; set; }
        public string NomeLocal { get; set; }
<<<<<<< HEAD
        public TipoMaterial MateriasAceito { get; set; }//Enum
=======
        public TipoMaterial MateriasAceito { get; set; } // Enum
>>>>>>> 847275f5ae365e78b65ddff5520896cbd18ae457

        public Endereco Endereco { get; set; }
        public Instituto Instituto { get; set; }
    }
}