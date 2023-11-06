using Lab3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Lab3.Controllers
{
    public class ContactController : Controller
    {
        static Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();
        static int id = 1;

        public IActionResult Index()
        {
            return View(_contacts);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact model)
        {
            if (ModelState.IsValid)
            {
                model.Id = id++;
                _contacts.Add(model.Id, model);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Update(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_contacts.ContainsKey(id))
            {
                return View(_contacts[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_contacts.ContainsKey(id))
            {
                _contacts.Remove(id);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_contacts[id]);
        }

        [HttpPost]
        public IActionResult Details(Contact model)
        {
            if (ModelState.IsValid)
            {
                _contacts[model.Id] = model;
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
