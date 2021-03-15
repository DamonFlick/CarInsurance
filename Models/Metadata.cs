using System;
using System.ComponentModel.DataAnnotations;

namespace CarInsurance.Models
{
    public class InsureeMetadata
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [StringLength(100)]
        public string EmailAddress { get; set; }

        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Display(Name = "Date of Birth")]
        [StringLength(50)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Car Make")]
        [StringLength(50)]
        public string CarMake { get; set; }

        [Display(Name = "Car Model")]
        [StringLength(50)]
        public string CarModel { get; set; }

        [Display(Name = "DUI on Record")]
        public bool DUI { get; set; }

        [Display(Name = "Number of Speeding Tickets")]
        public int SpeedingTickets { get; set; }

        [Display(Name = "Coverage Type")]
        public bool CoverageType { get; set; }

        [Display(Name = "Quote")]
        public decimal Quote { get; set; }
    }
}