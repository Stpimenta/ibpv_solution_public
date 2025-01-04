using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using IbpvFrontend.src.Provider.interfaces;
using IbpvFrontend.src.Services;

namespace IbpvFrontend.src.Provider
{
    public class ProviderUsuario : IProviderMembro
    {
        readonly private CostumerHttpCLient _costumerHttpClient;

        public ProviderUsuario(CostumerHttpCLient costumerHttpCLient)
        {
            _costumerHttpClient = costumerHttpCLient;
        }

        public async Task<int> AddUsuario(UsuarioPostDTO usuario)
        {
            await _costumerHttpClient.configureHeaders();
            var response = await _costumerHttpClient.PostAsJsonAsync("/api/Usuario",usuario);

            if(response.IsSuccessStatusCode)
            {
                return int.Parse(await response.Content.ReadAsStringAsync());
            }

            else
            {
                throw new Exception("error adicionar usuario");
            }
        }

        public async Task<PaginetedResultDTO<UsuarioPagDTO>> getPageUsuario(int page, int itensQuantity, string? nome=null, string? token=null)
        {
            await _costumerHttpClient.configureHeaders();
            var url = $"/api/Usuario?page={page}&itensQuantity={itensQuantity}";
            
            
            if(!string.IsNullOrEmpty(nome))
                 url += $"&nome={nome}";
            if(!string.IsNullOrEmpty(token))
                 url += $"&token={token}";
            
            var response = await _costumerHttpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                  var deserializedObject = await response.Content.ReadFromJsonAsync<PaginetedResultDTO<UsuarioPagDTO>>();
                  return deserializedObject!;
            }

            else
            {
                throw new Exception("erro adicionar pegar pagina contribuicao");
            }
           
        }

        public async Task deleteUsuario(int id)
        {
            await _costumerHttpClient.configureHeaders();
            var response = await _costumerHttpClient.DeleteAsync($"/api/Usuario/{id}");

            if(response.IsSuccessStatusCode)
            {
    
            }

            else
            {
                throw new Exception("error adicionar usuario");
            }
        }

        

    }
}