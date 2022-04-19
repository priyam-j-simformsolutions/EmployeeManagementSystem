using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Service.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Firstname must be less than 50 charectors")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Firstname must be less than 50 charectors")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Address must be less than 50 charectors")]
        public string Address { get; set; }
        [Required]
        [DisplayName("Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Dob { get; set; }
        [Required]
        [DisplayName("Joinin Date")]
        [DataType(DataType.Date)]
        [DisplayFormat( DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? JoiningDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [MaxLength(5000, ErrorMessage = "About section must be less than 5000 charectors")]
        public string About { get; set; }
        [Required]
        public int Role { get; set; }
        public int[] Hobbies { get; set; }
        public List<SkillViewModel> Skills { get; set; }
        
    }

    public class EmployeeTableModel:EmployeeViewModel
    {
        public string skills { get; set; }
    }

}
