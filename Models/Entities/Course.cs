using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Entities
{
    public class Course : BaseEntity
    {        
        [Required]
        public string courseCode { get; set; }
    }
}
