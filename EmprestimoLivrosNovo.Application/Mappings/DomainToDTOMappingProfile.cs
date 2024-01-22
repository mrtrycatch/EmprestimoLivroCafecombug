using AutoMapper;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.Entities;
using EmprestimoLivrosNovo.Domain.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprestimoLivrosNovo.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile() {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
            CreateMap<Usuario, UsuarioPutDTO>().ReverseMap();
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<EmprestimoDTO, Emprestimo>().ReverseMap()
                .ForMember(dest => dest.ClienteDTO, opt => opt.MapFrom(x => x.Cliente));
            CreateMap<Emprestimo, EmprestimoPostDTO>().ReverseMap();
            CreateMap<QuantidadeItens, QuantidadeItensDTO>().ReverseMap();
            CreateMap<LivroEmprestado, LivroEmprestadoDTO>().ReverseMap()
                .ForMember(dest => dest.Livro, opt => opt.MapFrom(x => x.Livro));
        }
    }
}
