using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using IbpvFrontend.src.Provider.interfaces;
using IbpvFrontend.src.Services;

namespace IbpvFrontend.src.Provider
{
    public class ProviderGasto : IProviderGasto
    {
        readonly private CostumerHttpCLient _costumerHttpClient;

        public ProviderGasto(CostumerHttpCLient constumerHttpClient)
        {
            _costumerHttpClient = constumerHttpClient;
        }

        public async Task<int> addGasto(DtoGastoPost dtoGasto)
        {
            await _costumerHttpClient.configureHeaders();
            var response = await _costumerHttpClient.PostAsJsonAsync("/api/Gasto",dtoGasto);

            if(response.IsSuccessStatusCode)
            {
                return int.Parse(await response.Content.ReadAsStringAsync());
            }

            else
            {
                throw new Exception("error adicionar gasto");
            }
        }

        public async Task<PaginetedResultDTO<GastoPagDTO>> getPageGastos(int pageNumber, int pageQuantity,int? idCaixa = null, string? descricao = null,  DateTime? initialDate = null, DateTime? finalDate = null)
        {
            await _costumerHttpClient.configureHeaders();
            var url = $"/api/Gasto?pageNumber={pageNumber}&pageQuantity={pageQuantity}";
            
            if(!string.IsNullOrEmpty(descricao))
                 url += $"&descricao={descricao}";
            if(initialDate.HasValue)
            {   
                initialDate =  DateTime.SpecifyKind((DateTime)initialDate, DateTimeKind.Utc).Date;
                string formattedDate = initialDate.Value.ToString("yyyy-MM-dd");
                 url += $"&initialDate={formattedDate }";
            }
                
            if(finalDate is not null)
            {
                finalDate =  DateTime.SpecifyKind((DateTime)finalDate, DateTimeKind.Utc).Date;
                string formattedDate = finalDate.Value.ToString("yyyy-MM-dd");
                url += $"&finalDate={formattedDate}";
            }
            if(idCaixa is not null)
                 url += $"&idCaixa={idCaixa}";
                 
            
            var response = await _costumerHttpClient.GetAsync(url);

            if(response.IsSuccessStatusCode)
            {
                  var deserializedObject = await response.Content.ReadFromJsonAsync<PaginetedResultDTO<GastoPagDTO>>();
                  return deserializedObject!;
            }

            else
            {
                throw new Exception("erro adicionar pegar pagina contribuicao");
            }
        }

         public async Task<bool>deleteGasto(int id)
        {
            await _costumerHttpClient.configureHeaders();
            var url = $"/api/Gasto/{id}";
            
            
            var response = await _costumerHttpClient.DeleteAsync(url);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }

            else
            {
                throw new Exception("erro ao remover gasto");
            }
        }
    }
}