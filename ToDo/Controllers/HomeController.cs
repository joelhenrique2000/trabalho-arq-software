using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Models;
using ToDo.Services;
using ToDo.ViewModels;

namespace ToDo.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
       private readonly IMapper _mapper;
        private GrupoService _grupoService;
        private AtividadeService _atividadeService;

        public HomeController(ILogger<HomeController> logger, IMapper mapper) {
            _logger = logger;
            _mapper = mapper;
            _grupoService = new GrupoService();
            _atividadeService = new AtividadeService();
        }

        public async Task<IActionResult> IndexAsync() {
            var atividades = await _atividadeService.Get();
           var atividadeViewModel = _mapper.Map<IEnumerable<ObterAtividadeViewModel>>(atividades);
            return View(atividadeViewModel);
        }

        
         [HttpGet]
        public async Task<IActionResult> CriarAsync() {

            var grupos = await _grupoService.Get();
;
            return View(new AdicionarAtividadeViewModel() {
                grupos = grupos
            });
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync(AdicionarAtividadeViewModel dto) {
            if (ModelState.IsValid) {

                var atividade = _mapper.Map<Atividade>(dto);
                await _atividadeService.Create(atividade);

                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }

        public async Task<IActionResult> RemoverAsync(Guid id) {
            await _atividadeService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditarAsync(Guid id) {
            Atividade atividade = (await _atividadeService.GetById(id));
            var grupos = await _grupoService.Get();


            var viewModel = new AtualizarAtividadeViewModel {
                CodAtividade = atividade.CodAtividade,
                Titulo = atividade.Titulo,
                grupos = grupos,
                Descricao = atividade.Descricao,
            };

            if (atividade.CodGrupo != null) {
                viewModel.CodGrupo = atividade.CodGrupo;
            }

            return View("Editar", viewModel);
        }
   
      [HttpPost]
      public async Task<IActionResult> EditarAsync(AtualizarAtividadeViewModel dto) {
          var atividade = _mapper.Map<Atividade>(dto);

          if (ModelState.IsValid) {
                await _atividadeService.Update(atividade);
            }
          else {
          return View();
          }

          return RedirectToAction("Index");
        }
    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
