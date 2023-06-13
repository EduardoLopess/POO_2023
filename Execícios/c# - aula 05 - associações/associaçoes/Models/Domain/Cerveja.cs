namespace associaçoes.Models.Domain
{
    public class Cerveja : Garrafa
    {
        public Cerveja(string codBarras, string marca, int volume, int teorAlcolico) : base(codBarras, marca, volume)
        {
            this.TeorAlcolico = teorAlcolico;
        }

        public int TeorAlcolico { get; set; }
        
    }
}