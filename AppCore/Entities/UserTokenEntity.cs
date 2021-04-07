using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities
{
    public class UserTokenEntity : BaseEntity
    {
        
        public string nome { get; set; }
        public string email { get; set; }
        public DateTime createIndexes { get; set; }
        public string password { get; set; }
        public string Role { get; set; }

        public UserTokenEntity()
        {
            Role = "default";
        }
    }
}
