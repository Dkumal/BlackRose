using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Black_Rose.Models;
using Black_Rose.Repository;
using Black_Rose.helper;

namespace Black_Rose.Controllers
{
    public class UserController : Controller
    {
        private IConfiguration configuration;
        private UserRepo UserRepo;
        private EncDec encDec;
        public UserController(IConfiguration iconfig)
        {
            configuration = iconfig;
            UserRepo = new UserRepo(configuration);
            encDec = new EncDec(configuration);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<UserModels> data = new List<UserModels>();
            data = UserRepo.GetAllUser();

            ViewData["users"] = data;
            return View();
        }

        public IActionResult AddPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(string username, string password, string fullname, int roleid)
        {

            UserModels data = new UserModels();
            data.fullname = fullname;
            data.username = username;
            data.password = encDec.enc(password);
            data.roleid = roleid;
            data.id = 0;

            int insertresult = UserRepo.Upsert(data);

            return RedirectToAction("List");
        }
        
        public IActionResult EditPage(int id)
        {
            UserModels data = new UserModels();
            data = UserRepo.GetUser(id);
            data.password = encDec.dec(data.password);
            ViewData["user"] = data;
            return View();
        }

        public IActionResult Edit(string username, string password, string fullname, int roleid, int id)
        {
            UserModels data = new UserModels();
            data.fullname = fullname;
            data.username = username;
            data.password = encDec.enc(password);
            data.roleid = roleid;
            data.id = id;

            int insertresult = UserRepo.Upsert(data);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            int result = UserRepo.delete(id);

            return RedirectToAction("List");
        }
    }
}
