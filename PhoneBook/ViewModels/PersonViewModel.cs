using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhoneBook.Models;

namespace PhoneBook.ViewModels
{
    public class PersonViewModel
    {
        public PersonModel DummyPerson { get; } = new PersonModel();

        public List<PersonModel> PersonList = new List<PersonModel>();
        public int NumberOfRows;
        public int CurrentPage;
        public int TotalPages;
        public string FilterLastName;
        public int LinesPerPage;
    }
}
