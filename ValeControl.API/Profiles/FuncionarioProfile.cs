using AutoMapper;
using ValeControl.API.Entities;
using ValeControl.API.Models;

namespace ValeControl.API.Profiles;

public class FuncionarioProfile : Profile
{
    public FuncionarioProfile() {
        CreateMap<Funcionario, FuncionarioDTO>().ReverseMap();
        CreateMap<Funcionario, FuncionarioParaCriacaoDTO>().ReverseMap();
        CreateMap<Funcionario, FuncionarioParaAtualizacaoDTO>().ReverseMap();
    }
}
