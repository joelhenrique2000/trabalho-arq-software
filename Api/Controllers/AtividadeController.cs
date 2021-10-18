using Api.Business;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;

namespace Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AtividadeController : ControllerBase {
        private readonly IMapper _mapper;

        public AtividadeController(IMapper mapper) {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ObterAtividadeDTO> Obter() {
            var business = new AtividadeBusiness(_mapper);
            var grupos = business.GetAll();

            return _mapper.Map<IEnumerable<ObterAtividadeDTO>>(grupos);
        }

        [HttpGet("{id}")]
        public ObterAtividadeDTO ObterPorId(Guid id) {
            var business = new AtividadeBusiness(_mapper);
            var grupo = business.GetById(id);

            return _mapper.Map<ObterAtividadeDTO>(grupo);
        }

        [HttpPut]
        public ObterAtividadeDTO Atualizar(AtualizarAtividadeDTO dto) {
            var business = new AtividadeBusiness(_mapper);

            business.Update(_mapper.Map<Atividade>(dto));

            return _mapper.Map<ObterAtividadeDTO>(business.GetById(dto.CodAtividade));
        }

        [HttpPost]
        public ObterAtividadeDTO Adicionar(AdicionarAtividadeDTO dto) {
            var business = new AtividadeBusiness(_mapper);

            var atividade  = business.Create(_mapper.Map<Atividade>(dto));

            return _mapper.Map<ObterAtividadeDTO>(atividade);
        }

        [HttpDelete("{id}")]
        public Boolean Remover(Guid id) {
            var business = new AtividadeBusiness(_mapper);
            business.Remove(id);

            return true;
        }
    }
}
