using ValeControl.API.EndpointHandlers;

namespace ValeControl.API.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void RegisterFuncionariosEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var funcionariosEndpoints = endpointRouteBuilder.MapGroup("/funcionarios");
            var funcionariosComIdEndPoints = funcionariosEndpoints.MapGroup("/{funcionarioId:int}");

            funcionariosEndpoints.MapGet("", FuncionariosHandlers.GetFuncionariosAsync);

            funcionariosComIdEndPoints.MapGet("", FuncionariosHandlers.GetFuncionarioByIdAsync).WithName("GetFuncionarios");

            funcionariosEndpoints.MapPost("", FuncionariosHandlers.CreateFuncionarioAsync);

            funcionariosComIdEndPoints.MapPut("", FuncionariosHandlers.UpdateFuncionarioAsync);

            funcionariosComIdEndPoints.MapPut("/inativar", FuncionariosHandlers.InativarFuncionarioById);

            funcionariosComIdEndPoints.MapDelete("", FuncionariosHandlers.DeleteFuncionarioAsync);
        }

        public static void CalcularGastosEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            var gastosEndpoints = endpointRouteBuilder.MapGroup("/gastos-mensais");
            var gastosComIdEndpoints = gastosEndpoints.MapGroup("/{funcionarioId:int}");

            gastosComIdEndpoints.MapGet("", CaluleGastosHandlers.CalcularGastosMensaisAsync);
        }
    }
}
