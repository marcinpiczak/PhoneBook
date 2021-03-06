﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Repositories;
using PhoneBook.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhoneBook.Controllers
{
    public class PersonController : Controller
    {

        private readonly SourceManager _manager = new SourceManager();

        public IActionResult Index(int page = 1, int linesPerPage = 10, string filterLastName = "")
        {
            //var manager = new SourceManager();
            var list = _manager.Get(1,1);

            if (!string.IsNullOrWhiteSpace(filterLastName))
            {
                list = list.Where(x => !string.IsNullOrEmpty(x.LastName) && x.LastName.ToLower().StartsWith(filterLastName.ToLower())).ToList();
            }

            /*liczba wpisów na stronie*/
            //int linesPerPage = 10;

            var numOfPages = (int)Math.Ceiling((decimal) list.Count / (decimal) linesPerPage);

            page = page < 1 ? 1 : page > numOfPages ? numOfPages : page;

            ViewBag.NumberOfRows = list.Count;
            //ViewBag.CurrentPage = page;
            //ViewBag.TotalPages = numOfPages;
            ViewBag.FilterLastName = filterLastName;
            ViewBag.LinesPerPage = linesPerPage;

            list = list.Skip((page - 1) * linesPerPage).Take(linesPerPage).ToList();

            var personViewModel = new PersonViewModel()
            {
                NumberOfRows = list.Count,
                CurrentPage = page,
                TotalPages = numOfPages,
                FilterLastName = filterLastName,
                LinesPerPage = linesPerPage,
                PersonList = list
            };

            //return View(list);
            return View(personViewModel);
        }

        [HttpGet]
        public IActionResult Add()
        {
            //return View(new PersonModel());
            return View();
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
                //var now = DateTime.Now;
                //person.Updated = now;
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
                var now = DateTime.Now;
                personModel.Updated = now;
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
