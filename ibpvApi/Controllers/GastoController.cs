using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class GastoController : ControllerBase
    {
        readonly private IGastoRepositorio _gastoRepositorio;
        readonly private IMapper _mapper;

        public GastoController(IGastoRepositorio gastoRepositorio,IMapper mapper)
        {
            _gastoRepositorio = gastoRepositorio;
            _mapper = mapper;
        }

        [HttpGet]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task <ActionResult<PaginetedResultDTO<GastoPagDTO>>> GetPagGastos(int pageNumber, int pageQuantity, string? descricao = null, int? idCaixa = null, DateTime? initialDate = null, DateTime? finalDate = null)
        {
            if(initialDate is not null)
            {
                initialDate =  DateTime.SpecifyKind((DateTime)initialDate, DateTimeKind.Utc).Date;
                    
            }

            if(finalDate is not null)
            {
                finalDate =  DateTime.SpecifyKind((DateTime)finalDate, DateTimeKind.Utc).Date;
            }
         
            PaginetedResultDTO<GastoModel> gastosModel = await _gastoRepositorio.GetPageGastos(pageNumber,pageQuantity,descricao,idCaixa,initialDate,finalDate);
            var gastosDTO = _mapper.Map<List<GastoPagDTO>>(gastosModel.items);
            PaginetedResultDTO<GastoPagDTO> paginetedGastosDTO = new PaginetedResultDTO<GastoPagDTO>{
                items = gastosDTO,
                pages = gastosModel.pages
            };
            return Ok(paginetedGastosDTO);
        }
        
        [HttpPost]
        public async Task <ActionResult<int>> AddGasto([FromBody] DtoGastoPost dtoGasto)
        {
            if (dtoGasto.Data.HasValue)
            {
                //estava tendo problemas com data melhor padronizar o formato
                dtoGasto.Data = DateTime.SpecifyKind((DateTime)dtoGasto.Data, DateTimeKind.Utc);
                dtoGasto.Data = dtoGasto.Data.Value;
                var gastoModel = _mapper.Map<GastoModel>(dtoGasto);
                int idGasto = await _gastoRepositorio.Addgasto(gastoModel);
                return Ok(idGasto);
            }
            else
            {
                return BadRequest();
            }
          
        }

        [HttpDelete("{id:int}")]
        public async Task <ActionResult> DeleteGasto(int id)
        {
            if( await _gastoRepositorio.DeleteGasto(id))
            {
                return Ok();
            }
            return StatusCode(500);
         
        }
    }
}