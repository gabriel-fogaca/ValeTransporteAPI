using System.ComponentModel.DataAnnotations;

namespace ValeControl.API.Entities;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(200)]
    public required string Nome { get; set; }
    [Required]
    public EscalaTrabalho Escala { get; set; }

    [Required]
    public required decimal CustoDiario { get; set; }

    public bool Ativo {  get; set; }

    public Funcionario()
    {
        
    }

    public Funcionario(int id, string nome, EscalaTrabalho escala, decimal custoDiario, bool ativo )
    {
        Id = id;
        Nome = nome;
        Escala = escala;
        CustoDiario = custoDiario;
        Ativo = ativo;
    }
}
