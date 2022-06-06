using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Entity.Dto
{
    public class GetProductWithAttributeDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string ProductName { get; set; }
        [Required]
        public IEnumerable<string> Attributes { get; set; }


    }
}
