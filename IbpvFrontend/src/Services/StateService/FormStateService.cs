using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;

namespace IbpvFrontend.src.Services.StateService
{
    public class FormStateService
    {
        public UsuarioPostDTO usuarioPostForm {get; set;} = new UsuarioPostDTO();
        public NavStateService navStateService { get; set; } = new();
    }
}