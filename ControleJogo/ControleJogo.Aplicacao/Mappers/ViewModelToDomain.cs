using AutoMapper;
using ControleJogo.Aplicacao.Mappers.Configure;
using ControleJogo.Aplicacao.ViewModels;
using ControleJogo.Dominio.Amigos.Entities;

namespace ControleJogo.Aplicacao.Mappers
{
    public class ViewModelToDomain : Profile
    {
        public ViewModelToDomain()
        {
            Configure();
        }

        private void Configure()
        {
            CreateMap<AmigoViewModel, Amigo>().ForMember(t => t.Logradouro, opt => opt.ResolveUsing<LogradouroResolver>());
        }
    }
}
