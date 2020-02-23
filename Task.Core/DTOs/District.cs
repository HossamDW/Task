using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Task.Core.DTOs.Base;

namespace Task.Core.DTOs
{
    public class District : BaseDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int AreaId { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}
