using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.DTOs
{
    public class CourseDTO
    {

        [Required]
        public string courseCode { get; set; }
    }
}
