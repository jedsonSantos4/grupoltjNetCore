using AppCore.Entities;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using System;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IUserTokenRepository _tokebRepo;
        public TokenService(IUserTokenRepository tokebRepo)
        {
            _tokebRepo = tokebRepo;
        }

        public async Task<ValidResult<UserTokenEntity>> Get(string nome, string password)
        {
            var result = new ValidResult<UserTokenEntity>();
            try
            {
                result.Value = await _tokebRepo.Get(nome,password);
                result.Status = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
       
        public async Task<ValidResult<bool>> DeleteAsync(string id)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _tokebRepo.DeleteAsync(id);
                result.Status = true;
                result.Value = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<bool>> InsertAsync(UserTokenEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _tokebRepo.InsertAsync(obj);
                result.Status = true;
                result.Value = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<bool>> UpdateAsync(UserTokenEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _tokebRepo.UpdateAsync(obj);
                result.Status = true;
                result.Value = true;
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
