using ValeControl.API.Entities;

namespace ValeControl.API.Models;

public class FuncionarioParaAtualizacaoDTO
{
    public required string Nome { get; set; }
    public required string Escala { get; set; }
    public required decimal CustoDiario { get; set; }
    public required bool Ativo { get; set; }

}
