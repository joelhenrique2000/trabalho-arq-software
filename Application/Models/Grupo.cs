using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models {
    [Table("Grupo")]
    public class Grupo
    {

        [PrimaryKey]
        public Guid CodGrupo { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }

    }
}
