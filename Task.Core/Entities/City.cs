using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Task.Core.Entities.Base;

namespace Task.Core.Entities
{
    [Table("City", Schema = "Task")]
    public class City : BaseEntity 
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int AreaId { get; set; }
    }
}
