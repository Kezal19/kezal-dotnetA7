
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 
using System.Linq;
using System.Threading.Tasks;



namespace NEW_MVC.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID{get; set;}
        [Required]
        public string? Teacher_Name {get; set;}
        [Required]
        public string? Class {get; set;}
        // [ForeignKey("Teacher")]
        // [Display(Name="Subject")]

        public int SubjectID {get; set;}

        // public virtual Subject {get; set;}
    }
}