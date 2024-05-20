using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using ValeControl.API.DbContexts;
using ValeControl.API.Entities;
using ValeControl.API.Models;

namespace ValeControl.API.EndpointHandlers
{
    public static class CaluleGastosHandlers
    {
        public static async Task<Results<NotFound, Ok<GastosMensaisDTO>>> CalcularGastosMensaisAsync(
            ValeDbContext valeDbContext,
            IMapper mapper,
            int funcionarioId)
        {
            var funcionarioEntity = await valeDbContext.Funcionarios.FindAsync(funcionarioId);

            if (funcionarioEntity == null)
            {
                return TypedResults.NotFound();
            }

            var dataAtual = DateTime.Now;
            var ultimoDiaMes = new DateTime(dataAtual.Year, dataAtual.Month, DateTime.DaysInMonth(dataAtual.Year, dataAtual.Month));
            var diasUteis = Enumerable.Range(1, ultimoDiaMes.Day)
                .Select(day => new DateTime(dataAtual.Year, dataAtual.Month, day))
                .Count(day => day.DayOfWeek != DayOfWeek.Saturday && day.DayOfWeek != DayOfWeek.Sunday);

            decimal custoMensalFuncionario = 0;
            switch (funcionarioEntity.Escala)
            {
                case EscalaTrabalho.CincoxDois:
                    custoMensalFuncionario = funcionarioEntity.CustoDiario * 5 * (diasUteis / 7);
                    break;
                case EscalaTrabalho.SeisxUm:
                    custoMensalFuncionario = funcionarioEntity.CustoDiario * (diasUteis / 7);
                    break;
                case EscalaTrabalho.SeisxDois:
                    custoMensalFuncionario = funcionarioEntity.CustoDiario * (diasUteis / 7) * 2;
                    break;
                case EscalaTrabalho.DozeTrintaSeis:
                    custoMensalFuncionario = funcionarioEntity.CustoDiario * 12;
                    break;
                default:
                    break;
            }

            var gastosMensaisDTO = new GastosMensaisDTO
            {
                Id = funcionarioEntity.Id,
                Nome = funcionarioEntity.Nome,
                Escala = funcionarioEntity.Escala.ToString(),
                CustoDiario = funcionarioEntity.CustoDiario,
                Ativo = funcionarioEntity.Ativo,
                CustoTotal = custoMensalFuncionario
            };

            return TypedResults.Ok(gastosMensaisDTO);
        }
    }
}
