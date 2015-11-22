using System;
using System.Collections.Generic;
using System.Web.Http;
using HomeTask_1.Models;

namespace HomeTask_1.Controllers
{
    public class WebController : ApiController
    {
        private UsersRepository repo = UsersRepository.Current;

        public List<User> GetAllUser()
        {
        
            return repo.GetAll();
        }

        public User GetUser(int id)
        {
            return repo.Get(id);
        }

        [HttpPost]
        public User CreateUser(User item)
        {
            return repo.Add(item);
        }

        [HttpPut]
        public bool UpdateUser(User item)
        {
            return repo.Update(item);
        }

        public void DeleteUser(int id)
        {
            repo.Remove(id);
        }

    
    }
}