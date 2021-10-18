using RepositoryHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    [Table("Atividade")]
    public class Atividade
    {

        [PrimaryKey]
        public Guid CodAtividade { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório")]
        public string Descricao { get; set; }
        public Guid CodGrupo { get; set; }
        [DapperIgnore]
        public virtual string? TituloGrupo { get; set; }
    }
}
