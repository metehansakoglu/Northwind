using System.ComponentModel.DataAnnotations;
using Castle.DynamicProxy.Generators.Emitters;

namespace Northwind.Entities
{
    public class User
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType((DataType.Password))]
        public string Password { get; set; }
    }
}


