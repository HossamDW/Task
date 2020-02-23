using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Task.Core.DTOs.Base;

namespace Task.Core.DTOs
{
    public class Area : BaseDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
