using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using c___Api_Example.Models;

namespace c___Api_Example.Domain.Models
{
    public class DesligamentoModel
    {   public int id{get; set;}
        public DateTime data {get; set;}
        public string? descricao {get; set;}
        public int idMembro {get; set;}
        public UsuarioModel? membro {get; set;}
    }
}