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
    public class GrupoController : ControllerBase {
        private readonly IMapper _mapper;

        public GrupoController(IMapper mapper) {
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ObterGrupoDTO> Obter() {
            GrupoBusiness business = new GrupoBusiness(_mapper);
            var grupos = business.GetAll();

            return _mapper.Map<IEnumerable<ObterGrupoDTO>>(grupos);
        }

        [HttpGet("{id}")]
        public ObterGrupoDTO ObterPorId(Guid id) {
            GrupoBusiness business = new GrupoBusiness(_mapper);
            var grupo = business.GetById(id);

            return _mapper.Map<ObterGrupoDTO>(grupo);
        }

        [HttpPut]
        public ObterGrupoDTO Atualizar(AtualizarGrupoDTO dto) {
            GrupoBusiness business = new GrupoBusiness(_mapper);
            
            business.Update(_mapper.Map<Grupo>(dto));

            return _mapper.Map<ObterGrupoDTO>(business.GetById(dto.CodGrupo));
        }

        [HttpPost]
        public ObterGrupoDTO Adicionar(AdicionarGrupoDTO dto) {
            GrupoBusiness business = new GrupoBusiness(_mapper);

            var grupo = business.Create(_mapper.Map<Grupo>(dto));

            return _mapper.Map<ObterGrupoDTO>(grupo);
        }

        [HttpDelete("{id}")]
        public Boolean Remover(Guid id) {
            GrupoBusiness business = new GrupoBusiness(_mapper);
            business.Remove(id);

            return true;
        }
    }
}
