using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace ToDo.ViewModels {
    public class ObterGrupoViewModel {
        public IEnumerable<Grupo> grupos { get; set; }
    }
}
