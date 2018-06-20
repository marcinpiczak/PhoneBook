using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Repositories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
    public class PersonController : Controller
    {

        private readonly SourceManager _manager = new SourceManager();

        public IActionResult Index(int page = 1, string filterLastName = "")
        {
            //var manager = new SourceManager();
            var list = _manager.Get(1,1);

            if (!string.IsNullOrWhiteSpace(filterLastName))
            {
                list = list.Where(x => !string.IsNullOrEmpty(x.LastName) && x.LastName.ToLower().StartsWith(filterLastName.ToLower())).ToList();
            }

            int linesPerPage = 10;

            var numOfPages = (int)Math.Ceiling((decimal) list.Count / (decimal) linesPerPage);

            page = page < 1 ? 1 : page > numOfPages ? numOfPages : page;

            ViewBag.NumberOfRows = list.Count;
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = numOfPages;
            ViewBag.FilterLastName = filterLastName;

            list = list.Skip((page - 1) * linesPerPage).Take(linesPerPage).ToList();
            
            return View(list);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new PersonModel());
        }

        [HttpPost]
        public IActionResult Add(PersonModel personModel)
        {
            if (!ModelState.IsValid)
            {
                return View(personModel);
            }

            //var manager = new SourceManager();
            try
            {
                _manager.Add(personModel);
            }
            catch (Exception e)
            {
                throw ;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //var manager = new SourceManager();
            try
            {
                var person = _manager.GetByID(id);
                var now = DateTime.Now;
                person.Updated = now;
                return View(person);
            }
            catch (Exception e)
            {
                throw;
            } 
        }

        [HttpPost]
        public IActionResult Edit(PersonModel personModel)
        {
            if (!ModelState.IsValid)
            {
                return View(personModel);
            }

            //var manager = new SourceManager();
            try
            {
                _manager.Update(personModel);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Remove(int id)
        {
            //var manager = new SourceManager();
            var person = _manager.GetByID(id);

            return View(person);
        }

        [HttpPost]
        public IActionResult RemoveConfirm(int id)
        {
            //var manager = new SourceManager();
            try
            {
                _manager.Remove(id);
            }
            catch (Exception e)
            {
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}
