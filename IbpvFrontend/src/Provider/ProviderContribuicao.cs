using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using IbpvFrontend.src.Provider.interfaces;
using IbpvFrontend.src.Services;

namespace IbpvFrontend.src.Provider
{
    public class ProviderContribuicao : IProviderContribuicao
    {
        readonly private CostumerHttpCLient _costumerHttpClient;
        public ProviderContribuicao(CostumerHttpCLient costumerHttpCLient)
        {
            _costumerHttpClient = costumerHttpCLient;
        }
        public async Task<int> addContribuicao(ContribuicaoPostDTO gasto)
        { 
            await _costumerHttpClient.configureHeaders();
            var response = await _costumerHttpClient.PostAsJsonAsync("/api/Contribuicao",gasto);

            if(response.IsSuccessStatusCode)
            {
                return int.Parse(await response.Content.ReadAsStringAsync());
            }

            else
            {
                throw new Exception("error adicionar contribuicao");
            }
        }

        public async Task<PaginetedResultDTO<ContribuicaoPagDTO>>getPageContribuicao(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            await _costumerHttpClient.configureHeaders();
            var url = $"/api/Contribuicao?pageNumber={pageNumber}&pageQuantity={pageQuantity}";
            
            if(!string.IsNullOrEmpty(descricao))
                 url += $"&descricao={descricao}";
            if (initialDate is not null)
            {
                string formattedDate = initialDate.Value.ToString("yyyy-MM-dd");
                url += $"&initialDate={formattedDate}";
            }

            if (finalDate is not null)
            {
                string formattedDate = finalDate.Value.ToString("yyyy-MM-dd");
                url += $"&finalDate={formattedDate}";
            }
              
            if(idCaixa is not null)
                 url += $"&idCaixa={idCaixa}";
            
            var response = await _costumerHttpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                  var deserializedObject = await response.Content.ReadFromJsonAsync<PaginetedResultDTO<ContribuicaoPagDTO>>();
                  return deserializedObject!;
            }

            else
            {
                throw new Exception("erro adicionar pegar pagina contribuicao");
            }
        }

        public async Task<bool>deleteContribuicao(int id)
        {
            await _costumerHttpClient.configureHeaders();
            var url = $"/api/Contribuicao/{id}";
            
            
            var response = await _costumerHttpClient.DeleteAsync(url);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }

            else
            {
                throw new Exception("erro ao remover contribuição");
            }
        }
    }
}