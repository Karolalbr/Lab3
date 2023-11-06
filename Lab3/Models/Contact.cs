using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class Contact
    {

        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Muisz podac imie!")]
        [StringLength(maximumLength: 50, ErrorMessage = "Imie jest zbyt długie, maksymalnie 50 znakow!")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Musisz podac poprawny email(brak znaku @)!")]
        public string Email { get; set; }
        [Phone(ErrorMessage = "Numer telefonu powinen zawierać cyfry")]
        public string Phone { get; set; }

        public DateTime? Birth { get; set; }

    }
}