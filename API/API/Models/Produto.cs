using System.ComponentModel.DataAnnotations;

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

    //Anotação - Data Annotations
    [Required(ErrorMessage = "Este campo é obrigatório!")]
    public string? Nome { get; set; }

    [MinLength(3, ErrorMessage = "Este campo tem o tamanho mínimo de 3 caracteres!")]
    [MaxLength(10, ErrorMessage = "Este campo tem o tamanho máximo de 10 caracteres!")]
    public string? Descricao { get; set; }

    [Range(1,1000, ErrorMessage = "Este campo deve ter valor entre R$ 1,00 e R$ 1000,00!")]
    public double Valor { get; set; }
    public DateTime CriadoEm { get; set; }
    public int Quantidade { get; set; }
}