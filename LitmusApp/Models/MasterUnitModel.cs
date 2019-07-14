using System;
using System.ComponentModel.DataAnnotations;

namespace Litmus.Models
{
    public class MasterUnitModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(4, ErrorMessage = "Name length should be less than 4")]
        [Display(Name = "Company Code")]
        public int CompanyCode { get; set; }

        [Display(Name = "Unit Code")]
        public int Code { get; set; }

        [StringLength(50, ErrorMessage = "Name length should be less than 50")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Address length should be less than 50")]
        public string Address { get; set; }

        public string CrushingSeason { get; set; }

        [Display(Name = "Report Start Time(MM/dd/yyyy)")]
        public TimeSpan? ReportStartTime { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Crushing Start Date (MM/dd/yyyy)")]
        public DateTime? CrushingStartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Crushing End Date (MM/dd/yyyy)")]
        public DateTime? CrushingEndDate { get; set; }

        public int? DayHours { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Crushing End Date (MM/dd/yyyy)")]
        public Nullable<System.DateTime> EntryDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Crushing End Date (MM/dd/yyyy)")]
        public DateTime? ProcessDate { get; set; }

        public string NewMillCapacity { get; set; }

        public string OldMillCapacity { get; set; }

        public bool? IsActive { get; set; }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        public string Createdy { get; set; }
    }
}