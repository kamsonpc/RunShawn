using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RunShawn.Web.Areas.Admin.Models.Users
{
    public class UserEditViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Imię")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Phone]
        [Display(Name = "Numer Telefonu")]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Rola")]
        public string RoleId { get; set; }
        public List<SelectListItem> Roles { get; set; }

        [Display(Name = "Blokada Konta")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Data Zakończenia Blokady")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? LockoutEndDateUtc { get; set; }
    }
}