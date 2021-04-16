using AppCore.Entities;
using AppCore.Interface.Repositores;
using AppCore.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employee;
        public EmployeeService(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        public async Task<ValidResult<bool>> DeleteAsync(string id)
        {
            var result = new ValidResult<bool>();
            try
            {
                await _employee.DeleteAsync(id);
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

     
        public async Task<ValidResult<bool>> InsertAsync(EmployeeEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                var employee = await GetAll();

                if (employee.Value == null || !employee.Status)
                {
                    result.Message = "Error: when querying user existence. Please try again!";
                    return result;
                }

                if (!ValidationEmail.IsValidEmail(obj.Email))
                {
                    result.Message = "Erro: Email type is not valid. Please try again!";
                    return result;
                }

                if (ValidationEmail.ExistingEmail(obj.Email, employee.Value.Select(p=> p.Email)))
                {
                    result.Message = "Erro: Email already has a registration. Please try another email";
                    return result;
                }

                await _employee.InsertAsync(obj);
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

        public async Task<ValidResult<bool>> UpdateAsync(EmployeeEntity obj)
        {
            var result = new ValidResult<bool>();
            try
            {
                var employee = await _employee.Get(obj.Id);
                if (employee == null)
                {
                    result.Message = "Erro: User not located,. Try again";
                    return result;
                }

                employee.Email = obj.Email;
                employee.Nome = obj.Nome;
                employee.Cpf = obj.Cpf;
                employee.Nascimento =obj.Nascimento;

                await _employee.UpdateAsync(employee);
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

        public async Task<EmployeeEntity> Get(string id)
        {
            try
            {
                return await _employee.Get(id);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
              
        public async Task<ValidResult<List<EmployeeEntity>>> GetAll()        
        {
            var result = new ValidResult<List<EmployeeEntity>>();
            try
            {
                result.Value = (List<EmployeeEntity>)await _employee.GeAll();
                result.Status = true;
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
