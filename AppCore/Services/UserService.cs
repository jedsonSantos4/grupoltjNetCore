using AppCore.Entities;
using AppCore.Helpers;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using AppCore.validacoes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _useRepo;
        public UserService(IUserRepository tokebRepo)
        {
            _useRepo = tokebRepo;
        }

        public async Task<ValidResult<UserEntity>> Auth(string email, string password)
        {
            var result = new ValidResult<UserEntity>();

            if (!ValidationEmail.IsValidEmail(email))
            {
                result.Message = "Erro: Email type is not valid. Please try again!";
                return result;
            }

            try
            {
                result.Value = await _useRepo.Get(email,password);

                if (result.Value == null )
                {
                    result.Message = "Error: when querying user existence. Please try again!";
                    return result;
                }

                if (!Crypto.IsValid(Crypto.ConvertToDeCrypto(result.Value.Password),password ))
                {
                    result.Message = "Erro: PassWord is not valid. Please try again!";
                    return result;
                }
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
                await _useRepo.DeleteAsync(id);
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

        public async Task<ValidResult<bool>> InsertAsync(UserEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                var users = await GetAll();

                if (users.Value == null || !users.Status)
                {
                    result.Message = "Error: when querying user existence. Please try again!";
                    return result;
                }

                if (!ValidationEmail.IsValidEmail(obj.Email))
                {
                    result.Message = "Erro: Email type is not valid. Please try again!";
                    return result;
                }
                if (ValidationEmail.ExistingEmail(obj.Email, users.Value.Select(p => p.Email)))
                {
                    result.Message = "Erro: Email already has a registration. Please try another email";
                    return result;
                }

                if (string.IsNullOrEmpty(obj.Password))
                {
                    result.Message = "Erro: PassWord cannot be empty. Try again!";
                    return result;
                }
                //if (!CryptoPassWord.IsAlphNumEsp(obj.Password))
                //{
                //    result.Message = "Erro: PassWord is not alphanumeric or has no special character. Try again!";
                //    return result;
                //}

                obj.Password = Crypto.ConvertToCrypto(obj.Password);

                await _useRepo.InsertAsync(obj);
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

        public async Task<ValidResult<bool>> UpdateAsync(UserEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                var user = await _useRepo.Get(obj.Id);

                user.Email = obj.Email;
                user.Nome =obj.Nome;
                user.Role = obj.Role;



                await _useRepo.UpdateAsync(user);
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
        
        public async Task<ValidResult<List<UserEntity>>> GetAll()
        {
            var result = new ValidResult<List<UserEntity>>();
            try
            {
                result.Value = (List<UserEntity>)await _useRepo.GeAll();
                result.Status = true;               
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<UserEntity> Get(string id)
        {
            try
            {
                return await _useRepo.Get(id);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}
