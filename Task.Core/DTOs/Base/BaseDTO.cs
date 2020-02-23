using System;
using System.Collections.Generic;
using System.Text;

namespace Task.Core.DTOs.Base
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
