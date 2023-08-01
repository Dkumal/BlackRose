using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Black_Rose.Models;
using Black_Rose.Repository;

namespace Black_Rose.Controllers
{
    public class PatientController : Controller
    {
        private IConfiguration configuration;
        private PatientRepo repo;
        public PatientController(IConfiguration iconfig)
        {
            configuration = iconfig;
            repo = new PatientRepo(configuration);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<PatientModel> data = new List<PatientModel>();
            data = repo.GetAllPatients();

            ViewData["patients"] = data;
            return View();
        }

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(string firstname, string lastname, string address, string email, long ktp, long phone)
        {
            PatientModel data = new PatientModel();
            data.id = 0;
            data.first_name = firstname;
            data.last_name = lastname;
            data.address = address;
            data.email = email;
            data.phone = phone;
            data.ktp = ktp;
            int insertresult = repo.Upsert(data);

            return RedirectToAction("List");
        }
        
        public IActionResult EditPage(int id)
        {
            PatientModel data = new PatientModel();
            data = repo.GetPatient(id);
            ViewData["patient"] = data;
            return View();
        }

        public IActionResult Edit(string firstname, string lastname, string address, string email, int phone, int ktp, int id)
        {
            PatientModel data = new PatientModel();
            data.id = id;
            data.first_name = firstname;
            data.last_name = lastname;
            data.address = address;
            data.email = email;
            data.phone = phone;
            data.ktp = ktp;
            int insertresult = repo.Upsert(data);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            int result = repo.delete(id);

            return RedirectToAction("List");
        }
    }
}
