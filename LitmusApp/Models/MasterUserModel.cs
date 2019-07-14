using System;
using System.ComponentModel.DataAnnotations;

namespace Litmus.Models
{
    public class MasterUserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Company code cannot be empty")]        
        [Display(Name = "Company Code")]
        public int? CompanyCode { get; set; }

        [Required(ErrorMessage = "Unit Code cannot be empty")]        
        [Display(Name = "Unit Code")]
        public int? UnitCode { get; set; }

        [Required(ErrorMessage ="User Code cannot be empty")]
        public string Code { get; set; }

        [Required(ErrorMessage = "First Name cannot be empty")]
        [StringLength(50, ErrorMessage = "FirstName length should be less than 50")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "LastName length should be less than 50")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50, ErrorMessage = "CreatedDate length should be less than 50")]
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }
    }
}