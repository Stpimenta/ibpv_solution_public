using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IbpvDtos;
using IbpvFrontend.src.Provider.interfaces;
using IbpvFrontend.src.Services;

namespace IbpvFrontend.src.Provider
{
    public class providerCaixa : IProviderCaixa
    {
        

       private readonly CostumerHttpCLient _costumerHttpCLient;

        public providerCaixa(CostumerHttpCLient costumerHttpCLient)
        {
            _costumerHttpCLient = costumerHttpCLient;
        }
        
        public async Task<int> addCaixa(CaixaDTO caixa)
        {
            await _costumerHttpCLient.configureHeaders();
            var response = await _costumerHttpCLient.PostAsJsonAsync("/api/Caixa",caixa);

            if(response.IsSuccessStatusCode)
            {
                return int.Parse(await response.Content.ReadAsStringAsync());
            }

            else
            {
                throw new Exception("error ao adicionar caixa");
            }
        }

        public async Task<bool> deleteCaixa(int id)
        {
            await _costumerHttpCLient.configureHeaders();
            var response = await _costumerHttpCLient.DeleteAsync($"/api/Caixa/{id}");

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
             

            else
            {
                throw new Exception("error ao remover caixas");
            }  
        }    

        public async Task<List<CaixaDTO>> getCaixa()
        {
             await _costumerHttpCLient.configureHeaders();
             try
             {
                var response = await _costumerHttpCLient.GetAsync("/api/Caixa");

                if(response.IsSuccessStatusCode)
                {
                    var deserializedObject = await response.Content.ReadFromJsonAsync<List<CaixaDTO>>();
                    return deserializedObject!;
                }
                else
                {
                    // Capturar exceção específica para tratamento personalizado
                    throw new HttpRequestException($"Falha na requisição: {response.StatusCode}");
                }
             }
             catch(HttpRequestException ex)
             {
                // Logging de erro ou tratamento adicional de exceção
                Console.WriteLine($"Erro ao acessar a API de caixas: {ex.Message}");
                throw; // Re-lança a exceção para tratamento superior
             }
             catch(Exception ex)
             {
                // Exceção geral
                Console.WriteLine($"Erro inesperado ao acessar a API de caixas: {ex.Message}");
                throw; // Re-lança a exceção para tratamento superior
             }
        
        }

     
    }
}