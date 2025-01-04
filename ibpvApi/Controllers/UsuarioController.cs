
using AutoMapper;
using IbpvDtos;
using c___Api_Example.Application.Services.UserCryptography;
using c___Api_Example.Models;
using c___Api_Example.repository.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; //mvc para model view controller
namespace c___Api_Example.Controllers
{   
    /*
    o que está entre chaves dentro da classe atribui algumas caracteristicas a ela, por exemplo aqui eu indico que essa classe e uma apicontroller,
    e indico que a rota pode ser atribuida pelo mapeador
    */

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsuarioController : ControllerBase //herda controller base para permitir o comportamento de api, rotas mapeadas metodos http etc...
    {
        //repositori database
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ILogger<UsuarioController> _logger;

        //criptografar a senha
        private readonly IServiceUserPassCryptography _serviceUserPassCryptography;
        //criptografar dados sensiveis
        private readonly IDataProtector _dataProtector;
        //mapear os dtos e os models para converter
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepositorio usuarioRepositorio, ILogger<UsuarioController> logger, 
                                 IMapper mapper, IDataProtectionProvider dataProtectionProvider, IServiceUserPassCryptography serviceUserPassCryptography)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _logger = logger;
            _mapper = mapper;
            _serviceUserPassCryptography = serviceUserPassCryptography;
            _dataProtector = dataProtectionProvider.CreateProtector("userCryptography");
        }

        //para usar o log  _logger.LogInformation("bah guri");

        [HttpGet]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task <ActionResult<PaginetedResultDTO<UsuarioPagDTO>>> GetAllUser(int page, int itensQuantity, string? nome, string? token)
        {
            //dto rustico
            PaginetedResultDTO<UsuarioPagDTO> usuarios = await _usuarioRepositorio.GetPagUsers(page,itensQuantity,nome,token);
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task <ActionResult<UsuarioGetByIdDTO>> GetUserById(int id)
        {
            //dto moderno
            UsuarioModel? usuario = await _usuarioRepositorio.GetUserById(id);
            var usuarioDto = _mapper.Map<UsuarioGetByIdDTO>(usuario);
            //refatorar a cryptografia para um serviço
            if(usuario is not null)
            {   
                if(usuarioDto.Cpf is not null)
                {
                    usuarioDto.Cpf = _dataProtector.Unprotect(usuarioDto.Cpf);
                }
               
                if(usuarioDto.RGnumero is not null)
                {
                    usuarioDto.RGnumero = _dataProtector.Unprotect(usuarioDto.RGnumero);
                }
                usuarioDto.CepEndereco = _dataProtector.Unprotect(usuarioDto.CepEndereco);
                usuarioDto.RuaEdereco = _dataProtector.Unprotect(usuarioDto.RuaEdereco);
                usuarioDto.NumeroEndereco = _dataProtector.Unprotect(usuarioDto.NumeroEndereco);
                return Ok(usuarioDto);
            }
            return NotFound();
        }

        [HttpPost]
        /*ActionResult é um tipo de retorno para métodos de ação em controladores ASP.NET Core que encapsula o resultado de uma solicitação HTTP*/
        public async Task<ActionResult<int>> CreateUser([FromBody]UsuarioPostDTO user)
        {
            
            // //var validationResult = _validator.Validate(user);

            // if(validationResult.IsValid)
            // {
            //     return BadRequest(validationResult.Errors);
            // }

            user.Data_nascimento = DateTime.SpecifyKind((DateTime)user.Data_nascimento, DateTimeKind.Utc);
            if (user.dataBatismo.HasValue)
            {
                user.dataBatismo = DateTime.SpecifyKind((DateTime)user.dataBatismo, DateTimeKind.Utc);
            }
            
            //data protector é a  criptografia
            if(!string.IsNullOrEmpty(user.Cpf))
            {
                user.Cpf = _dataProtector.Protect(user.Cpf);
            }
            
            if(!string.IsNullOrEmpty(user.RGnumero))
            {
                user.RGnumero = _dataProtector.Protect(user.RGnumero!);
            }
            
            user.CepEndereco = _dataProtector.Protect(user.CepEndereco!);
            user.RuaEdereco = _dataProtector.Protect(user.RuaEdereco!);
            user.NumeroEndereco = _dataProtector.Protect(user.NumeroEndereco!);
            user.Senha  = _serviceUserPassCryptography.encryptPassUser(user.Senha!);

            //mapeia a dto e devolve um model
            var modelUser = _mapper.Map<UsuarioModel>(user);
            //pega o id
            int id = await _usuarioRepositorio.AddUser(modelUser);
            //retorna o id
            return Ok(id);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<bool>> UpdateByid(int id,[FromBody]UsuarioPutDTO user)
        {
            bool usuario = await _usuarioRepositorio.UpdateUser(id,user);
            return Ok(usuario);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<bool>> DeleteById(int id)
        {
            bool usuario = await _usuarioRepositorio.DeleteUserById(id);
            return Ok(usuario);
        }
    }
    
}