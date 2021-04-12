using AppCore.DTO;
using AppCore.Entities;
using AppCore.Interface.Services;
using AppCore.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
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
        [Route("List")]
        public async Task<ActionResult<dynamic>> Users()
        {

            // Recupera o usuário
            var users = await _user.GetAll();

            // Verifica se o usuário existe
            if (users.Value == null)
                return NotFound(new { message = "Usuários não localizados" });

           
                var maps = _mapper.Map<List<UserViewModel>>(users.Value);
            
                return new
                {
                    user = maps
                };
        }


    }
}
