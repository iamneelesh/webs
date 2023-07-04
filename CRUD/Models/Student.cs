using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUDDemo.Models
{
    public class Student
    {
        [Display(Name ="Id")]
        public int StudentId { get; set; }


        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(25, ErrorMessage = "Must be less than 25")]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [Range(01, 12, ErrorMessage = "Must not be greater than 12")]
        [Display(Name = "Class")]
        public int StudentClass { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [Range(4,21, ErrorMessage = "Must be between 04 to 21")]
        [Display(Name = "Age")]
        public int StudentAge { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(2, ErrorMessage = "Only Initials are required like 'M' or 'F' or 'O'")]
        [Display(Name = "Gender")]
        public String StudentGender { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [RegularExpression(@"[6789][0-9]{9}",ErrorMessage ="Enter a valid Phone Number.")]
        [Display(Name = "Phone Number")]
        public long PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(25, ErrorMessage = "Must be less than 25")]
        [Display(Name = "Home City")]
        public String HomeCity { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [RegularExpression(@"[a-zA-Z0-9_\-\.]+[@]+[a-z]+[\.][a-z]{2,4}",ErrorMessage ="Enter a valid email Id.")]
        [Display(Name = "Email-Id")]
        public String EmailId { get; set; }

        public List<Student> listStudents { get; set; }
    }
}