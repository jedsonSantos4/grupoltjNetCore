using AppCore.Entities;
using AppCore.Interface.Services;
using AppCore.ViewModel.Employee;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/employee")]
    [ApiController]
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employ;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employ, IMapper mapper)
        {
            _employ = employ;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<ActionResult<dynamic>> GetAll()
        {
            // Recupera o usuário
            var res = await _employ.GetAll();

            // Verifica se o usuário existe
            if (res.Value == null)
                return NotFound(new { message = "Usuários não localizados" });

            return new
            {
                employee = _mapper.Map<List<EmployeeViewModel>>(res.Value)
            };
        }

        //[HttpPost("{id}")]
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<dynamic>> Get(string id)
        {

            try
            {
                var res = await _employ.Get(id);

                return new
                {
                    employee = _mapper.Map<EmployeeViewModel>(res)
                };
            }
            catch (Exception)
            {
                return NotFound(new { message = "Usuário não localizado" });
            }
            
        }

      
        [HttpPost]
        [Route("insert")]
        public async Task<ActionResult<dynamic>> Insert([FromBody] EmployeeViewModel model)
        {

            var result = await _employ.InsertAsync(_mapper.Map<EmployeeEntity>(model));

            if (!result.Status)
                return NotFound(result.Message);

            return Ok("Great, registration success");
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult<dynamic>> Put([FromBody] EmployeeViewModel model)
        {
            var res = await _employ.UpdateAsync(_mapper.Map<EmployeeEntity>(model));

            if (!res.Status)
                return NotFound(res.Message);

            return new
            { employee = model };
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult<dynamic>> Delete(string id)
        {
            var result = await _employ.DeleteAsync(id);

            if (!result.Status)
                return NotFound(result.Message);

            return Ok("Great, remove registration success");
        }
    }
}
