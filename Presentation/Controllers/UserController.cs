using AppCore.DTO;
using AppCore.Entities;
using AppCore.Interface.Services;
using AppCore.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _user;
        private readonly IMapper _mapper;

        public UserController(IUserService user, IMapper mapper)
        {
            _user = user;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Auth")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] AuthUserModel model)
        {

            // Recupera o usuário
            var user = await _user.Auth(model.Email, model.Password);

            // Verifica se o usuário existe
            if (user.Value == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenConfig.GenerateToken(user.Value);

            // Oculta a senha
            user.Value.Password = "";

            // Retorna os dados
            return new
            {
                user = user.Value,
                token
            };
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            // Recupera o usuário
            var users = await _user.GetAll();

            // Verifica se o usuário existe
            if (users.Value == null)
                return NotFound(new { message = "Usuários não localizados" });

            return new
            {
                users = _mapper.Map<List<UserViewModel>>(users.Value)
            };
        }

        //[HttpPost("{id}")]
        [HttpPost]
        [Route("Get")]
        public async Task<ActionResult<dynamic>> Get(string id)
        {
            // Recupera o usuário
            var user = await _user.Get(id);

            // Verifica se o usuário existe
            if (user.Value == null)
                return NotFound(new { message = "Usuários não localizados" });

            return new
            {
                users = _mapper.Map<UserViewModel>(user.Value)
            };
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<dynamic>> Put([FromBody] UserViewModel model )
        {
            var upObjec = _mapper.Map<UserEntity>(model);

            // Recupera o usuário
            var stat = await _user.UpdateAsync(upObjec);

            // Verifica se o usuário existe
            if (!stat.Status)
                return NotFound(new { message = "Usuários não localizados" });
                        
            return new
            {
                users = model
            };
        }
    }
}
