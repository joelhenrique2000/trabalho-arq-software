using Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ObterGrupoDTO
    {
        public Guid CodGrupo { get; set; }
        public string Titulo { get; set; }
    }
}
