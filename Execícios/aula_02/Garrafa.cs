namespace aula_02
{
    public class Garrafa
    {

        public Garrafa(int codigo, string cor, int anoFabricacao, int identificador)
        {
            this.Codigo = codigo;
            this.Cor = cor;
            this.AnoFabricacao = anoFabricacao;
            this.Identificador = identificador;
        }

        //Leitura e escrita
        public int Codigo { get; protected set; }
        public string Cor { get; set; }
        public int AnoFabricacao { get; protected set; }
        public int Identificador { get; protected set; }
        public int Volume { get; set; }



    }
}