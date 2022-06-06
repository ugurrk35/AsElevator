using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsElevator.Entity.Dto
{
    public class CreateProductCategoryDto
    {
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int CategoryID { get; set; }
    }
}
