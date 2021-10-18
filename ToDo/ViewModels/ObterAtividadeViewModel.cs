using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace ToDo.ViewModels {
    public class ObterAtividadeViewModel {
        public Guid CodAtividade { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid? CodGrupo { get; set; }
        public string? TituloGrupo { get; set; }
    }
}
