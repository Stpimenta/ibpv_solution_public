using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;

namespace IbpvFrontend.src.Provider.interfaces
{
    public interface IProviderMembro
    {
        public  Task<PaginetedResultDTO<UsuarioPagDTO>> getPageUsuario(int page, int itensQuantity, string? nome=null, string? token=null);
        public Task<int> AddUsuario (UsuarioPostDTO usuario);
        public Task deleteUsuario(int id);
    }
}