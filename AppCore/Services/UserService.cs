using AppCore.Entities;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class UserService : IUserServece
    {
        private readonly IUserRepository _userRepo;
        public UserService(IUserRepository userRepository)
        {
            _userRepo = userRepository;
        }

        public async Task<ValidResult<bool>> UpdateAsync(UserEntity user)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _userRepo.UpdateAsync(user);
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

        public async Task<ValidResult<bool>> InsertAsync(UserEntity user)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _userRepo.InsertAsync(user);
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
        
        public async Task<ValidResult<bool>> DeleteAsync(string id)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _userRepo.DeleteAsync(id);
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

        public async Task<ValidResult<UserEntity>> GetRegisterUser(string id)
        {
            var result = new ValidResult<UserEntity>();
            try
            {
                result.Value =  await _userRepo.GetRegisterUser(id);
                result.Status = true;                
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ValidResult<List<UserEntity>>> GetRegisterUsersAll()
        {
            var result = new ValidResult<List<UserEntity>>();
            try
            {
                var ctrl = await _userRepo.GetRegisterUsersAll();
                result.Status = true;
                result.Value = ctrl.ToList();
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
