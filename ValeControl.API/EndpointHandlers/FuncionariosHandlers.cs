using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ValeControl.API.DbContexts;
using ValeControl.API.Entities;
using ValeControl.API.Models;

namespace ValeControl.API.EndpointHandlers;


public static class FuncionariosHandlers
{
    public static async Task<Results<NoContent, Ok<IEnumerable<FuncionarioDTO>>>> GetFuncionariosAsync
        (ValeDbContext valeDbContext,
        IMapper mapper,
        [FromQuery(Name = "name")]string? funcionarioNome) 
    {
       var funcionarioEntity = await valeDbContext.Funcionarios
                                  .Where(x => funcionarioNome == null || x.Nome.ToLower().Contains(funcionarioNome.ToLower()))
                                  .ToListAsync();
        if (funcionarioEntity.Count <= 0 || funcionarioEntity == null)
            return TypedResults.NoContent();
        else
            return TypedResults.Ok(mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarioEntity));
    }

    public static async Task<Results<NotFound, Ok<FuncionarioDTO>>> GetFuncionarioByIdAsync(
        ValeDbContext valeDbContext,
        IMapper mapper,
        int funcionarioId)
    {
        var funcionarioEntity = await valeDbContext.Funcionarios.FirstOrDefaultAsync(x => x.Id == funcionarioId);

        if (funcionarioEntity == null)
            return TypedResults.NotFound();

        return TypedResults.Ok(mapper.Map<FuncionarioDTO>(
            await valeDbContext.Funcionarios.FirstOrDefaultAsync(x => x.Id == funcionarioId)));
    }

    [HttpPost]
    public static async Task<CreatedAtRoute<FuncionarioDTO>> CreateFuncionarioAsync(
        ValeDbContext valeDbContext,
        IMapper mapper,
        [FromBody] FuncionarioParaCriacaoDTO funcionarioParaCriacaoDTO)
    {
        var rangoEntity = mapper.Map<Funcionario>(funcionarioParaCriacaoDTO);
        valeDbContext.Add(rangoEntity);
        await valeDbContext.SaveChangesAsync();

        var funcionarioToReturn = mapper.Map<FuncionarioDTO>(rangoEntity);

        return TypedResults.CreatedAtRoute(
                            funcionarioToReturn, 
                            "GetFuncionarios", 
                            new { funcionarioId = funcionarioToReturn.Id}
                            );
    }

    [HttpPut("{funcionarioId}")]
    public static async Task<Results<NotFound, Ok>> UpdateFuncionarioAsync(
        ValeDbContext valeDbContext,
        IMapper mapper,
        int funcionarioId,
        [FromBody] FuncionarioParaAtualizacaoDTO funcionarioParaAtualizacaoDTO)
    {
        var funcionarioEntity = await valeDbContext.Funcionarios.FirstOrDefaultAsync(x => x.Id == funcionarioId);

        if (funcionarioEntity == null)
            return TypedResults.NotFound();

        mapper.Map(funcionarioParaAtualizacaoDTO, funcionarioEntity);

        await valeDbContext.SaveChangesAsync();

        return TypedResults.Ok();
    }

    public static async Task<FuncionarioDTO> InativarFuncionarioById(
    ValeDbContext valeDbContext,
    IMapper mapper,
    int funcionarioId)
    {
        var funcionarioEntity = await valeDbContext.Funcionarios.FirstOrDefaultAsync(x => x.Id == funcionarioId);

        if (funcionarioEntity == null)
            return null;

        funcionarioEntity.Ativo = false;

        await valeDbContext.SaveChangesAsync();

        return mapper.Map<FuncionarioDTO>(funcionarioEntity);
    }


    public static async Task<Results<NotFound, NoContent>> DeleteFuncionarioAsync(
        ValeDbContext valeDbContext,
        int funcionarioId)
    {
        var funcionarioEntity = await valeDbContext.Funcionarios.FirstOrDefaultAsync(x => x.Id == funcionarioId);

        if (funcionarioEntity == null)
            return TypedResults.NotFound();

        valeDbContext.Funcionarios.Remove(funcionarioEntity);

        await valeDbContext.SaveChangesAsync();

        return TypedResults.NoContent();

    }
}
