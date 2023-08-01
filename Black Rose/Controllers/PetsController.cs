using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Black_Rose.Models;
using Black_Rose.Repository;

namespace Black_Rose.Controllers
{
    public class PetsController : Controller
    {
        private IConfiguration configuration;
        private PetsRepo repo;
        public PetsController(IConfiguration iconfig)
        {
            configuration = iconfig;
            repo = new PetsRepo(configuration);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List(string? namahewan, string? klasifikasi, string? pemilik)
        {
            List<PetModel> data = new List<PetModel>();
            data = repo.getPetsWithFilter(namahewan,klasifikasi,pemilik);

            ViewData["Pets"] = data;
            return View();
        }

        public IActionResult AddPage()
        {
            PatientRepo pr = new PatientRepo(configuration);
            List<PatientModel> pasien = pr.GetAllPatients();
            List<SelectListItem> listpasien = new List<SelectListItem>();
           foreach(PatientModel item in pasien)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.id.ToString();
                x.Text = string.Concat(item.first_name, " ", item.last_name);
                listpasien.Add(x);
            }

            ViewData["ListPemilik"] = listpasien;
            
            ClassificationRepo classrepo = new ClassificationRepo(configuration);
            List<ClassificationModel> classifications = classrepo.GetAllClassification();
            List<SelectListItem> listklasifikasi = new List<SelectListItem>();
            foreach (ClassificationModel item in classifications)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.id.ToString();
                x.Text = item.name;
                listklasifikasi.Add(x);
            }
            ViewData["ListKlasifikasi"] = listklasifikasi;

            return View();
        }

        [HttpPost]
        public IActionResult Save(PetModel formdata)
        {
            //PetModel data = new PetModel();
            //data.id = 0;
            //data.idpemilik = formdata.idpemilik;
            //data.nama = formdata.nama;
            //data.sex = sex;
            //data.jenis = jenis;
            //data.warna = warna;
            //data.pola = pola;
            //data.idklasifikasi = klasifikasi;

            int insertresult = repo.Upsert(formdata);

            return RedirectToAction("List");
        }
        
        public IActionResult EditPage(int id)
        {
            PetModel data = new PetModel();
            data = repo.GetPet(id);
            ViewData["pet"] = data;

            PatientRepo pr = new PatientRepo(configuration);
            List<PatientModel> pasien = pr.GetAllPatients();
            List<SelectListItem> listpasien = new List<SelectListItem>();
            foreach (PatientModel item in pasien)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.id.ToString();
                x.Text = string.Concat(item.first_name, " ", item.last_name);
                listpasien.Add(x);
            }

            ViewData["ListPemilik"] = listpasien;

            ClassificationRepo classrepo = new ClassificationRepo(configuration);
            List<ClassificationModel> classifications = classrepo.GetAllClassification();
            List<SelectListItem> listklasifikasi = new List<SelectListItem>();
            foreach (ClassificationModel item in classifications)
            {
                SelectListItem x = new SelectListItem();
                x.Value = item.id.ToString();
                x.Text = item.name;
                listklasifikasi.Add(x);
            }
            ViewData["ListKlasifikasi"] = listklasifikasi;
            return View();
        }

        public IActionResult Edit(string pemilik, string sex, string jenis,
            string warna,string pola, string klasifikasi, int id, string nama)
        {
            PetModel data = new PetModel();
            data.id = id;
            data.idpemilik = pemilik;
            data.nama = nama;
            data.sex = sex;
            data.jenis = jenis;
            data.warna = warna;
            data.pola = pola;
            data.idklasifikasi = klasifikasi;

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
