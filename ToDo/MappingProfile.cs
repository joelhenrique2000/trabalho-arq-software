using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.ViewModels;
using Api.Models;

namespace todo {
    public class MappingProfile : Profile {
        public MappingProfile() {
            CreateMap<Grupo, AdicionarGrupoViewModel>();
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
        }
    }
}
