using HomeTask_1.Models;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace HomeTask_1.Controllers
{
    public class HomeController : Controller
    {
        UserDBContext db = UsersRepository.context;
        private UsersRepository repository = UsersRepository.Current;

        public ActionResult Index(int? page)
        {
            List<User> list = new List<User>(repository.GetAll().Count());
             for(int i = 0;i< repository.GetAll().Count(); i++)
             {
                list.Add(new User() { Id = repository.GetAll()[i].Id, UserName = repository.GetAll()[i].UserName });
            }
            const int pageSize = 5;
            int pageNumber = (page ?? 1);

               // System.Diagnostics.Debug.WriteLine(pageNumber+" "+pageSize);
            
            return View(list.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Add(User item)
        {
            if (ModelState.IsValid)
            {
                repository.Add(item);
                return RedirectToAction("Index");
            }
            else return View("Index");
        }

        public ActionResult Update(User item)
        {
            if (ModelState.IsValid && repository.Update(item))
                return RedirectToAction("Index");
            else return View("Index");
        }

        public ActionResult Delete(User item)
        {
            if (ModelState.IsValid)
            {
                repository.Remove(item.Id);
                return RedirectToAction("Index");
            }
           else return View("Index");
        }
    }


}
