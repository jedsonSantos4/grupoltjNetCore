using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.ViewModel
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }        
        public string Email { get; set; }    
        public string Role { get; set; }
        public UserViewModel()
        {
            Role = "Default".ToUpper();
        }
    }
}
