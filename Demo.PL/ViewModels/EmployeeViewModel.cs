using Demo.DAL.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Http;

namespace Demo.PL.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = "Max length is 50")]
        [MinLength(5, ErrorMessage = "Min length is 50")]
        public string Name { get; set; }

        [Range(22, 60, ErrorMessage = "Age must be between 22 to 60")]
        public int? Age { get; set; }


        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$",
            ErrorMessage = "Adress must be in form of '123-street-City-Country'")]
        public string Address { get; set; }

     
        [Range(4000, 8000, ErrorMessage = "Salary must be between 4000 to 8000")]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        [EmailAddress(ErrorMessage = "Salary must be between 4000 to 8000")]
        public string Email { get; set; }


        public int PhoneNumber { get; set; }

        public string ImageName { get; set; }

        public IFormFile Image { get; set; }

        public DateTime HireDate { get; set; }
       

        public int? DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
