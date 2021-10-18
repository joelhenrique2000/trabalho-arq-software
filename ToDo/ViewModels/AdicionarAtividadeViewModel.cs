using Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace ToDo.ViewModels {
    public class AdicionarAtividadeViewModel {
        [Required(ErrorMessage = "O Título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O codGrupo é obrigatório")]
        public Guid? CodGrupo { get; set; }
        public IEnumerable<Grupo> grupos { get; set; }

    }
}
