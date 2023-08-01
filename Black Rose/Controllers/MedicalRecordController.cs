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
    public class MedicalRecordController : Controller
    {
        private IConfiguration configuration;
        private MedicalRecordRepo repo;
        public MedicalRecordController(IConfiguration iconfig)
        {
            configuration = iconfig;
            repo = new MedicalRecordRepo(configuration);
        }
        public IActionResult Index(string? namahewan, string? klasifikasi, string? pemilik)
        {
            List<PetModel> datahewan = new List<PetModel>();
            datahewan = repo.getPetsWithFilter(namahewan, klasifikasi, pemilik);

            ViewData["Listhewan"] = datahewan;

            return View();
        }
        public IActionResult ListHewan(string? namahewan, string? klasifikasi, string? pemilik)
        {
            List<PetModel> datahewan = new List<PetModel>();
            datahewan = repo.getPetsWithFilter(namahewan, klasifikasi, pemilik);

            ViewData["Listhewan"] = datahewan;

            return View();

        }

        public IActionResult Examination(int ID)
        {
            ExamDataModel edm = new ExamDataModel();
            edm = repo.GetPetData(ID);
            ViewData["DataHewan"] = edm;
           
            return View();
        }

        public IActionResult SaveExam(ExaminationFormModel data)
        {
            int result = repo.Save(data);
            return View("Index");
        }

        public IActionResult History(int ID)
        {
            List<ExaminationFormModel> data = new List<ExaminationFormModel>();
            data = repo.getHistorybyPets(ID);

            ExamDataModel edm = new ExamDataModel();
            edm = repo.GetPetData(ID);

            ViewData["DataHistory"] = data;
            ViewData["NamaHewan"] = edm.namahewan;

            return View();
        }

        public IActionResult ExaminationLoad(int ID)
        {
            ExaminationFormLoadModel data = new ExaminationFormLoadModel();
            data = repo.getExamRecordHistoryByID(ID);
            data.examdata = repo.GetPetData(data.idhewan);

            ViewData["Data"] = data;

            return View();
        }
    }
}
