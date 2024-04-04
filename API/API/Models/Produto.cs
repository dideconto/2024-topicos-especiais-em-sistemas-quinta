namespace API.Models;

public class Produto
{
    //Construtor
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
    }

    public Produto(string nome, string descricao, double valor)
    {
        Id = Guid.NewGuid().ToString();
        Nome = nome;
        Descricao = descricao;
        Valor = valor;
        CriadoEm = DateTime.Now;
    }

    //Atributos ou propriedades = Características de um objeto
    public string Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public double Valor { get; set; }
    public DateTime CriadoEm { get; set; }
}