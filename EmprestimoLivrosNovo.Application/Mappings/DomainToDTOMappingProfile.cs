using AutoMapper;
using EmprestimoLivrosNovo.Application.DTOs;
using EmprestimoLivrosNovo.Domain.Entities;
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
            CreateMap<Livro, LivroDTO>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoDTO>().ReverseMap()
                .ForMember(dest => dest.Livro, opt => opt.MapFrom(x => x.LivroDTO))
                .ForMember(dest => dest.Cliente, opt => opt.MapFrom(x => x.ClienteDTO));
        }
    }
}
