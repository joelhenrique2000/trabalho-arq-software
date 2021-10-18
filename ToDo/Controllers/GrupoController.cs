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
    public class GrupoController : Controller {
        private readonly ILogger<HomeController> _logger;
       private readonly IMapper _mapper;
        private GrupoService _grupoService;
        private AtividadeService _atividadeService;

        public GrupoController(ILogger<HomeController> logger, IMapper mapper) {
            _logger = logger;
            _mapper = mapper;
            _grupoService = new GrupoService();
            _atividadeService = new AtividadeService();
        }

        public async Task<IActionResult> IndexAsync() {
            var grupos = await _grupoService.Get();
            var view = new ObterGrupoViewModel {
                grupos = grupos
            };

            return View(view);
        }

        
         [HttpGet]
        public async Task<IActionResult> CriarAsync() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync(AdicionarGrupoViewModel dto) {
            if (ModelState.IsValid) {

                var grupo = _mapper.Map<Grupo>(dto);
                await _grupoService.Create(grupo);

                return RedirectToAction("Index");
            }
            else {
                return View();
            }
        }

        public async Task<IActionResult> RemoverAsync(Guid id) {
            await _grupoService.Delete(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditarAsync(Guid id) {
            Grupo grupo = (await _grupoService.GetById(id));
            var grupoDTO = _mapper.Map<AtualizarGrupoViewModel>(grupo);

            return View("Editar", grupoDTO);
        }
   
      [HttpPost]
      public async Task<IActionResult> EditarAsync(AtualizarGrupoViewModel dto) {
          var grupo = _mapper.Map<Grupo>(dto);

          if (ModelState.IsValid) {
                await _grupoService.Update(grupo);
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
