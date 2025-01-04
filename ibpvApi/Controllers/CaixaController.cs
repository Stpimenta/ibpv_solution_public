using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IbpvDtos;
using c___Api_Example.Models;
using c___Api_Example.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace c___Api_Example.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   [Authorize]
   public class CaixaController : ControllerBase
   {
        readonly private ICaixaRepositorio _caixaRepositorio;
        readonly private IMapper _mapper;
        public CaixaController(ICaixaRepositorio caixaRepositorio, IMapper mapper)
        {
            _caixaRepositorio = caixaRepositorio;
            _mapper = mapper;
        }

      

        [HttpGet]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task <ActionResult<List<CaixaDTO>>> GetAllcaixas()
        {
            List<CaixaModel> caixas = await _caixaRepositorio.GetAllCaixas();
            var caixasdto = _mapper.Map<List<CaixaDTO>>(caixas);
            return Ok(caixasdto);
        }

        [HttpPost]

        public async Task <ActionResult<int>> CreateCaixa([FromBody] CaixaDTO caixa)
        {
            var  caixaModel = _mapper.Map<CaixaModel>(caixa);
            int id = await _caixaRepositorio.AddCaixa(caixaModel);
            return Ok(id);
        }

        [HttpDelete ("{id:int}")]

        public async Task<ActionResult> deleteCaixa(int id)
        {

            if( await _caixaRepositorio.DeleteCaixa(id))
            {
                return Ok();
            }
            return StatusCode(500);
        }
     
   }
}