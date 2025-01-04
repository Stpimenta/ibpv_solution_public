using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using c___Api_Example.Models;

namespace c___Api_Example.repository.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<PaginetedResultDTO<UsuarioPagDTO>> GetPagUsers(int pageNumber, int pageQuantity, string? name, string? token);
        Task<UsuarioModel?> GetUserById(int id);
        Task<bool> DeleteUserById(int id);
        Task<bool> UpdateUser(int id, UsuarioPutDTO  userUpdate);
        Task<int> AddUser(UsuarioModel user);
        Task<UsuarioModel?> GetUserByGmail(string gmail);
    }
}