using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Application;

namespace ToDo.ViewModels {
    public class AtualizarAtividadeViewModel {
        public Guid CodAtividade { get; set; }
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }
        public Guid? CodGrupo { get; set; }
        public IEnumerable<Grupo> grupos { get; set; }
    }
}
