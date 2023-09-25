namespace Domain.DTOs
{
    public class EnderecoDTO
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public int NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        public int Cep { get; set; }
        public string Cidade { get; set; }
        

        public UsuarioDTO UsuarioDTO { get; set; }
    }
}