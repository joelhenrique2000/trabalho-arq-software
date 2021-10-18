using Api.Models;
using Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Grupo, ObterGrupoDTO>();
            CreateMap<ObterGrupoDTO, Grupo>();

            CreateMap<Grupo, AtualizarGrupoDTO>();
            CreateMap<AtualizarGrupoDTO, Grupo>();

            CreateMap<Grupo, AdicionarGrupoDTO>();
            CreateMap<AdicionarGrupoDTO, Grupo>();

            CreateMap<Atividade, ObterAtividadeDTO>();
            CreateMap<ObterAtividadeDTO, Atividade>();

            CreateMap<Atividade, AtualizarAtividadeDTO>();
            CreateMap<AtualizarAtividadeDTO, Atividade>();

            CreateMap<Atividade, AdicionarAtividadeDTO>();
            CreateMap<AdicionarAtividadeDTO, Atividade>();
            /*
            CreateMap<Grupo, AtualizarGrupoViewModel>();
            CreateMap<Grupo, ObterGrupoViewModel>();
            CreateMap<Atividade, AdicionarAtividadeViewModel>();
            CreateMap<Atividade, AtualizarAtividadeViewModel>();
            CreateMap<Atividade, ObterAtividadeViewModel>();


            CreateMap<AdicionarGrupoViewModel, Grupo>();
            CreateMap<AtualizarGrupoViewModel, Grupo>();
            CreateMap<ObterGrupoViewModel, Grupo>();
            CreateMap<AdicionarAtividadeViewModel, Atividade>();
            CreateMap<ObterAtividadeViewModel, Atividade>();

            CreateMap<AtualizarAtividadeViewModel, Atividade>()
                .ForMember(dest => dest.CodGrupo,
                map => map.MapFrom(src => src.CodGrupo));
             */
        }
    }
}
