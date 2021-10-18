using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.ViewModels {
    public class AtualizarGrupoViewModel {
        public Guid CodGrupo { get; set; }
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }
    }
}
