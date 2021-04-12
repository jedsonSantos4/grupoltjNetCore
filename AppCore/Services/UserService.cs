using AppCore.Entities;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using AppCore.validacoes;
using System;
using System.Collections;
using System.Collections.Generic;
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
                return result;

            try
            {
                result.Value = await _useRepo.Get(email,password);

                //if (!ValidationPassword.IsPassWord(result.Value.password, password))
                //    throw new Exception();

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
                await _useRepo.UpdateAsync(obj);
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

        public Task<ValidResult<UserEntity>> Get(string id)
        {
            throw new NotImplementedException();
        }
        
        public async Task<ValidResult<List<UserEntity>>> GetAll()
        {
            var result = new ValidResult<List<UserEntity>>();
            try
            {
                var teste = await _useRepo.GeAll();

                result.Status = true;
                result.Value = teste;
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
