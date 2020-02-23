using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Task.Core.Entities.Base;

namespace Task.Core.Entities
{
    [Table("Area", Schema = "Task")]
    public class Area : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
