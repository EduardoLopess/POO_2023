namespace ex02.Models.Interfaces
{
    public interface IPessoa
    {
        string Nome {get; set;}
        int Idade {get; set;}
        void Falar();
    }
}