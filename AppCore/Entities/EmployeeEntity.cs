using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Entities
{
    public class EmployeeEntity :BaseEntity
    {
        [Required]
        [BsonElement("nome")]
        public string Nome { get; set; }
        [Required]
        [BsonElement("dt_nasc")]
        public DateTime Nascimento { get; set; }
        [Required]
        [BsonElement("cpf")]
        public decimal Cpf { get; set; }
        [Required]
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
