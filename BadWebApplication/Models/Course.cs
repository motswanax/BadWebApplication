using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BadWebApplication.Models
{
    public class Course
    {
        //[Key()]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        //[Display(Name = "Course Title")]
        //[Required(ErrorMessage = "Please fill the Course Title")]
        public string CourseName { get; set; }
        public int Credits { get; set; }
    }
}
