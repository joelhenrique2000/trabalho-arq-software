using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs {
    public class ObterAtividadeDTO {
        public Guid CodAtividade { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Guid? CodGrupo { get; set; }
        public string? TituloGrupo { get; set; }
    }
}
