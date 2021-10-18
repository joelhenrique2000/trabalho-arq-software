using Api.Models;
using Api.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Business {
    public class AtividadeBusiness {
        private readonly AtividadeRepository atividadeRepository;
        private readonly IMapper _mapper;

        public AtividadeBusiness(IMapper mapper) {
            atividadeRepository = new AtividadeRepository();
            _mapper = mapper;
        }

        public IEnumerable<Atividade> GetAll() {
            return atividadeRepository.GetAll();
        }

        public Atividade GetById(Guid id) {
            return atividadeRepository.GetById(id);
        }

        public Atividade Create(Atividade atividade) {
            atividade.CodAtividade = Guid.NewGuid();
            var grupoRepository = new GrupoRepository();

            var atividadeCriada = atividadeRepository.Criar(atividade);

            atividadeCriada.TituloGrupo = grupoRepository.GetById(atividadeCriada.CodGrupo).Titulo;

            return atividadeCriada;
        }

        public int Update(Atividade atividade) {
            atividadeRepository.Atualizar(atividade);
            return 1;
        }

        public int Remove(Guid id) {
            atividadeRepository.Remover(id);
            return 1;
        }
    }
}
