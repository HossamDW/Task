using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Task.Core.Entities.Base;

namespace Task.Core.Entities
{
    [Table("District", Schema = "Task")]
    public class District : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int AreaId { get; set; }

        [Required]
        public int CityId { get; set; }
    }
}
