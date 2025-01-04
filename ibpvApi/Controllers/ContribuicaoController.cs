
using AutoMapper;
using IbpvDtos;
using c___Api_Example.Models;
using c___Api_Example.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace c___Api_Example.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ContribuicaoController : ControllerBase
    {
        readonly private IContribuicaoRepositorio _contribuicaoRepositorio;
        readonly private IMapper _mapper;
        public ContribuicaoController(IContribuicaoRepositorio contribuicaoRepositorio, IMapper mapper)
        {
            _contribuicaoRepositorio = contribuicaoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task <ActionResult<PaginetedResultDTO<ContribuicaoPagDTO>>> getAllUser(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            if(initialDate is not null)
            {
                initialDate = DateTime.SpecifyKind((DateTime)initialDate, DateTimeKind.Utc);
            }

            if(finalDate is not null)
            {
                finalDate = DateTime.SpecifyKind((DateTime)finalDate, DateTimeKind.Utc);
            }

            PaginetedResultDTO<ContribuicaoModel> contribuicaoModel = await _contribuicaoRepositorio.GetPagContribuicoes(pageNumber,pageQuantity,descricao,idCaixa,initialDate,finalDate);
           
           
            var contribuicaoDTO = _mapper.Map<List<ContribuicaoPagDTO>>(contribuicaoModel.items);
            PaginetedResultDTO<ContribuicaoPagDTO> PaginetedContribuicaoDTO = new PaginetedResultDTO<ContribuicaoPagDTO>{items = contribuicaoDTO, pages = contribuicaoModel.pages};
            
            return Ok(PaginetedContribuicaoDTO);
        }


        [HttpPost]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task <ActionResult<int>> createContribuicao([FromBody] ContribuicaoPostDTO contribuicao)
        {
            if (contribuicao.Data.HasValue)
            {
                contribuicao.Data = DateTime.SpecifyKind((DateTime)contribuicao.Data, DateTimeKind.Utc);
                contribuicao.Data = contribuicao.Data.Value;
                var contribuicaoModel = _mapper.Map<ContribuicaoModel>(contribuicao);
                int idContribruicao = await _contribuicaoRepositorio.AddContribuicao(contribuicaoModel);
                return Ok(idContribruicao);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("{id:int}")]
        public async Task <ActionResult> DeleteGasto(int id)
        {

            if( await _contribuicaoRepositorio.DeleteContribuicao(id))
            {
                return Ok();
            }
            return StatusCode(500);
            
        }
    }
}