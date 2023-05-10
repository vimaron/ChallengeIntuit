using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ClientCreateCriteria
    { 
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        [Required]
        public string CUIT { get; set; }
        public string Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Mail { get; set; }
    }
}
