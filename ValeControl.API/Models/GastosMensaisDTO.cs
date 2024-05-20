namespace ValeControl.API.Models;

public class GastosMensaisDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Escala { get; set; }
    public decimal CustoDiario { get; set; }
    public bool Ativo { get; set; }
    public decimal CustoTotal { get; set; }
}
