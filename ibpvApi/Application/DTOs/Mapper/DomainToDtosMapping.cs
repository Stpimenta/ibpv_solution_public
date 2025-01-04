using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IbpvDtos;
using c___Api_Example.Models;

namespace c___Api_Example.Application.Mapper
{
    public class DomainToDtosMapping : Profile
    {
        public DomainToDtosMapping()
        {

            /*se tiver atributos com nomes diferentes tem que dar mais uns comandos.
            reateMap<UsuarioModel, UsuarioGetByIdDTO>() .ForMember(dest => dest.Contribuicao, opt => opt.MapFrom(src => src.TokenContribuicao));*/
            
            CreateMap<UsuarioModel,UsuarioGetByIdDTO>(); 
            CreateMap<UsuarioPostDTO,UsuarioModel>();

            CreateMap<CaixaModel,CaixaDTO>();
            CreateMap<CaixaDTO,CaixaModel>();

            CreateMap<DtoGastoPost,GastoModel>();
            //se precisar mapear um filho como model caixa nome usa for path, neste caso estamos mapeando para dto caixa entao nao precisa
            CreateMap<GastoModel, GastoPagDTO>()
            .ForMember(dto => dto.Caixa, opt => opt.MapFrom(model => model.Caixa!.Nome));

            CreateMap<ContribuicaoPostDTO,ContribuicaoModel>();

            CreateMap<ContribuicaoModel,ContribuicaoPagDTO>()
            .ForMember(dto => dto.Caixa, opt => opt.MapFrom(model => model.Caixa!.Nome))
            .ForMember(dto => dto.TokenMembro, opt => opt.MapFrom(model => model.Membro == null? null : model.Membro.TokenContribuicao));
        }
    }
}