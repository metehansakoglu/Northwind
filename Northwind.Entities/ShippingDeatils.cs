using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using Castle.DynamicProxy.Generators.Emitters;

namespace Northwind.Entities
{
    public class ShippingDeatils
    {
        [Required(ErrorMessage = "İsim girilmesi zorunludur")]
        
        public string Name { get; set; }
        [Required()]
        [MinLength(10)]
        [MaxLength(50)]
        public string Adress1 { get; set; }
        [Required()]
        [MaxLength(50)]
        public string Adress2 { get; set; }
        
       

        public string Adress3 { get; set; }
        [Required()]

        public string City { get; set; }
        [Required()]

        public string Country { get; set; }
        [Required()]

        public bool IsGift { get; set; }
        

    }
} 

