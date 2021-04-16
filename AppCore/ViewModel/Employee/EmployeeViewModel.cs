using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.ViewModel.Employee
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public decimal Cpf { get; set; }
        public string Email { get; set; }
    }
}
