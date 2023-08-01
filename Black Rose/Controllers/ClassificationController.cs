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
    public class ClassificationController : Controller
    {
        private IConfiguration configuration;
        private ClassificationRepo repo;
        public ClassificationController(IConfiguration iconfig)
        {
            configuration = iconfig;
            repo = new ClassificationRepo(configuration);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<ClassificationModel> data = new List<ClassificationModel>();
            data = repo.GetAllClassification();

            ViewData["classifications"] = data;
            return View();
        }

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(string name, string description)
        {
            ClassificationModel data = new ClassificationModel();
            data.id = 0;
            data.name = name;
            data.description= description;
           
            int insertresult = repo.Upsert(data);

            return RedirectToAction("List");
        }
        
        public IActionResult EditPage(int id)
        {
            ClassificationModel data = new ClassificationModel();
            data = repo.GetClassification(id);
            ViewData["classification"] = data;
            return View();
        }

        public IActionResult Edit(string name, string description, int id)
        {
            ClassificationModel data = new ClassificationModel();
            data.id = id;
            data.name = name;
            data.description= description;
            
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
