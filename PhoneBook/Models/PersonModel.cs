using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class PersonModel
    {
        [Key]
        [Required]
        [DisplayName("ID")]
        public int Id { get; set; }

        [Required (ErrorMessage = "Pole Imię jest wymagane")]
        [DisplayName("Imię")]
        [MinLength(3, ErrorMessage = "Imię musi składać się przynajmniej z 3 liter")]
        [MaxLength(255, ErrorMessage = "Imię może składać się maksymalnie z 255 liter")]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [MinLength(3, ErrorMessage = "Nazwisko musi składać się przynajmniej z 3 liter")]
        [MaxLength(255, ErrorMessage = "Nazwisko może składać się maksymalnie z 255 liter")]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Pole Nr telefonu jest wymanage")]
        [DisplayName("Nr telefonu")]
        [MinLength(4, ErrorMessage = "Nr telefonu musi składać się przynajmniej z 4 znaków")]
        [MaxLength(15, ErrorMessage = "Nr telefonu może składać się maksymalnie z 15 znaków")]
        public string Phone { get; set; }

        [EmailAddress (ErrorMessage = "Podaj prawidłowy adres e-mail")]
        [MaxLength(255, ErrorMessage = "Adres e-mail może składać się maksymalnie z 255 znaków")]
        [DisplayName("Adres E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Data utworzenia")]
        public DateTime Created { get; set; }

        [Required]
        [DisplayName("Data modyfikacji")]
        public DateTime Updated { get; set; }

        public PersonModel()
        {
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
    }
}
