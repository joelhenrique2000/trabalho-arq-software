using Api.Models;
using Api.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business {
    public class GrupoBusiness {
        private readonly GrupoRepository grupoRepository;
        private readonly IMapper _mapper;

        public GrupoBusiness(IMapper mapper) {
            grupoRepository = new GrupoRepository();
            _mapper = mapper;
        }

        public IEnumerable<Grupo> GetAll() {
            return grupoRepository.GetAll();
        }

        public Grupo GetById(Guid id) {
            return grupoRepository.GetById(id);
        }

        public Grupo Create(Grupo grupo) {
            grupo.CodGrupo = Guid.NewGuid();

            return grupoRepository.Criar(grupo);
        }

        public int Update(Grupo grupo) {
            grupoRepository.Atualizar(grupo);
            return 1;
        }

        public int Remove(Guid id) {
            grupoRepository.Remover(id);
            return 1;
        }
    }
}
