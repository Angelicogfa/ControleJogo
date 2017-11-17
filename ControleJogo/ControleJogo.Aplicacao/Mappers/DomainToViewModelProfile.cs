using AutoMapper;
using ControleJogo.Aplicacao.InputModel;
using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Jogos.Entities;

namespace ControleJogo.Aplicacao.Mappers
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            Configure();
        }

        private void Configure()
        {
            CreateMap<Amigo, AmigoViewModel>()
                .ForMember(t => t.Estado, opt => opt.MapFrom(t => t.Logradouro.Estado))
                .ForMember(t => t.CEP, opt => opt.MapFrom(t => t.Logradouro.CEP))
                .ForMember(t => t.Bairro, opt => opt.MapFrom(t => t.Logradouro.Bairro))
                .ForMember(t => t.Endereco, opt => opt.MapFrom(t => t.Logradouro.Endereco))
                .ForMember(t => t.Numero, opt => opt.MapFrom(t => t.Logradouro.Numero))
                .ForMember(t => t.Complemento, opt => opt.MapFrom(t => t.Logradouro.Complemento)).ReverseMap();

            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
            CreateMap<Console, ConsoleViewModel>().ReverseMap();
            CreateMap<Jogo, JogoViewModel>().ReverseMap();
        }
    }
}
