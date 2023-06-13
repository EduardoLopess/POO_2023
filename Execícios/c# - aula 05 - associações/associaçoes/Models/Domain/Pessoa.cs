namespace associaçoes.Models.Domain
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Endereco> Enderecos;

        public Pessoa()
        {
            Enderecos = new List<Endereco>();
        }

        
        public void addEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }
    }
}