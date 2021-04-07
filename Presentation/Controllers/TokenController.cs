using AppCore.Entities;
using AppCore.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenUser;

        public TokenController(ITokenService tokenUser)
        {
            _tokenUser = tokenUser;
        }       

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserTokenEntity model)
        {
            // Recupera o usuário
            var user = await _tokenUser.Get(model.nome, model.password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user.Value);

            // Oculta a senha
            user.Value.password = "";

            // Retorna os dados
            return new
            {
                user = user.Value,
                token = token
            };
        }

    }
}
