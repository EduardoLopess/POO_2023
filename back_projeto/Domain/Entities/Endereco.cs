namespace Domain.Entities
{
    public class Endereco
    {
        public int Id { get; private set; }
        public string Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        

        //Relacionamentos
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; } //FK
        //public Instituto Instituto { get; set; }
        //public Voluntariado Voluntariado { get; set; }
        //public PontosColetaDoacao PontosColetaDoacao { get; set; }
    }
}