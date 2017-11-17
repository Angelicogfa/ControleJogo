using AutoMapper;
using ControleJogo.Aplicacao.InputModel;
using ControleJogo.Dominio.Amigos.Entities;
using ControleJogo.Dominio.Amigos.ObejctValues;
using System;

namespace ControleJogo.Aplicacao.Mappers.Configure
{
    public class LogradouroResolver : IValueResolver<AmigoViewModel, Amigo, Logradouro>
    {
        public Logradouro Resolve(AmigoViewModel source, Amigo destination, Logradouro destMember, ResolutionContext context)
        {
            destMember = new Logradouro((Dominio.Amigos.ObejctValues.Estado)Enum.ToObject(typeof(Dominio.Amigos.ObejctValues.Estado),
                (int) source.Estado), source.CEP, source.Bairro, source.Endereco, source.Numero, source.Complemento);
            return destMember;
        }
    }
}
